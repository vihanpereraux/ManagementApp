using ManagmentAppTestOne.Server.Data;
using ManagmentAppTestOne.Server.Models;
using ManagmentAppTestOne.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
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
        public async Task<ActionResult> GetAllProjects()
        {
            return Ok(await _projectModel.GetAllProjects());
        }

        [HttpGet("{companyId:guid}")]
        public async Task<ActionResult> GetProjects(Guid companyId)
        {
            return Ok(await _projectModel.GetProjects(companyId));
        }

        [HttpGet("{projectName}")]
        public async Task<ActionResult<ProjectEntity>> GetProjectByName(string projectName)
        {
            return Ok(await _projectModel.GetProjectByName(projectName));
        }

        [HttpPost]
        public async Task<ActionResult<ProjectEntity>> Post(ProjectEntity project)
        {
            await _projectModel.Post(project);
            return new CreatedAtRouteResult("GetProject", new { ProjectName = project.ProjectName }, project);
        }

        [HttpPut]
        public async Task<ActionResult> Put(ProjectEntity project)
        {
            await _projectModel.Put(project);
            return new CreatedAtRouteResult("GetProject", new { ProjectName = project.ProjectName }, project);
        }

        [HttpDelete("{projectName}")]
        public async Task<ActionResult> Delete(string projectName)
        {
            var deleted = await _projectModel.Delete(projectName);
            return new CreatedAtRouteResult("GetProject", new { projectName = deleted.ProjectName }, deleted);
        }
    }
}
