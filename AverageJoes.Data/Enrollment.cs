using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageJoes.Data
{
    public class Enrollment
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey(nameof(Users))]
        public int UserID { get; set; }
        public virtual Users Users { get; set; } 
        [ForeignKey(nameof(Activities))]
        public int ActivityID { get; set; }
        public virtual Activity Activities { get; set; } 
    }
}
