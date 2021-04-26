using AverageJoes.Data;
using AverageJoes.Models.User;
using BlueBadgeFinal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageJoes.Services
{
    public class UserService
    {
        private readonly Guid _ownerID;

        public UserService(Guid ownerID)
        {
            _ownerID = ownerID;
        }
        public bool CreateUser(UserCreate model)
        {
            var entity =
                new Users()
                {
                    OwnerID = _ownerID,
                    Name = model.Name,
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    CreditCard = model.CreditCard,
                    MembershipID = model.MembershipID,
                   
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.UsersInfo.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }
        public UserDetail GetUserByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .UsersInfo
                    .Single(e => e.ID == id && e.OwnerID == _ownerID);
                return
                    new UserDetail
                    {
                        Name = entity.Name,
                        Address = entity.Address,
                        PhoneNumber = entity.PhoneNumber,
                        Email = entity.Email,
                        CreditCard = entity.CreditCard,
                        Membership = entity.Membership,
                   //     Activity = entity.Activities
                    };
            }
        }
        public bool UpdateUsers(UserEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .UsersInfo
                    .Single(e => e.ID == model.ID && e.OwnerID == _ownerID);
                entity.Name = model.Name;
                entity.Address = model.Address;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Email = model.Email;
                entity.CreditCard = model.CreditCard;
                //entity.MembershipID = model.MembershipID;
                //entity.Membership = model.Membership;

                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<UserListItem> GetUsers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .UsersInfo
                    .Where(e => e.OwnerID == _ownerID)
                    .Select(
                        e =>
                        new UserListItem
                        {
                            ID = e.ID,
                            Name = e.Name,
                            Address = e.Address,
                            PhoneNumber = e.PhoneNumber,
                            Email = e.Email,
                            CreditCard = e.CreditCard,
                            Membership = e.Membership,
                         //   Activity = e.Activities
                        });
                return query.ToArray();
            }
        }
        public bool DeleteUsers(int userID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.UsersInfo
                    .Single(e => e.ID == userID && e.OwnerID == _ownerID);
                ctx.UsersInfo.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
