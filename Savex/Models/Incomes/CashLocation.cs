using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Savex.Models.Incomes
{
    public class CashLocation
    {
        public int Id { get; set; }
        public string CashLocationName { get; set; }


        public List<Income> Incomes { get; set; }
    }
}
