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
    public class GameController : ApiControllerBase
    {
        public GameController(IAppUow uow)
        {
            Uow = uow;
        }

        public Game Get(int id)
        {
            return Uow.Game.GetById(id);
        }

        public Game Post(Game game)
        {
            Uow.Game.Add(game);
            Uow.Commit();

            return game;
        }

        

    }
}
