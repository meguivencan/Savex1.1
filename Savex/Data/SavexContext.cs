using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Savex.Models.User;
using Savex.Models.Expenses;
using Savex.Models.Incomes;

public class SavexContext : DbContext
    {
        public SavexContext (DbContextOptions<SavexContext> options)
            : base(options)
        {
        }

        public DbSet<Account> Account { get; set; }

        public DbSet<AccountRole> AccountRole { get; set; }

        public DbSet<Expense> Expense { get; set; }

        public DbSet<ExpenseType> ExpenseType { get; set; }

        public DbSet<CashLocation> CashLocation { get; set; }

        public DbSet<IncomeType> IncomeType { get; set; }

        public DbSet<Income> Income { get; set; }
    }
