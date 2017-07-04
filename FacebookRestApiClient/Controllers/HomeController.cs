using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FacebookRestApiClient.Models;
using FacebookRestApiConnector;

namespace FacebookRestApiClient.Controllers
{
    public class HomeController : Controller
    {
        private const string baseUrl = "https://graph.facebook.com/";
        private const string token = "EAACEdEose0cBAH7gUTcegiZBd2Jptn658zawLsUTzCHT2H3lfdGfhshxDzXpWnYNuCR1ZBumCOeLnjMxaDIM3PhbaRNPUSzxAtsiCZCUaivK5jp6XnLWBLqZAhpimhjpCmoPe5P3C6JmTXZBOceGednew7t3BiXMtqG4nhyGQ6z2IxWWNapeMZB2iK9Pgv1JkZD";

        private Connector fbCon = new Connector(token, baseUrl);
        private string request = "?fields=id,name,email,picture{url},friends{picture,id},posts{message,created_time},photos{picture}";

        public ActionResult Index()
        {
            var model = new FacebookAccountViewModel();

            try
            {
                var result = fbCon.Request("me" + request);
                model.updateModel(result);
            }
            catch (Exception e) {}
            
            return View(model);
        }

        public ActionResult FbProfile(string id)
        {
            var model = new FacebookAccountViewModel();

            id = id == "" ? "me" : id;
            
            try
            {
                var result = fbCon.Request(id + request);
                model.updateModel(result);
            }
            catch (Exception e) { }

            return View("Index", model);
        }

        public ActionResult RandomProfile()
        {
            var model = new FacebookAccountViewModel();

            Random r = new Random();
            double id = 1000000000 + r.Next();

            try
            {
                var result = fbCon.Request(id + request);
                model.updateModel(result);
            }
            catch (Exception e) { }

            return View("Index", model);
        }
    }
}