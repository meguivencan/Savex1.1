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
        public int AccountrId { get; set; }
        public Account Account { get; set; }
        [Required]
        public string Date { get; set; }
        public string Comment { get; set; }
    }
}
