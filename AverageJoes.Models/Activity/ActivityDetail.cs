using AverageJoes.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageJoes.Models.Activity
{
    public class ActivityDetail
    {
    
        
        public int ID { get; set; }
       
        public string Name { get; set; }
        
        public string Descripton { get; set; }

        public int UserID { get; set; }
        public virtual Users User { get; set; }
    }
}

