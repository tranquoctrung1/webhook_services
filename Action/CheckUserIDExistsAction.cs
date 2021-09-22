using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceWebHook.Action
{
    public class CheckUserIDExistsAction
    {
        public bool CheckUserIDExists(string id, string phone)
        {
            ModelDataContext context = new ModelDataContext();

            try
            {
                t_Consumer el = context.t_Consumers.Single(u => u.ConsumerId == id && u.Phone == phone && u.ConsumerId != null && u.ConsumerId != "");

                if(el != null)
                {
                    return true;
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