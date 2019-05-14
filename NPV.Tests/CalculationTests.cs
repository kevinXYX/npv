using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPV.Models.ViewModels;
using NPV.Services.CalculationService;
using System;
using System.Collections.Generic;

namespace NPV.Tests
{
    [TestClass]
    public class CalculationTests
    {
        private readonly ICalculationService calculationService;

        public CalculationTests()
        {
            var serviceTestsLocator = new ServiceTestsLocator();

            calculationService = serviceTestsLocator.GetService<ICalculationService>(typeof(ICalculationService), typeof(CalculationService));
        }

        [TestMethod]
        public void CalculateNetPresentValue()
        {
            //Arrange
            var calculationModel = new CalculationModel();

            calculationModel.LifeOfProject = 5;
            calculationModel.DiscountRateIncrement = 0.01;
            calculationModel.LowerBoundDiscountRate = 3.65;
            calculationModel.UpperBoundDiscountRate = 3.70;
            calculationModel.InitialCost = -100000;

            var cashFlows = new List<CashFlow>();

            cashFlows.Add(new CashFlow
            {
                Year = 1,
                Value = 30000,
            });
            cashFlows.Add(new CashFlow
            {
                Year = 2,
                Value = 30000,
            });
            cashFlows.Add(new CashFlow
            {
                Year = 3,
                Value = 30000,
            });
            cashFlows.Add(new CashFlow
            {
                Year = 4,
                Value = 30000,
            });
            cashFlows.Add(new CashFlow
            {
                Year = 5,
                Value = 30000,
            });

            calculationModel.CashFlows = cashFlows;

            //Act
            var netPresentValue = calculationService.CalculateNetPresentValue(calculationModel);

            //Assert
            Assert.IsTrue(netPresentValue > 0);
        }

        [TestMethod]
        public void CalculatePresentValueOfCashFlows()
        {
            //Arrange
            var calculationModel = new CalculationModel();

            calculationModel.LifeOfProject = 5;
            calculationModel.DiscountRateIncrement = 0.01;
            calculationModel.LowerBoundDiscountRate = 3.65;
            calculationModel.UpperBoundDiscountRate = 3.70;
            calculationModel.InitialCost = -100000;

            var cashFlows = new List<CashFlow>();

            cashFlows.Add(new CashFlow
            {
                Year = 1,
                Value = 5000,
            });
            cashFlows.Add(new CashFlow
            {
                Year = 2,
                Value = 5000,
            });
            cashFlows.Add(new CashFlow
            {
                Year = 3,
                Value = 5000,
            });
            cashFlows.Add(new CashFlow
            {
                Year = 4,
                Value = 5000,
            });
            cashFlows.Add(new CashFlow
            {
                Year = 5,
                Value = 5000,
            });

            calculationModel.CashFlows = cashFlows;

            //Act
            var presentValueOfCashFlows = calculationService.CalculateNetPresentValue(calculationModel) + Convert.ToDouble(Math.Abs(calculationModel.InitialCost));

            //Assert
            Assert.IsTrue(presentValueOfCashFlows > 0);
        }
    }
}
