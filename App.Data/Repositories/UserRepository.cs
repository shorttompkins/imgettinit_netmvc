using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data;
using System.Linq;
using App.Data.Contracts;
using App.Model;

namespace App.Data
{
    public class UserRepository : EFRepository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context) {  }

        public bool ActivateUser(int userid)
        {
            var user = this.GetById(userid);
            user.IsActive = true;

            return MarkAsModified(user);            
        }
        public bool UpdateLastLoginTimestamp(int userid)
        {
            var user = this.GetById(userid);
            user.LastLoginTimestamp = DateTime.Now;

            return MarkAsModified(user);
        }

        public User GetUser(int userid)
        {
            return DbSet.FirstOrDefault(u => u.UserId == userid);
        }
        public User GetUser(string username)
        {
            return DbSet.FirstOrDefault(u => u.Username == username);
        }
        public User GetUserByEmail(string email)
        {
            return DbSet.FirstOrDefault(u => u.EmailAddress == email);
        }

        public User GetUserBySocialLink(string socialname, string token)
        {
            return DbContext.Set<SocialLink>().SingleOrDefault(sl => sl.SocialName == socialname && sl.Token == token).User;
        }
        public User GetUserBySocialUID(string socialname, string uid)
        {
            var links = DbContext.Set<SocialLink>().SingleOrDefault(sl => sl.SocialUserId == uid && sl.SocialName == socialname);
            if (links != null)
                return links.User;

            return null;
        }

        public ICollection<User> FindUsers(string s, int maxitems = 10)
        {
            return DbContext.Set<User>().Where(u => u.Username.ToLower().Contains(s.ToLower())).Take(maxitems).ToList();
        }
        public ICollection<User> GetUsersFollowing(int userid)
        {
            return DbContext.Set<Follow>().Where(f => f.User.UserId == userid).Select(f => f.FollowedUser).ToList();
        }
        public ICollection<User> GetFriendsGettinGame(int userid, int gameid)
        {
            return (from f in DbContext.Set<Follow>() join g in DbContext.Set<Gettinlist>() on f.FollowedUser.UserId equals g.UserId where g.GameId.Equals(gameid) && f.User.UserId.Equals(userid) select g).GroupBy(g => g.UserId).Select(u => u.FirstOrDefault().User).ToList();
        }

    }
}