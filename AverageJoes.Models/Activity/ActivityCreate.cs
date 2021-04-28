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
        
        public int ID { get; set; }
        public string Name { get; set; }
        
        public string Description { get; set; }
    }
}

