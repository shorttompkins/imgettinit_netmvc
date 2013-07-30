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
    public class ConsolesController : ApiControllerBase
    {
        public ConsolesController(IAppUow uow)
        {
            Uow = uow;
        }

        public List<App.Model.Console> Get()
        {
            return Uow.Game.GetConsoles().ToList();
        }

        

    }
}
