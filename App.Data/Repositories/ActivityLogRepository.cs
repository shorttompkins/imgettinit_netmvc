using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data;
using System.Linq;
using App.Data.Contracts;
using App.Model;

namespace App.Data
{
    public class ActivityLogRepository: EFRepository<ActivityLog>, IActivityLogRepository
    {
        public ActivityLogRepository(DbContext context) : base(context) { }

        public ICollection<ActivityLog> GetActivityByUser(int userid, bool hidefriends)
        {
            //joins against friends and returns the full list
            //return (from f in _dbC.Following join a in _dbC.ActivityLogs on f.FollowedUser.UserId equals a.UserId where f.User.UserId.Equals(userid) select a).ToList();
            if (hidefriends)
                return DbContext.Set<ActivityLog>().Where(i => i.UserId == userid).ToList();
            else
            {
                var mylog = DbContext.Set<ActivityLog>().Where(i => i.UserId == userid).ToList();
                var myfriends = DbContext.Set<Follow>().Where(f => f.User.UserId == userid).ToList();

                //var outlist = new List<ActivityLog>();

                foreach (var friend in myfriends)
                {
                    var flist = DbContext.Set<ActivityLog>().Where(i => i.UserId == friend.FollowedUser.UserId).ToList();
                    foreach (var list in flist)
                    {
                        //if (mylog.Count(g => g.GameId == list.GameId && g.ConsoleId == list.ConsoleId) > 0)
                        mylog.Add(list);
                    }
                }

                return mylog;
            }
        }
    }
}
