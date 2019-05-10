using NPV.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPV.DatabaseCore
{
    //Minimal exposure of the DbContext object
    public interface INPVContext
    {
        Task<int> SaveEntityChangesAsync();
        IQueryable<PreviousResult> PreviousResults { get; }
        void AddPreviousResults(PreviousResult previousResult);
    }
}
