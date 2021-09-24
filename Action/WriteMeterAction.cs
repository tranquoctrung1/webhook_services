using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceWebHook.Action
{
    public class WriteMeterAction
    {
        public bool WriteMeter(string contracid, string period, string lastnumber, string recordtime, string file)
        {
            ModelDataContext context = new ModelDataContext();

            try
            {
                DateTime p = new DateTime(1970,01,01).AddSeconds(int.Parse(period)).AddHours(7);
                DateTime r = new DateTime(1970, 01, 01).AddSeconds(int.Parse(recordtime)).AddHours(7);

                tbl_ClockRecord_History el = new tbl_ClockRecord_History();
                el.ContractID = long.Parse(contracid);
                el.Period = p;
                el.LastNumber = long.Parse(lastnumber);
                el.RecordTime = r;

                context.tbl_ClockRecord_Histories.InsertOnSubmit(el);

                context.SubmitChanges();

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}