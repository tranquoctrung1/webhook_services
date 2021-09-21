using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceWebHook.Action
{
    public class UpdateUserFollowerAction
    {


        public void UpdateUserFollower(string id, bool isFollow)
        {
            ModelDataContext context = new ModelDataContext();


            try
            {

                Zl_User_Follow el = context.Zl_User_Follows.Single(u => u.IdFollower == id);
                if (el != null)
                {
                    el.IsFollower = isFollow;

                    context.SubmitChanges();
                }
            }
            catch(Exception ex)
            {

            }
            
        }
    }
}