using Microsoft.EntityFrameworkCore;
using NPV.Models.Entities;
using System;

namespace NPV.DatabaseCore
{
    public class NPVContext : DbContext
    {
        public NPVContext(DbContextOptions options) 
            : base(options) {
        }

        public virtual DbSet<PreviousResult> PreviousResults { get; set; }
    }
}
