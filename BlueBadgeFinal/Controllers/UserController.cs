using AverageJoes.Models.User;
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
    public class UserController : ApiController
    {
        private UserService CreateUserService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var userService = new UserService(userID);
            return userService;
        }
        public IHttpActionResult Get()
        {
            UserService userService = CreateUserService();
            var users = userService.GetUsers();
            return Ok(users);
        }
        public IHttpActionResult Get(int id)
        {
            UserService userService = CreateUserService();
            var users = userService.GetUserByID(id);
            return Ok(users);
        }
        public IHttpActionResult Post(UserCreate users)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateUserService();

            if (!service.CreateUser(users))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateUserService();

            if (!service.DeleteUsers(id))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Put(UserEdit users)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateUserService();

            if (!service.UpdateUsers(users))
                return InternalServerError();

            return Ok();
        }
    }
}