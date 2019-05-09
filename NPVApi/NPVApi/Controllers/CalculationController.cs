using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NPV.DatabaseCore;
using NPV.Models.ViewModels;
using NPV.Services.CalculationService;
namespace NPV.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationController : ControllerBase
    {
        private readonly ICalculationService _calculationService;
        private readonly NPVContext _npvContext;
        public CalculationController(NPVContext npvContext, ICalculationService calculationService)
        {
            _npvContext = npvContext;
            _calculationService = calculationService;
        }

        [HttpGet("calculate-npv/{calculationModelJson}")]
        public ActionResult<double> CalculatePresentAndNetPresentValue(string calculationModelJson)
        {
            if (string.IsNullOrEmpty(calculationModelJson))
                throw new Exception("The parameter calculationModelJson is null");

            var calculationModel = JsonConvert.DeserializeObject<CalculationModel>(calculationModelJson);

            if (calculationModel == null)
                throw new Exception("Failed to deserialize calculationModelJson parameter into CalculationModel");

            var netPresentValue = _calculationService.CalculateNetPresentValue(calculationModel);

            return Ok(new { NetPresentValue = netPresentValue, PresentValueOfCashFlows = netPresentValue - Convert.ToDouble(calculationModel.InitialCost) });
        }
    }
}