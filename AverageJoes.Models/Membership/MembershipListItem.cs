using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AverageJoes.Data.Memberships;

namespace AverageJoes.Models.Membership
{
    public class MembershipListItem
    {
        public int ID { get; set; }
        public MembershipType membership { get; set; }

        public string Notes { get;set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
