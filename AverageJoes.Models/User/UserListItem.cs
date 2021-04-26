using AverageJoes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageJoes.Models.User
{
    public class UserListItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
        public long CreditCard { get; set; }
        public virtual Memberships Membership { get; set; }
        public virtual Data.Activity Activity { get; set; }
    }
}
