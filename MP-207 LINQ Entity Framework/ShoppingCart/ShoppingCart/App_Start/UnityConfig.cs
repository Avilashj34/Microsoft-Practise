using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using ShoppingCart.DataAcess;
using ShoppingCart.Business;

namespace ShoppingCart
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ICustomerBll, CustomerBll>();
            container.RegisterType<IProductBll, ProductBll>();
            container.RegisterType<IDbConnection,DbConnection>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

        }
    }
}