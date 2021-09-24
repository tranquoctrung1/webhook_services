using ServiceWebHook.Action;
using ServiceWebHook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace ServiceWebHook.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LoadInforMeterController : ApiController
    {
        // GET: LoadInforMeter
        public List<InforMeterModel> Get(string id)
        {
            LoadInforMeterAction action = new LoadInforMeterAction();

            return action.LoadInforMeter(id);
        }
    }
}