using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceWebHook.Model
{
    public class PayloadModel
    {
        public string template_type { get; set; }
        public List<ElementModel> elements { get; set; }
    }
}