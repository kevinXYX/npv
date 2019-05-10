using Microsoft.EntityFrameworkCore;
using NPV.Models.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NPV.DatabaseCore
{
    public class NPVContext : DbContext, INPVContext
    {
        public NPVContext(DbContextOptions options) 
            : base(options) {
        }

        IQueryable<PreviousResult> INPVContext.PreviousResults => PreviousResults.Include(x => x.CashFlows);

        public Task<int> SaveEntityChangesAsync()
        {
            return SaveChangesAsync();
        }

        public void AddPreviousResults(PreviousResult previousResult)
        {
            PreviousResults.Add(previousResult);
        }

        public virtual DbSet<PreviousResult> PreviousResults { get; set; }
        public virtual DbSet<CashFlows> CashFlows { get; set; }
    }
}
