using ManagmentAppTestOne.Server.Data;
using ManagmentAppTestOne.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagmentAppTestOne.Server.Models
{
    public class ProjectModel:IProjectModel
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public readonly ILogger<ProjectModel> _logger;

        public ProjectModel(ILogger<ProjectModel> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<ProjectEntity>> GetProjects()
        {
            return await _applicationDbContext.Projects.ToListAsync();
        }

        public async Task<ProjectEntity> GetProjectByName(string projectName)
        {
            return await _applicationDbContext.Projects.FirstOrDefaultAsync(x => x.ProjectName == projectName);
        }

        public async Task<ProjectEntity> Post(ProjectEntity projectModel)
        {
            var result = _applicationDbContext.Projects.Add(projectModel);
            await _applicationDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<ProjectEntity> Put(ProjectEntity projectModel)
        {
            _applicationDbContext.Entry(projectModel).State = EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return projectModel;
        }

        /*private async Task<ProjectEntity> GetProjectByName(string projectName)
        {
            return await _applicationDbContext.Projects.FirstOrDefaultAsync(project => project.ProjectName == projectName);
        }*/

        public async Task<ProjectEntity> Delete(string projectName)
        {
            var result = await GetProjectByName(projectName);
            if (result != null)
            {
                _applicationDbContext.Projects.Remove(result);
                await _applicationDbContext.SaveChangesAsync();
                return result;
            }
            return null;

        }
    }
}
