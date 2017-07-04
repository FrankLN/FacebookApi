using FacebookRestApiConnector;
using Umbraco.Web.Mvc;
using FacebookRestApiClientUmbraco.Models;
using System;
using System.Web.Mvc;
using Umbraco.Web.Models;

namespace FacebookRestApiClientUmbraco.Controllers
{
    public class HomeController : RenderMvcController
    {
        private const string baseUrl = "https://graph.facebook.com/";
        private const string token = "EAACEdEose0cBAH7gUTcegiZBd2Jptn658zawLsUTzCHT2H3lfdGfhshxDzXpWnYNuCR1ZBumCOeLnjMxaDIM3PhbaRNPUSzxAtsiCZCUaivK5jp6XnLWBLqZAhpimhjpCmoPe5P3C6JmTXZBOceGednew7t3BiXMtqG4nhyGQ6z2IxWWNapeMZB2iK9Pgv1JkZD";

        private Connector fbCon = new Connector(token, baseUrl);
        private string request = "?fields=id,name,email,picture{url},friends{picture,id},posts{message,created_time},photos{picture}";

        
        public override ActionResult Index(RenderModel model)
        {
            var tempModel = new FacebookAccountViewModel(model.Content);

            try
            {
                var result = fbCon.Request("me" + request);
                tempModel.updateModel(result);
            }
            catch (Exception e) { }

            model = tempModel;

            return View("Home", "~/Views/Master.cshtml", model);
        }

        public ActionResult FbProfile(RenderModel model, string id)
        {
            var tempModel = new FacebookAccountViewModel(model.Content);
            
            id = id == "" ? "me" : id == "10206011971326192" ? "me" : id;

            try
            {
                var result = fbCon.Request(id + request);
                tempModel.updateModel(result);
            }
            catch (Exception e) { }

            model = tempModel;

            return View("Home", model);
        }

        public ActionResult RandomProfile(RenderModel model)
        {
            var tempModel = new FacebookAccountViewModel(model.Content);

            Random r = new Random();
            double id = 1000000000 + r.Next();

            try
            {
                var result = fbCon.Request(id + request);
                tempModel.updateModel(result);
            }
            catch (Exception e) { }

            model = tempModel;

            return View("Home", model);
        }
    }
}