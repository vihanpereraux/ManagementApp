using ManagmentAppTestOne.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagmentAppTestOne.Server.Models
{
    public interface IProjectModel
    {
        public Task<IEnumerable<ProjectEntity>> GetProjects();

        public Task<ProjectEntity> GetProjectByName(string  projectName);

        public Task<ProjectEntity> Post(ProjectEntity prjectModel);

        public Task<ProjectEntity> Put(ProjectEntity prjectModel);

        public Task<ProjectEntity> Delete(string projectName);
    }
}
