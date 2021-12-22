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
        public async Task<ActionResult> GetCompanies()
        {
            return Ok(await _collaborationModel.GetCollaborations());
        }

        [HttpGet("{collaborationId}", Name = "GetCollaboration")]
        public async Task<ActionResult<CollaborationEntity>> Get(Guid collaborationId)
        {
            return Ok(await _collaborationModel.GetCollaborationById(collaborationId));
        }

        [HttpPost]
        public async Task<ActionResult<CollaborationEntity>> Post(CollaborationEntity collaboration)
        {
            await _collaborationModel.Post(collaboration);
            return new CreatedAtRouteResult("GetCollaboration", new { collaborationId = collaboration.CollaborationId }, collaboration);
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
