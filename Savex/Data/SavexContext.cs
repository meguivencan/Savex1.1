using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Savex.Models.User;
using Savex.Models.Expenses;

    public class SavexContext : DbContext
    {
        public SavexContext (DbContextOptions<SavexContext> options)
            : base(options)
        {
        }

        public DbSet<Account> Account { get; set; }

        public DbSet<AccountRole> AccountRole { get; set; }

        public DbSet<Role> Role { get; set; }

        public DbSet<Savex.Models.Expenses.Expense> Expense { get; set; }

        public DbSet<Savex.Models.Expenses.ExpenseType> ExpenseType { get; set; }
    }
