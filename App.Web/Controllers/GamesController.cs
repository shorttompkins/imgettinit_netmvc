using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using App.Data.Contracts;
using App.Model;

namespace App.Web.Controllers
{
    public class GamesController : ApiControllerBase
    {
        public GamesController(IAppUow uow)
        {
            Uow = uow;
        }

        public List<Game> Get()
        {
            //return Uow.Game.GetAll().OrderBy(o => o.ReleaseDate).Take(20).ToList();
            return Uow.Game.GetAll().ToList();
        }

        public Game Get(int gameId)
        {
            return Uow.Game.GetById(gameId);
        }

        public List<Game> Get(int page, string searchstr)
        {
            //return Uow.Game.GetAll().OrderBy(o => o.ReleaseDate).Skip((page - 1) * 20).Take(20).ToList();
            return Uow.Game.GetAll().ToList();
        }        

        public Game Post(Game game)
        {
            Uow.Game.Add(game);
            Uow.Commit();

            return game;
        }

    }
}
