using AverageJoes.Data;
using AverageJoes.Models.User;
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
        
        public string Description { get; set; }
        public virtual ICollection<UserListItem> Enrollments { get; set; } = new List<UserListItem>();
    }
}

