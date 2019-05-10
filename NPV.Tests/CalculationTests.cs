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
            calculationModel.DiscountRateIncrement = 0.25;
            calculationModel.LowerBoundDiscountRate = 1;
            calculationModel.UpperBoundDiscountRate = 5;
            calculationModel.InitialCost = 10000;

            var cashFlows = new List<CashFlow>();

            cashFlows.Add(new CashFlow
            {
                Year = 1,
                Value = 1245,
            });
            cashFlows.Add(new CashFlow
            {
                Year = 2,
                Value = 2846,
            });
            cashFlows.Add(new CashFlow
            {
                Year = 3,
                Value = 4256,
            });
            cashFlows.Add(new CashFlow
            {
                Year = 4,
                Value = 2123,
            });
            cashFlows.Add(new CashFlow
            {
                Year = 5,
                Value = 3893,
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

            calculationModel.LifeOfProject = 10;
            calculationModel.DiscountRateIncrement = 0.25;
            calculationModel.LowerBoundDiscountRate = 1;
            calculationModel.UpperBoundDiscountRate = 5;
            calculationModel.InitialCost = 10000;

            var cashFlows = new List<CashFlow>();

            cashFlows.Add(new CashFlow
            {
                Year = 1,
                Value = 4543,
            });
            cashFlows.Add(new CashFlow
            {
                Year = 2,
                Value = 2342,
            });
            cashFlows.Add(new CashFlow
            {
                Year = 3,
                Value = 1234,
            });
            cashFlows.Add(new CashFlow
            {
                Year = 4,
                Value = 3443,
            });
            cashFlows.Add(new CashFlow
            {
                Year = 5,
                Value = 2312,
            });
            cashFlows.Add(new CashFlow
            {
                Year = 6,
                Value = 1234,
            });
            cashFlows.Add(new CashFlow
            {
                Year = 7,
                Value = 4322,
            });
            cashFlows.Add(new CashFlow
            {
                Year = 8,
                Value = 2344,
            });
            cashFlows.Add(new CashFlow
            {
                Year = 9,
                Value = 4232,
            });
            cashFlows.Add(new CashFlow
            {
                Year = 10,
                Value = 2323,
            });

            calculationModel.CashFlows = cashFlows;

            //Act
            var presentValueOfCashFlows = calculationService.CalculateNetPresentValue(calculationModel) + Convert.ToDouble(calculationModel.InitialCost);

            //Assert
            Assert.IsTrue(presentValueOfCashFlows > 0);
        }
    }
}
