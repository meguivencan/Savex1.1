﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Savex.Models.Expenses
{
    public class ExpenseType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ExpenseTypeName { get; set; }
        public string Comment { get; set; }

        public List<Expense> Expenses { get; set; }
    }
}
