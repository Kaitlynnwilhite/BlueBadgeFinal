using AverageJoes.Models.Activity;
using AverageJoes.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlueBadgeFinal.Controllers
{
    [Authorize]
    public class ActivityController : ApiController
    {
        private ActivityService CreateActivityService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var activityService = new ActivityService(userID);
                return activityService;
        }
        public IHttpActionResult Get()
        {
            ActivityService activityService = CreateActivityService();
            var activities = activityService.GetActivities();
            return Ok(activities);
        }
        public IHttpActionResult Post(ActivityCreate activity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateActivityService();
            if (!service.CreateActivity(activity))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Get(int id)
        {
            ActivityService activityService = CreateActivityService();
            var activity = activityService.GetActivitiesByID(id);
                return Ok(activity);
        }
        public IHttpActionResult Put(ActivityEdit activity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateActivityService();
            if (!service.UpdateActivities(activity))
                return InternalServerError();
            return Ok();

        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateActivityService();
            if (!service.DeleteActivity(id))
                return InternalServerError();
            return Ok();
        }
    }
}
