using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Savex.Models.User
{
    public class AccountRole
    {
        public int Id { get; set; }
        public string AccountRoleName { get; set; }

        public List<Account> Accounts { get; set; }
    }
}
