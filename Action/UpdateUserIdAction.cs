using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceWebHook.Action
{
    public class UpdateUserIdAction
    {
        public void UpdateUserId (string id,string phone ,string zaloid)
        {
            ModelDataContext context = new ModelDataContext();

            try
            {
                t_Consumer el = context.t_Consumers.Single(u => u.ConsumerId == id && u.Phone == phone && u.ConsumerId != null && u.ConsumerId != "");

                if(el != null)
                {
                    el.ZaloId = zaloid;
                    context.SubmitChanges();
                }

            }
            catch(Exception ex)
            {

            }
        }
    }
}