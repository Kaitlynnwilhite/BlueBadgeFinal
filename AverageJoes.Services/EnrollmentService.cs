using AverageJoes.Data;
using AverageJoes.Models.Enrollment;
using BlueBadgeFinal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageJoes.Services
{
    public class EnrollmentService
    {
        public bool CreateEnrollment(EnrollmentCreate model)
        {
            var entity =
                new Enrollment()
                {
                    UserID = model.UserID,                   
                    ActivityID = model.ActivityID,                    
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Enrollments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
