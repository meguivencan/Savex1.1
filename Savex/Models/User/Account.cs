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
        public string Username { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public bool? IsActive { get; private set; }
        public bool? IsLockedOut { get; private set; }


        public List<AccountRole> AccountRoles { get; set; }

    }
}
