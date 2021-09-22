using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServiceWebHook.Action;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
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

                }
                else if(zaloEvent == "unfollow")
                {

                    UpdateUserFollowerAction updateUserFollowerAction = new UpdateUserFollowerAction();

                    string follower_id = jsonResult["follower"]["id"].ToString();

                    updateUserFollowerAction.UpdateUserFollower(follower_id, false);
                }
                else if(zaloEvent == "user_send_text")
                {
                    string sender_id = jsonResult["sender"]["id"].ToString();

                    CheckFollowerFollowAction checkFollowerFollowAction = new CheckFollowerFollowAction();

                    if (checkFollowerFollowAction.CheckFollowerFollow(sender_id) == true)
                    {
                        string text = jsonResult["message"]["text"].ToString();

                        if(text == "#dangky")
                        {
                            CreateDataPostAction createDataPostAction = new CreateDataPostAction();


                           
                            string jsonString = createDataPostAction.CreateDataPost(sender_id);

                            HttpClient client = new HttpClient();

                            string url = WebConfigurationManager.AppSettings["url_zl"];


                            client.DefaultRequestHeaders.Add("access_token", WebConfigurationManager.AppSettings["access_token"]);

                            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                            var result = client.PostAsync(url, content).Result;

                            File.WriteAllText(WebConfigurationManager.AppSettings["path"], result.ToString());

                        }
                    }
                    
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