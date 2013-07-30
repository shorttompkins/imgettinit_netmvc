using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data;
using System.Linq;
using App.Data.Contracts;
using App.Model;

namespace App.Data
{
    public class GameRepository : EFRepository<Game>, IGameRepository
    {
        public GameRepository(DbContext context) : base(context) { }

        public override IQueryable<Game> GetAll()
        {
            return DbContext.Set<Game>().Include("consoles");
        }

        public ICollection<Game> GetGettinListGames(int userid)
        {
            return DbContext.Set<Gettinlist>().Where(w => w.UserId == userid).OrderByDescending(w => w.AddedTimestamp).Select(i => i.Game).ToList();
        }
        public IEnumerable<Game> GetGettinGamesListByUser(int userid, int consoleid = 0)
        {
            if (consoleid > 0)
                return DbContext.Set<Gettinlist>().Where(gl => gl.UserId == userid && gl.ConsoleId == consoleid).Select(g => g.Game);
            else
                return DbContext.Set<Gettinlist>().Where(gl => gl.UserId == userid).Select(g => g.Game);
        }
        public IEnumerable<Game> GetGettinGamesListByUserAndFriends(int userid, int consoleid = 0)
        {
            var mylist = DbContext.Set<Gettinlist>().Where(i => i.UserId == userid).ToList();
            var myfriends = DbContext.Set<Follow>().Where(f => f.User.UserId == userid).ToList();

            var outlist = new List<Gettinlist>();

            foreach (var friend in myfriends)
            {
                var flist = DbContext.Set<Gettinlist>().Where(i => i.UserId == friend.FollowedUser.UserId);
                foreach (var list in flist)
                {
                    if (mylist.Count(g => g.GameId == list.GameId && g.ConsoleId == list.ConsoleId) > 0)
                        outlist.Add(list);
                }
            }

            return outlist.Select(g => g.Game);
        }
        public IEnumerable<Game> GetGettinGamesListByFriends(int userid, int consoleid = 0)
        {
            if (consoleid > 0)
                return (from f in DbContext.Set<Follow>() join g in DbContext.Set<Gettinlist>() on f.FollowedUser.UserId equals g.UserId where g.ConsoleId.Equals(consoleid) && f.User.UserId.Equals(userid) select g).GroupBy(g => g.GameId).Select(u => u.FirstOrDefault().Game);
            else
                return (from f in DbContext.Set<Follow>() join g in DbContext.Set<Gettinlist>() on f.FollowedUser.UserId equals g.UserId where f.User.UserId.Equals(userid) select g).GroupBy(g => g.GameId).Select(u => u.FirstOrDefault().Game);
        }
        public IEnumerable<Game> GetGettinGameListByFriends(int userid, int gameid)
        {
            return (from f in DbContext.Set<Follow>() join g in DbContext.Set<Gettinlist>() on f.FollowedUser.UserId equals g.UserId where g.GameId.Equals(gameid) && f.User.UserId.Equals(userid) select g).GroupBy(g => g.GameId).Select(u => u.FirstOrDefault().Game);
        }

        public IEnumerable<App.Model.Console> GetConsoles()
        {
            return DbContext.Set<App.Model.Console>();
        }
    }
}
