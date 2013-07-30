using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data;
using System.Linq;
using App.Data.Contracts;
using App.Model;

namespace App.Data
{
    public class FollowRepository : EFRepository<Follow>, IFollowRepository
    {
        public FollowRepository(DbContext context) : base(context) { }

        public bool AddFollowUser(int userid, int followid)
        {
            var entity = new Follow { User = DbContext.Set<User>().FirstOrDefault(u => u.UserId == userid), FollowedTimestamp = DateTime.Now, FollowedUser = DbContext.Set<User>().FirstOrDefault(u => u.UserId == followid) };
            this.Add(entity);            
            return true;
        }
        public bool RemoveFollowUser(int userid, int followid)
        {
            var entity = new Follow { User = DbContext.Set<User>().FirstOrDefault(u => u.UserId == userid), FollowedTimestamp = DateTime.Now, FollowedUser = DbContext.Set<User>().FirstOrDefault(u => u.UserId == followid) };
            this.Delete(entity);
            return true;
        }
        public bool CheckIfFollowingUser(int userid, int followid)
        {
            return DbContext.Set<Follow>().Count(f => f.User.UserId == userid && f.FollowedUser.UserId == followid) > 0 ? true : false;
        }
        
    }
}
