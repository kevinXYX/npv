using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NPV.Models.Entities
{
    public class CashFlows
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Year { get; set; }
        public int Value { get; set; }
        public int PreviousResultId { get; set; }
    }
}
