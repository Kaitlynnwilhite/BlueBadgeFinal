using AverageJoes.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AverageJoes.Data.Memberships;

namespace AverageJoes.Models.User
{
    public class UserCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public long PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public long CreditCard { get; set; }
        [ForeignKey(nameof(Memberships))]
        public int MembershipID { get; set; }
        public MembershipType MembershipTypes { get; set; }
    }
}
