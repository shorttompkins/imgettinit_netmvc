using System.Collections.Generic;
using System.Linq;
using App.Model;

namespace App.Data.Contracts
{
    public interface IGameRepository : IRepository<Game>
    {
        ICollection<Game> GetGettinListGames(int userid);
        IEnumerable<Game> GetGettinGamesListByUser(int userid, int consoleid = 0);
        IEnumerable<Game> GetGettinGamesListByUserAndFriends(int userid, int consoleid = 0);
        IEnumerable<Game> GetGettinGamesListByFriends(int userid, int consoleid = 0);
        IEnumerable<Game> GetGettinGameListByFriends(int userid, int gameid);
        IEnumerable<Console> GetConsoles();
    }
}
