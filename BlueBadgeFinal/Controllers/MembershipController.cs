using AverageJoes.Models.Membership;
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
    public class MembershipController : ApiController
    {
        public IHttpActionResult Get(int id)
        {
            MembershipService membershipService = CreateMembershipService();
            var memberships = membershipService.GetMembershipById(id);
            return Ok(memberships);
        }
        public IHttpActionResult Get()
        {
            MembershipService membershipService = CreateMembershipService();
            var memberships = membershipService.GetMemberships();
            return Ok(memberships);
        }
        public IHttpActionResult Post(MembershipCreate membership)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMembershipService();

            if (!service.CreateMembership(membership))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(MembershipEdit membership)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMembershipService();

            if (!service.UpdateMembership(membership))
                return InternalServerError();

            return Ok();
        }


        private MembershipService CreateMembershipService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var membershipService = new MembershipService(userId);
            return membershipService;

        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateMembershipService();

            if (!service.DeleteMembership(id))
                return InternalServerError();

            return Ok();
        }

    }
}
