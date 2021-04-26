using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageJoes.Data
{
    public class Activity
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Descripton { get; set; }
        [Required]
        public Guid OwnerID { get; set; }
        
        [ForeignKey(nameof(User))]
        public int? UserID { get; set; }
        public virtual Users User { get; set; }
    }
}
