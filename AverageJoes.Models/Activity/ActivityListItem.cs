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
        
        
        public int ID { get; set; }
        
        public string Name { get; set; }
       
        public string Descripton { get; set; }
        
        public bool IsSignedUp { get; set; }
      
    }
}

