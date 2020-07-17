using Abp.Dependency;
using Castle.Core;
using Castle.MicroKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Backend.JTAuthenticate
{
    public static class JTAuthenticateInterceptorRegister
    {
        public static void Initialize(IHandler handler)
        {
            if (ShouldIntercept(handler.ComponentModel.Implementation))
            {
                handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(JTAuthenticateInterceptor)));
                //handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(AbpAsyncDeterminationInterceptor<JTAuthenticateInterceptor>)));
            }
        }
        private static bool ShouldIntercept(Type type)
        {
            return type
               .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
               .Any(m => m.IsDefined(typeof(JTAuthenticateAttribute), false));
        }

    }
}
