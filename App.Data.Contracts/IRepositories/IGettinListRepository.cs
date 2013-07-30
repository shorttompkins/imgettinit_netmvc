using System.Collections.Generic;
using System.Linq;
using App.Model;

namespace App.Data.Contracts
{
    public interface IGettinListRepository : IRepository<Gettinlist>
    {
        bool RemoveGameFromGettinList(int userid, int gameid);

        IEnumerable<Gettinlist> GetGettinListByUser(int userid);
        IEnumerable<Gettinlist> GetGettinListByUser(int userid, int gameid, int consoleid);
    }
}
