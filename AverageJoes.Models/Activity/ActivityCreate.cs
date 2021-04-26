using AverageJoes.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageJoes.Models.Activity
{
    public class ActivityCreate
    {
        
        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Descripton { get; set; }
        [ForeignKey(nameof(User))]
        public int? UserID { get; set; }
        public virtual Users User { get; set; }
    }
}

