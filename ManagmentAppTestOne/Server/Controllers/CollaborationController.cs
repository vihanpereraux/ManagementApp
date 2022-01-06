using ManagmentAppTestOne.Server.Models;
using ManagmentAppTestOne.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ManagmentAppTestOne.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CollaborationController:ControllerBase
    {
        private readonly ILogger<CollaborationController> _logger;
        private readonly ICollaborationModel _collaborationModel;

        public CollaborationController(ILogger<CollaborationController> logger, ICollaborationModel collaborationModel)
        {
            _logger = logger;
            _collaborationModel = collaborationModel;
        }

        [HttpGet]
        public async Task<ActionResult> GetCollaborations()
        {
            return Ok(await _collaborationModel.GetCollaborations());
        }

        /*[HttpGet("{companyName}", Name = "GetCompany")]
        public async Task<ActionResult<CompanyEntity>> Get(string companyName)
        {
            return Ok(await _companyModel.GetCompanyByName(companyName));
        }*/

        [HttpGet("{projectId:guid}")]
        public async Task<ActionResult> Get(Guid projectId)
        {
            return Ok(await _collaborationModel.GetCollaborationById(projectId));
        }

        [HttpPost]
        public async Task<ActionResult<CollaborationEntity>> Post(CollaborationEntity collaboration)
        {
            var result = await _collaborationModel.Post(collaboration);
            if( result != null )
            {
                return Ok(new CreatedAtRouteResult("GetCollaboration", new { collaborationId = collaboration.CollaborationId }, collaboration));
            }
            else 
            {
                return BadRequest();
            }
            /*return new CreatedAtRouteResult("GetCollaboration", new { collaborationId = collaboration.CollaborationId }, collaboration);*/
        }

        [HttpPut]
        public async Task<ActionResult> Put(CollaborationEntity collaboration)
        {
            await _collaborationModel.Put(collaboration);
            return new CreatedAtRouteResult("GetCollaboration", new { collaborationId = collaboration.CollaborationId }, collaboration);
        }

        [HttpDelete("{collaborationId}")]
        public async Task<ActionResult> Delete(Guid collaborationId)
        {
            var deleted = await _collaborationModel.Delete(collaborationId);
            return new CreatedAtRouteResult("GetCollaboration", new { collaborationId = deleted.CollaborationId }, deleted);
        }

    }
}
