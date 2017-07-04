using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace FacebookRestApiClientUmbraco.Models
{
    public class testClass : RenderModel
    {
        public testClass(IPublishedContent content) : base(content) {}

        [Required]
        [Display(Name = "MyProp")]
        public string MyProp { get; set; }
    }
}