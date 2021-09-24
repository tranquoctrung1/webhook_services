using ServiceWebHook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceWebHook.Action
{
    public class LoadInforMeterAction
    {
        public List<InforMeterModel> LoadInforMeter (string id)
        {
            ModelDataContext context = new ModelDataContext();

            long cid = long.Parse(id);

            List<InforMeterModel> list = new List<InforMeterModel>();

            try
            {
                t_Consumer cus = context.t_Consumers.Single(u => u.Id == cid);

                List<tbl_Contract> c = context.tbl_Contracts.Where(tc => tc.CustomerID == cid).ToList();

                if(c.Count != 0)
                {
                    foreach (var item in c )
                    {
                        tbl_ClockRecord ctd = context.tbl_ClockRecords.Where(cd => cd.ContractID == item.ContractID).OrderByDescending(t => t.Period).FirstOrDefault();

                        InforMeterModel el = new InforMeterModel();
                        el.Name = cus.Description;
                        el.Period = ctd.Period;
                        el.LastNumber = ctd.LastNumber;
                        el.FirstNumber = ctd.FirstNumber;
                        el.ContractID = item.ContractID.ToString();

                        list.Add(el);
                    }
                   
                }
            }
            catch(Exception ex)
            {

            }

            return list;
        }
    }
}