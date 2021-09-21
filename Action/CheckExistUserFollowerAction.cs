using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceWebHook.Action
{
    public class CheckExistUserFollowerAction
    {
        public bool CheckExistUserFollower(string id)
        {
            ModelDataContext context = new ModelDataContext();

            try
            {
                Zl_User_Follow el = context.Zl_User_Follows.Single(u => u.IdFollower == id);

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