using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Savex.Models.Expenses
{
    public class MonthlyBudget
    {
        public int Id { get; set; }
        public double Budget { get; set; }


        public List<Expense> Expenses { get; set; }
    }
}
