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
    public class ReportController : ControllerBase
    {
        private readonly ILogger<ReportController> _logger;
        private readonly IReportModel _reportModel;

        public ReportController(ILogger<ReportController> logger, IReportModel reportModel)
        {
            _logger = logger;
            _reportModel = reportModel;
        }

        [HttpGet]
        public async Task<ActionResult> GetTickets()
        {
            return Ok(await _reportModel.GetTickets());
        }

        [HttpGet("{userId:guid}")]
        public async Task<ActionResult> GetTicketsByUser(Guid userId)
        {
            return Ok(await _reportModel.GetUserTickets(userId));
        }

        [HttpGet]
        [Route("getrelevanttickets")]
        public async Task<ActionResult<TicketEntity>> Get(DateTime StartDate, DateTime EndDate)
        {
            var result = Ok(await _reportModel.GetRelevantTickets(StartDate, EndDate));
            if(result != null) 
            {
                return result;
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
