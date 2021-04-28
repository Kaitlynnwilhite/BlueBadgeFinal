using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageJoes.Data
{
    public class Memberships
    {
        public enum MembershipType
        {
           Annual =1, SemiAnnual, Quarterly, Monthly, Weekly 
        }
        [Key]
        public int ID { get; set; }
        [Required]

        public Guid OwnerID { get; set; }
        [Required]

        public MembershipType MembershipTypes { get; set; }

        [Required]

        public string Notes { get; set; }

        [Required]

        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }


    }
}
