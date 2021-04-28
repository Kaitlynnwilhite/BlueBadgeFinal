using AverageJoes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AverageJoes.Data.Memberships;

namespace AverageJoes.Models.User
{
    public class UserListItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int MembershipID { get; set; }
        public MembershipType MembershipTypes { get; set; }
    }
}
