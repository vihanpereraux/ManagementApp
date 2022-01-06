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
    public class PredictionController : ControllerBase
    {
        private readonly ILogger<PredictionController> _logger;
        private readonly IPredictionModel _predictionModel;

        public PredictionController(ILogger<PredictionController> logger, IPredictionModel predictionModel)
        {
            _logger = logger;
            _predictionModel = predictionModel;
        }

        [HttpGet]
        public async Task<IActionResult> GetRelevantAvg(Guid companyId) 
        {
            var result = await _predictionModel.GetRelevantAvg(companyId);

            return Ok(result);  
        }

        /*[HttpGet]
        [Route("getemployeeavg")]
        public async Task<float> GetEmployeeAvg(Guid companyId) 
        {
            var result = await _predictionModel.GetEmployeeAvg(companyId);
            return result;
        }*/
    }
}
