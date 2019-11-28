using Project.CheckOut.Repositories.Dapper.Sales;
using Project.CheckOut.UnitOfWork;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Configuration;
using System.Reflection;
using System.Web.Mvc;

namespace Project.CheckOut_MVC.App_Start
{
    public class DIConfig
    {
        public static void ConfigureInjector()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            container.Register<IUnitOfWork>(() => new CheckOutUnitOfWork(
                ConfigurationManager.ConnectionStrings["OnlineStoreDBConnection"].ToString()));
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            
            container.Verify();
            DependencyResolver.SetResolver(
            new SimpleInjectorDependencyResolver(container));
        }
    }
}