using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using Autofac;

namespace CoreApplication.Infrastructure
{
   public class EngineContext
    {
        private static ILifetimeScope _container;

        public static void initialize(ILifetimeScope container)
        {
            _container = container;
        }

        private static ILifetimeScope Scope {

            get {
                if (HttpContext.Current.Items["scope"] == null)
                    HttpContext.Current.Items["scope"] = _container.BeginLifetimeScope();

                return (ILifetimeScope)HttpContext.Current.Items["scope"];
            }
        }


        public static T Locate<T>() {
            return Scope.Resolve<T>();
        }

        public static T Locate<T>(string name)
        {
            return Scope.ResolveKeyed<T>(name);
        }
    }
}
