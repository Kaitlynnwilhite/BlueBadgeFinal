using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageJoes.Data
{
    public class Membership
    {
        public enum MembershipType
        {
            individual, family, seniorCitizen, veteran, student
        }
        [Key]
        public int ID { get; set; }
        [Required]

        public Guid OwnerID { get; set; }
        [Required]

        public MembershipType membership { get; set; }

        [Required]

        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

        //I am making changes okay github

    }
}
