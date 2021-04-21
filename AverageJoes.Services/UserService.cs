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
                    Membership = model.Membership
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
                        MembershipID = entity.MembershipID,
                        Membership = entity.Membership
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
                    .Single(e => e.Name == model.Name && e.OwnerID == _ownerID);
                entity.Address = model.Address;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Email = entity.Email;
                entity.CreditCard = entity.CreditCard;
                entity.MembershipID = entity.MembershipID;
                entity.Membership = entity.Membership;

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
                            Name = e.Name,
                            Address = e.Address,
                            PhoneNumber = e.PhoneNumber,
                            Email = e.Email,
                            CreditCard = e.CreditCard
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
