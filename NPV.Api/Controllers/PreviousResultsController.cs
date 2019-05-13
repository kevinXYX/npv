using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NPV.DatabaseCore;
using NPV.Models.Entities;
using NPV.Models.ViewModels;
using NPV.Services.CalculationService;

namespace NPV.Api.Controllers
{
    [Route("api/previous-results")]
    [ApiController]
    public class PreviousResultsController : ControllerBase
    {
        private readonly INPVContext _npvContext;
        private readonly ICalculationService _calculationService;

        public PreviousResultsController(INPVContext npvContext, ICalculationService calculationService)
        {
            _npvContext = npvContext;
            _calculationService = calculationService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _npvContext.PreviousResults.OrderByDescending(x => x.Id).ToListAsync());
        }

        [HttpPost("save")]
        public async Task<IActionResult> SavePreviousResults(CalculationModel calculationModel)
        {
            if (calculationModel == null)
                throw new Exception("The parameter calculationModel is null");

            var netPresentValue = Convert.ToDecimal(_calculationService.CalculateNetPresentValue(calculationModel));

            var presentValueOfCashFlows = netPresentValue + calculationModel.InitialCost;

            var previousResult = new PreviousResult();

            previousResult.LifeOfProject = calculationModel.LifeOfProject;
            previousResult.InitialCost = calculationModel.InitialCost;
            previousResult.LowerBoundDiscountRate = calculationModel.LowerBoundDiscountRate;
            previousResult.UpperBoundDiscountRate = calculationModel.UpperBoundDiscountRate;
            previousResult.DiscountRateIncrement = calculationModel.DiscountRateIncrement;
            previousResult.NetPresentValue = netPresentValue;
            previousResult.PresentValueOfCashFlows = presentValueOfCashFlows;

            calculationModel?.CashFlows?.ForEach(x =>
            {
                previousResult.CashFlows.Add(new CashFlows {
                    Year = x.Year,
                    Value = x.Value
                });
            });

            previousResult.CreatedDate = DateTime.UtcNow;

            _npvContext.AddPreviousResults(previousResult);

            var saveChangesResult = await _npvContext.SaveEntityChangesAsync();

            if (saveChangesResult > 0)
                return Ok(new { Success = true });

            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }
}