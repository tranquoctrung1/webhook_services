using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceWebHook.Model
{
    public class InforMeterModel
    {
        public string Name { get; set; }
        public string ContractID { get; set; }
        public Nullable<DateTime> Period { get; set; }
        public Nullable<double> FirstNumber { get; set; }
        public Nullable<double> LastNumber { get; set; }
    }
}