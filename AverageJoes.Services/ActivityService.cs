using AverageJoes.Data;
using AverageJoes.Models.Activity;
using BlueBadgeFinal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageJoes.Services
{
    public class ActivityService
    {
        private readonly Guid _ownerID;
        public ActivityService(Guid ownerID)
        {
            _ownerID = ownerID;
        }
        public bool CreateActivity(ActivityCreate model)
        {
            var entity =
                new Activity()
                {
                    OwnerID = _ownerID,
                    Name = model.Name,
                    Descripton = model.Descripton,
                    UserID = model.UserID,
                    User = model.User
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Activities.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ActivityListItem> GetActivities()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Activities
                        .Where(e => e.OwnerID == _ownerID)
                        .Select(
                            e =>
                                new ActivityListItem
                                {
                                    ID = e.ID,
                                    Name = e.Name,
                                    Descripton = e.Descripton,
                                    IsSignedUp = e.IsSignedUp,
                                }
                        );
                return query.ToArray();
            }
        }
        public ActivityDetail GetActivitiesByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Activities
                        .Single(e => e.ID == id && e.OwnerID == _ownerID);
                return
                    new ActivityDetail
                    {
                        ID = entity.ID,
                        Name = entity.Name,
                        Descripton = entity.Descripton,
                        UserID = entity.UserID,
                        User = entity.User
                    };
            }
        }
        public bool UpdateActivities(ActivityEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Activities
                        .Single(e => e.ID == model.ID && e.OwnerID == _ownerID);
                entity.ID = model.ID;
                entity.Name = model.Name;
                entity.Descripton = model.Descripton;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteActivity(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Activities
                        .Single(e => e.ID == id && e.OwnerID == _ownerID);
                ctx.Activities.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
