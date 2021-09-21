using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceWebHook.Action
{
    public class AddNewUserFollowAction
    {
        public void AddNewUserFollow(string id)
        {

            ModelDataContext context = new ModelDataContext();

            try
            {
                Zl_User_Follow el = new Zl_User_Follow();

                el.IdFollower = id;
                el.IsFollower = true;

                context.Zl_User_Follows.InsertOnSubmit(el);

                context.SubmitChanges();
            }
            catch(Exception ex)
            {

            }
           
        }
    }
}