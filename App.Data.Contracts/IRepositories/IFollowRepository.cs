using System.Collections.Generic;
using System.Linq;
using App.Model;

namespace App.Data.Contracts
{
    public interface IFollowRepository : IRepository<Follow>
    {
        bool AddFollowUser(int userid, int followid);
        bool RemoveFollowUser(int userid, int followid);
        bool CheckIfFollowingUser(int userid, int followid);
    }
}
