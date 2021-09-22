using Newtonsoft.Json;
using ServiceWebHook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace ServiceWebHook.Action
{
    public class CreateDataPostAction
    {
        public string CreateDataPost(string id)
        {
            NotificationModel notification = new NotificationModel();
            notification.recipient = new RecipientModel();
            notification.recipient.user_id = id;
            notification.message = new MessageModel();
            notification.message.attachment = new AttachmentModel();
            notification.message.attachment.type = "template";
            notification.message.attachment.payload = new PayloadModel();
            notification.message.attachment.payload.template_type = "list";
            

            List<ElementModel> list = new List<ElementModel>();

            ElementModel el = new ElementModel();

            el.title = "Liên Kết Thông Tin Khách Hàng Với Bavitech Thông Qua Zalo";
            el.subtitle = "Để nhận được thông tin và sử dụng dịch vụ của Bavitech, vui lòng chọn vào đây để liên kết thông tin khách hàng";
            el.image_url = "https://stc-developers.zdn.vn/images/bg_1.jpg";
            el.default_action = new DefaultActionModel();
            el.default_action.type = "oa.open.url";
            el.default_action.url = $"{WebConfigurationManager.AppSettings["url_web"]}?uid={id}" ;

            ElementModel el2 = new ElementModel();

            el2.title = "Liên Kết Thông Tin Khách Hàng Với Bavitech Thông Qua Zalo";
            el2.image_url = "https://stc-developers.zdn.vn/images/bg_1.jpg";
            el2.default_action = new DefaultActionModel();
            el2.default_action.type = "oa.open.url";
            el2.default_action.url = $"{WebConfigurationManager.AppSettings["url_web"]}?uid={id}";

            list.Add(el);
            list.Add(el2);

            notification.message.attachment.payload.elements = new List<ElementModel>();

            notification.message.attachment.payload.elements = list;

            return JsonConvert.SerializeObject(notification);

        }
    }
}