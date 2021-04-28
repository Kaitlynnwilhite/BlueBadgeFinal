using AverageJoes.Services;
using Microsoft.AspNet.Identity; 
using AverageJoes.Models.Enrollment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlueBadgeFinal.Controllers
{
    [Authorize]
    public class EnrollmentController : ApiController
    {
        private EnrollmentService CreateEnrollmentService()
        {
            var enrollmentService = new EnrollmentService();
            return enrollmentService;
        }
        public IHttpActionResult Post(EnrollmentCreate enrollments)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateEnrollmentService();
            if (!service.CreateEnrollment(enrollments))
                return InternalServerError();
            return Ok();
        }
    }
}
