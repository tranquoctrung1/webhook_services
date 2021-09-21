using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServiceWebHook.Action;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using WireMock.Models;

namespace ServiceWebHook.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class WebHookController : ApiController
    {
        // GET: WebHook
        public string Get(string name)
        {
            return $"Hello {name}";
        }

        public string Post(JObject jsonResult)
        {
            try
            {
                JObject item = JsonConvert.DeserializeObject<JObject>(jsonResult.ToString());
                string zaloEvent = jsonResult["event_name"].ToString();

                if(zaloEvent == "follow")
                {
                    string follower_id = jsonResult["follower"]["id"].ToString();

                    CheckExistUserFollowerAction checkExistUserFollowerAction = new CheckExistUserFollowerAction();
                    AddNewUserFollowAction addNewUserFollowAction = new AddNewUserFollowAction();
                    UpdateUserFollowerAction updateUserFollowerAction = new UpdateUserFollowerAction();

                    if(checkExistUserFollowerAction.CheckExistUserFollower(follower_id) == true)
                    {
                        updateUserFollowerAction.UpdateUserFollower(follower_id, true);
                    }
                    else
                    {
                        addNewUserFollowAction.AddNewUserFollow(follower_id);
                    }

                    File.WriteAllText(WebConfigurationManager.AppSettings["path"], follower_id);
                }
                else if(zaloEvent == "unfollow")
                {

                    UpdateUserFollowerAction updateUserFollowerAction = new UpdateUserFollowerAction();

                    string follower_id = jsonResult["follower"]["id"].ToString();

                    updateUserFollowerAction.UpdateUserFollower(follower_id, false);
                }

                return jsonResult.ToString();
            }
            catch(Exception ex)
            {
                return ex.ToString();
            }
            
        }
    }
}