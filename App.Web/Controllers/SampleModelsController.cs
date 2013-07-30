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
    public class SampleModelsController : ApiControllerBase
    {
        public SampleModelsController(IAppUow uow)
        {
            Uow = uow;
        }

        //GET /api/samplemodels/#

        //public SampleModel Get(int id)
        //{
        //    var model = Uow.SampleModel.GetById(id);
        //    if (model != null) return model;

        //    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        //}

        ////POST /api/samplemodels
        //public SampleModel Post(SampleModel model)
        //{
        //    Uow.SampleModel.Add(model);
        //    Uow.Commit();

        //    //var response = Request.CreateResponse(HttpStatusCode.Created, model);

        //    // Compose location header that tells how to get this session
        //    // e.g. ~/api/samplemodel/5
        //    //response.Headers.Location = new Uri(Url.Link(WebApiConfig.ControllerAndId, new { id = model.Id }));

        //    return model;
        //}

    }
}
