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
    public class VendorController : ApiControllerBase
    {
        public VendorController(IAppUow uow)
        {
            Uow = Uow;
        }

        public List<Vendor> Get()
        {
            return Uow.Vendor.GetAll().ToList();
        }
    }
}
