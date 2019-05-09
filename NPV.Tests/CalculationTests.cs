using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPV.DatabaseCore;
using NPV.Models.ViewModels;
using NPV.Services.CalculationService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NPV.Tests
{
    [TestClass]
    public class CalculationTests
    {
        private readonly ICalculationService calculationService;

        public CalculationTests()
        {
            var servicesCollection = new ServiceCollection();

            servicesCollection.AddTransient<ICalculationService, CalculationService>();

            var serviceProvider = servicesCollection.BuildServiceProvider();

            calculationService = serviceProvider.GetService<ICalculationService>();
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
        public void CalculateNPresentValue()
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
                Value = 10,
            });
            cashFlows.Add(new CashFlow
            {
                Year = 2,
                Value = 10,
            });
            cashFlows.Add(new CashFlow
            {
                Year = 3,
                Value = 10,
            });
            cashFlows.Add(new CashFlow
            {
                Year = 4,
                Value = 10,
            });
            cashFlows.Add(new CashFlow
            {
                Year = 5,
                Value = 10,
            });
            cashFlows.Add(new CashFlow
            {
                Year = 6,
                Value = 10,
            });
            cashFlows.Add(new CashFlow
            {
                Year = 7,
                Value = 10,
            });
            cashFlows.Add(new CashFlow
            {
                Year = 8,
                Value = 10,
            });
            cashFlows.Add(new CashFlow
            {
                Year = 9,
                Value = 10,
            });
            cashFlows.Add(new CashFlow
            {
                Year = 10,
                Value = 10,
            });

            calculationModel.CashFlows = cashFlows;

            //Act
            var presentValueOfCashFlows = calculationService.CalculateNetPresentValue(calculationModel) + Convert.ToDouble(calculationModel.InitialCost);

            //Assert
            Assert.IsTrue(presentValueOfCashFlows > 0);
        }
    }
}
