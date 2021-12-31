using ManagmentAppTestOne.Server.Models;
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
    }
}
