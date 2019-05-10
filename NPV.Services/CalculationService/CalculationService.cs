using System;
using System.Collections.Generic;
using System.Text;
using NPV.Models.ViewModels;

namespace NPV.Services.CalculationService
{
    public class CalculationService : ICalculationService
    {
        public double CalculateNetPresentValue(CalculationModel calculationModel)
        {
            if (calculationModel.CashFlows == null || calculationModel.CashFlows.Count == 0)
                return 0;

            double netPresentValue = 0;

            double discountRateIncrement = 0;

            foreach (var cashFlow in calculationModel.CashFlows)
            {
                var discountRate = cashFlow.Year == 1 ? calculationModel.LowerBoundDiscountRate : calculationModel.LowerBoundDiscountRate + discountRateIncrement;

                netPresentValue += cashFlow.Value / Math.Pow(1 + discountRate / 100d, cashFlow.Year);

                discountRateIncrement += calculationModel.DiscountRateIncrement;

                if (calculationModel.UpperBoundDiscountRate == discountRateIncrement)
                    break;
            }

            var netPresentValueResult = Math.Round(netPresentValue - Convert.ToDouble(calculationModel.InitialCost), 2);

            return netPresentValueResult;
        }
    }
}
