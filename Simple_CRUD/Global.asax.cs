using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using DataAcces;

namespace Simple_CRUD
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Database.SetInitializer (new MyDBInitializer());
                        
        }
    }
}
