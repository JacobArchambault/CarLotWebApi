using System;
using System.Collections.Generic;
using System.Data.Entity;
using AutoLotDAL.EF;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace CarLotWebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new MyDataInitializer());
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
