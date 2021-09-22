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
    public class UpdateUserController : ApiController
    {
        // GET: UpdateUser
        public bool Post(string id, string phone, string zaloid)
        {
            try
            {
                CheckUserIDExistsAction checkUserIDExistsAction = new CheckUserIDExistsAction();
                UpdateUserIdAction updateUserIdAction = new UpdateUserIdAction();

                if(checkUserIDExistsAction.CheckUserIDExists(id, phone)  == true)
                {
                    try
                    {
                        updateUserIdAction.UpdateUserId(id, phone, zaloid);
                        return true;
                    }
                    catch(Exception ex)
                    {
                        return false;
                    }
                    
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}