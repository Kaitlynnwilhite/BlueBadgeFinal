using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageJoes.Models.Activity
{
    public class ActivityListItem
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Descripton { get; set; }
        [Required]
        public bool IsSignedUp { get; set; }
        [Required]
        public Guid OwnerID { get; set; }

       
    }
}

