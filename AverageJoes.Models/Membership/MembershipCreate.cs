using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AverageJoes.Data.Memberships;

namespace AverageJoes.Models.Membership
{

    public class MembershipCreate
    {
        [Required]
        public MembershipType MembershipTypes { get; set; }

        [MaxLength(8000)]
        public string Notes { get; set; }
    }
}

