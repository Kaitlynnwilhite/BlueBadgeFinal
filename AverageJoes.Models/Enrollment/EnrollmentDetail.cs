using AverageJoes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageJoes.Models.Enrollment
{
    public class EnrollmentDetail
    {
        public int ID { get; set; }
        public virtual Users Users { get; set; }
        public virtual Data.Activity Activities { get; set; }
    }
}
