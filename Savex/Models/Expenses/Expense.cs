using Microsoft.Extensions.Diagnostics.HealthChecks;
using Savex.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Savex.Models.Expenses
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        public int ExpenseTypeId { get; set; }
        public ExpenseType ExpenseType { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        [Required]
        public string Date { get; set; }
        public string Comment { get; set; }

        public string SoonToBuy { get; set; } //yes or no
        public string Status { get; set; } //Active or Inactive
        public string PriorityLevel { get; set; } //1 - 5. 1 is the highest
        public string Title { get; set; }



    }
}
