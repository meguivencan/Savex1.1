using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Savex.Models.Incomes
{
    public class IncomeType
    {
        public int Id { get; set; }
        public string IncomeTypeName { get; set; }


        public List<Income> Income { get; set; }
    }
}
