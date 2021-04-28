using AverageJoes.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageJoes.Models.Enrollment
{
    public class EnrollmentCreate
    {
        
        
        public int UserID { get; set; }
        
     
        public int ActivityID { get; set; }
        
    }
}
