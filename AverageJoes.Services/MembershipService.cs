using AverageJoes.Data;
using AverageJoes.Models.Membership;
using BlueBadgeFinal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageJoes.Services
{
    public class MembershipService
    {
        private readonly Guid _userId;

        public MembershipService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMembership(MembershipCreate model)
        {

            var entity =
                new Memberships()
                {
                    OwnerID = _userId,
                    MembershipTypes = model.MembershipTypes,
                    Notes = model.Notes,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Memberships.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<MembershipListItem> GetMemberships()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Memberships
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new MembershipListItem
                                {

                                    ID = e.ID,
                                    membership = e.MembershipTypes,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }
        public MembershipDetail GetMembershipById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Memberships
                        .Single(e => e.ID == id && e.OwnerID == _userId);
                return
                    new MembershipDetail
                    {
                        ID = entity.ID,
                        MembershipTypes = entity.MembershipTypes,
                        Notes = entity.Notes,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public bool UpdateMembership(MembershipEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Memberships
                        .Single(e => e.ID == model.ID && e.OwnerID == _userId);

                entity.MembershipTypes = model.MembershipTypes;
                entity.Notes = model.Notes;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteMembership(int membershipId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Memberships
                        .Single(e => e.ID == membershipId && e.OwnerID == _userId);

                ctx.Memberships.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }

}
}
