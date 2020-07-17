using Abp.Dependency;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Backend.JTAuthenticate
{
    public interface IJTAuthenticateHelper : ITransientDependency
    {
        void Authenticate(MethodInfo methodInfo, Type type);
    }
}
