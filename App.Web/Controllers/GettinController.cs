using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using App.Model;
using App.Data;
using App.Data.Contracts;

namespace App.Web.Controllers
{
    public class GettinController : ApiControllerBase
    {
        public GettinController(IAppUow uow)
        {
            Uow = uow;
        }

        public GettinModel Post(GettinModel model)
        {
            model.status = "success";
            return model;
        }

    }

    public class GettinModel
    {
        public int gameid { get; set; }
        public int consoleid { get; set; }
        public string status { get; set; }
    }
}
