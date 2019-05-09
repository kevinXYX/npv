using NPV.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NPV.Services.CalculationService
{
    public interface ICalculationService
    {
        double CalculateNetPresentValue(CalculationModel calculationModel);
    }
}
