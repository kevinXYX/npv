using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPV.Models.ViewModels
{
    public class CalculationModel
    {
        public int LifeOfProject { get; set; }
        public decimal InitialCost { get; set; }
        public double LowerBoundDiscountRate { get; set; }
        public double UpperBoundDiscountRate { get; set; }
        public double DiscountRateIncrement { get; set; }
        public List<CashFlow> CashFlows { get; set; }
    }
    
    public class CashFlow
    {
        public int Year { get; set; }
        public int Value { get; set; }
    }
}
