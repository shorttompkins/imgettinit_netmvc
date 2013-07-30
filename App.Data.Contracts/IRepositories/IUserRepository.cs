using System.Collections.Generic;
using System.Linq;
using App.Model;

namespace App.Data.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
        bool ActivateUser(int userid);
        bool UpdateLastLoginTimestamp(int userid);

        User GetUser(int userid);
        User GetUser(string username);
        User GetUserByEmail(string email);

        User GetUserBySocialLink(string socialname, string token);
        User GetUserBySocialUID(string socialname, string uid);

        ICollection<User> FindUsers(string s, int maxitems = 10);
        ICollection<User> GetUsersFollowing(int userid);
        ICollection<User> GetFriendsGettinGame(int userid, int gameid);
    }
}
