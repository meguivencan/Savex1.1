using Savex.Models.Expenses;
using Savex.Models.Incomes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Savex.Models.DashBoards
{
    public class DashBoard
    {
        public IEnumerable<Expense> TotalExpenses { get; set; }
        public IEnumerable<Income> TotalIncomes { get; set; }

        public double Difference { get; set; }
    }
}
