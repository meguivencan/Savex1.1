using Savex.Models.Expenses;
using Savex.Models.Incomes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Savex.Models.User
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]

        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string ConfirmPassword { get; set; }
        [Required]

        public string SecurityQuestion { get; set; }
        [Required]

        public string SecurityQuestionAnswer { get; set; }
        public bool? IsActive { get; private set; }
        public bool? IsLockedOut { get; private set; }
        public int? AccountRoleId { get; set; }
        public AccountRole AccountRole { get; set; }

        public List<Expense> Expenses { get; set; }
        public List<Income> Incomes { get; set; }

    }
}
