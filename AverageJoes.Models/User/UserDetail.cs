using AverageJoes.Data;
using AverageJoes.Models.Activity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageJoes.Models.User
{
    public class UserDetail
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
        public long CreditCard { get; set; }
        public virtual Memberships Membership { get; set; }
        public virtual ICollection<ActivityListItem> Activity { get; set; } = new List<ActivityListItem>();
        
    }
}
