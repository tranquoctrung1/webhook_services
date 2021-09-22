using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceWebHook.Model
{
    public class ElementModel
    {
        public string title { get; set; }
        public string subtitle { get; set; }
        public string image_url { get; set; }

        public DefaultActionModel default_action { get; set; }

    }
}