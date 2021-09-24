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
    public class GetListCustomerController : ApiController
    {
        // GET: GetListCustomer
        public List<t_Consumer> Get(string zaloid)
        {
            GetListCustomerAction action = new GetListCustomerAction();

            List<t_Consumer> list = action.GetListCustomer(zaloid);

            return list;
        }
    }
}