using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageJoes.Data
{
    public class Users
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public Guid OwnerID { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public long PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public long CreditCard { get; set; }
        //[ForeignKey(nameof(Membership))]
        //public int MembershipID { get; set; }
        //public virtual Memberships Membership { get; set; }
    }
}
