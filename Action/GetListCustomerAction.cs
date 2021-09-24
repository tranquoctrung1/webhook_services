using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceWebHook.Action
{
    public class GetListCustomerAction
    {
        public List<t_Consumer> GetListCustomer(string zaloid)
        {
            ModelDataContext context = new ModelDataContext();

            List<t_Consumer> list = new List<t_Consumer>();

            try
            {
                list = context.t_Consumers.Where(u => u.ZaloId == zaloid).ToList();
            }
            catch(Exception ex)
            {
               
            }

            return list;
        }
    }
}