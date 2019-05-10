using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NPV.Models.Entities
{
    public class PreviousResult
    {
        public PreviousResult()
        {
            CashFlows = new HashSet<CashFlows>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int LifeOfProject { get; set; }
        public decimal InitialCost { get; set; }
        public double LowerBoundDiscountRate { get; set; }
        public double UpperBoundDiscountRate { get; set; }
        public double DiscountRateIncrement { get; set; }
        public decimal NetPresentValue { get; set; }
        public decimal PresentValueOfCashFlows { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<CashFlows> CashFlows { get; set; }
    }
}
