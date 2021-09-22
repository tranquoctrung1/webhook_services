using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceWebHook.Model
{
    public class NotificationModel
    {
        public RecipientModel recipient { get; set; }
        public MessageModel message { get; set; }
    }
}