﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NPV.Models.Entities
{
    public class PreviousResult
    {
        public int Id { get; set; }
        public int LifeOfProject { get; set; }
        public decimal InitialCost { get; set; }
        public double LowerBoundDiscountRate { get; set; }
        public double UpperBoundDiscountRate { get; set; }
        public double DiscountRateIncrement { get; set; }
        public decimal NetPresentValue { get; set; }
        public decimal PresentValueOfCashFlows { get; set; }
    }
}
