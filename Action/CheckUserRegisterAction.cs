using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceWebHook.Action
{
    public class CheckUserRegisterAction
    {
        public bool CheckUserRegister(string zaloid)
        {
            ModelDataContext context = new ModelDataContext();

            try
            {
                List<t_Consumer> list = context.t_Consumers.Where(u => u.ZaloId == zaloid).ToList();

                if(list.Count != 0)
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