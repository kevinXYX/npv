using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPV.DatabaseCore;
using NPV.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NPV.Tests
{
    [TestClass]
    public class PreviousResultsTests
    {
        private readonly INPVContext _npvContext;
        public PreviousResultsTests()
        {
            var serviceTestsLocator = new ServiceTestsLocator();

            var sqlLiteDatabasePath = Path.GetFullPath(@"..\..\..\..\NPV.Api\npv.db"); 

            serviceTestsLocator.serviceCollection.AddDbContext<NPVContext>(options =>
                options.UseSqlite($"Data Source={sqlLiteDatabasePath}"));

            _npvContext = serviceTestsLocator.GetService<INPVContext>(typeof(INPVContext), typeof(NPVContext));
        }

        [TestMethod]
        public void GetPreviousResults()
        {
            var previousResults = _npvContext.PreviousResults
                .Include(x => x.CashFlows)
                .ToList();

            Assert.IsNotNull(previousResults);
        }

        [TestMethod]
        public async Task SavePreviousResultsAsync()
        {
            //Arrange
            var previousResultEntity = new PreviousResult();

            previousResultEntity.LifeOfProject = 5;
            previousResultEntity.InitialCost = 300000;
            previousResultEntity.LowerBoundDiscountRate = 1;
            previousResultEntity.UpperBoundDiscountRate = 15;
            previousResultEntity.DiscountRateIncrement = 0.65;
            previousResultEntity.NetPresentValue = 234553;
            previousResultEntity.PresentValueOfCashFlows = 17345;
            previousResultEntity.CreatedDate = DateTime.UtcNow;

            previousResultEntity.CashFlows.Add(new CashFlows {
                Year = 1,
                Value = 12345,
            });
            previousResultEntity.CashFlows.Add(new CashFlows
            {
                Year = 2,
                Value = 24223,
            });
            previousResultEntity.CashFlows.Add(new CashFlows
            {
                Year = 3,
                Value = 22345,
            });
            previousResultEntity.CashFlows.Add(new CashFlows
            {
                Year = 4,
                Value = 52344,
            });
            previousResultEntity.CashFlows.Add(new CashFlows
            {
                Year = 5,
                Value = 12623,
            });
            //Act
            _npvContext.AddPreviousResults(previousResultEntity);

            var saveChangesResult = await _npvContext.SaveEntityChangesAsync();

            //Assert
            Assert.IsTrue(saveChangesResult > 0);
        }
    }
}
