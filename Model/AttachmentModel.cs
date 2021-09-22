using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceWebHook.Model
{
    public class AttachmentModel
    {
        public string type { get; set; }
        public PayloadModel payload { get; set; }

    }
}