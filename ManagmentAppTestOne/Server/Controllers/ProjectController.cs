using ManagmentAppTestOne.Server.Data;
using ManagmentAppTestOne.Server.Models;
using ManagmentAppTestOne.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagmentAppTestOne.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController: ControllerBase
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly IProjectModel _projectModel;

        public ProjectController(ILogger<ProjectController> logger, IProjectModel projectModel)
        {
            _logger = logger;
            _projectModel = projectModel;
        }

        [HttpGet]
        public async Task<ActionResult> GetProjects()
        {
            return Ok(await _projectModel.GetProjects());
        }

        [HttpGet("{projectName}", Name = "GetProject")]
        public async Task<ActionResult<CompanyEntity>> Get(string projectName)
        {
            return Ok(await _projectModel.GetProjectByName(projectName));
        }

        [HttpPost]
        public async Task<ActionResult<ProjectEntity>> Post(ProjectEntity projectModel)
        {
            await _projectModel.Post(projectModel);
            return new CreatedAtRouteResult("GetProject", new { ProjectName = projectModel.ProjectName }, projectModel);
        }

        [HttpPut]
        public async Task<ActionResult> Put(ProjectEntity projectModel)
        {
            await _projectModel.Put(projectModel);
            return new CreatedAtRouteResult("GetProject", new { ProjectName = projectModel.ProjectName }, projectModel);
        }

        [HttpDelete("{projectName}")]
        public async Task<ActionResult> Delete(string projectName)
        {
            var deleted = await _projectModel.Delete(projectName);
            return new CreatedAtRouteResult("GetProject", new { projectName = deleted.ProjectName }, deleted);
        }
    }
}
