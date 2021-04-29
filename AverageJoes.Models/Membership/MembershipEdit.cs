using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AverageJoes.Data.Memberships;

namespace AverageJoes.Models.Membership
{
    public class MembershipEdit
    {
        public int ID { get; set; }
        public MembershipType MembershipTypes { get; set; }
        public string Notes { get; set; }
    }
}
