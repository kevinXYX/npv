using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
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
        private readonly INPVContext _npvContext;
        public CalculationController(INPVContext npvContext, ICalculationService calculationService)
        {
            _npvContext = npvContext;
            _calculationService = calculationService;
        }

        [HttpPost("calculate-npv")]
        public IActionResult CalculatePresentAndNetPresentValue([FromBody]CalculationModel calculationModel)
        {
            if (calculationModel == null)
                throw new Exception("The parameter calculationModel is null");

            var netPresentValue = _calculationService.CalculateNetPresentValue(calculationModel);

           return Ok(new { NetPresentValue = netPresentValue, PresentValueOfCashFlows = (netPresentValue + Convert.ToDouble(Math.Abs(calculationModel.InitialCost))) });
        }
    }
}