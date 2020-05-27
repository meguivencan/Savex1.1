using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Savex.Models.Incomes
{
    public class Income
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Amount { get; set; }
        public int IncomeTypeId { get; set; }
        public IncomeType IncomeType { get; set; }
        public string Date { get; set; }
        public string Comment { get; set; }
        public string Status { get; set; }
        public int CashLocationId { get; set; }
        public CashLocation CashLocation { get; set; }

    }
}
