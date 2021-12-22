using ManagmentAppTestOne.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagmentAppTestOne.Server.Models
{
    public interface IProjectModel
    {
        public Task<IEnumerable<ProjectEntity>> GetProjects(Guid companyId);

        public Task<ProjectEntity> GetProjectByName(string  projectName);

        public Task<ProjectEntity> Post(ProjectEntity project);

        public Task<ProjectEntity> Put(ProjectEntity project);

        public Task<ProjectEntity> Delete(string projectName);
    }
}
