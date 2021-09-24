using ServiceWebHook.Action;
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
    public class WriteMeterController : ApiController
    {
       public bool Post(string contracid, string period, string lastnumber , string recordtime, string file)
        {
            WriteMeterAction action = new WriteMeterAction();

            return action.WriteMeter(contracid, period, lastnumber, recordtime, file);
        }
    }
}