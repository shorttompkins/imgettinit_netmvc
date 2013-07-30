using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data;
using System.Linq;
using App.Data.Contracts;
using App.Model;

namespace App.Data
{
    public class GettinListRepository : EFRepository<Gettinlist>, IGettinListRepository
    {
        public GettinListRepository(DbContext context) : base(context) { }

        public bool RemoveGameFromGettinList(int userid, int gameid)
        {
            var entity = DbSet.FirstOrDefault(l => l.UserId == userid && l.GameId == gameid);
            this.Delete(entity);

            return true;
        }

        public IEnumerable<Gettinlist> GetGettinListByUser(int userid)
        {
            return DbSet.Where(gl => gl.UserId == userid);
        }
        public IEnumerable<Gettinlist> GetGettinListByUser(int userid, int gameid, int consoleid)
        {
            return DbSet.Where(gl => gl.UserId == userid && gl.GameId == gameid && gl.ConsoleId == consoleid);
        }
    }
}
