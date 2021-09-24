using Newtonsoft.Json.Linq;
using ServiceWebHook.Action;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace ServiceWebHook.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UploadImageController : ApiController
    {
        // GET: UploadImage
        public string Post()
        { 

            var httpRequest = HttpContext.Current.Request;

            try
            {
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    if (postedFile != null && postedFile.ContentLength > 0)
                    {

                        int MaxContentLength = 1024 * 1024 * 1; //Size = 1 MB  

                        IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png" };
                        var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                        var extension = ext.ToLower();
                        if (!AllowedFileExtensions.Contains(extension))
                        {

                            var message = string.Format("Please Upload image of type .jpg,.gif,.png.");

                            return message;

                        }
                        else if (postedFile.ContentLength > MaxContentLength)
                        {

                            var message = string.Format("Please Upload a file upto 1 mb.");

                            return message;

                        }
                        else
                        {
                            var filePath = HttpContext.Current.Server.MapPath("~/upload/" + postedFile.FileName);

                            postedFile.SaveAs(filePath);

                        }
                        var message1 = string.Format("Image Updated Successfully.");
                        var res = string.Format("Please Upload a image.");
                        return message1;
                    }

                }
                return "Upload Success";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }

        }
    }
}