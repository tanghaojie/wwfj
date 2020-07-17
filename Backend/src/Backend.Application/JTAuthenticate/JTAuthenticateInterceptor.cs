using Abp.Dependency;
using Castle.DynamicProxy;
namespace Backend.JTAuthenticate
{
    public class JTAuthenticateInterceptor : IInterceptor, ITransientDependency//IInterceptor   IAsyncInterceptor
    {
        private readonly IJTAuthenticateHelper _filterHelper;

        public JTAuthenticateInterceptor(IJTAuthenticateHelper filterHelper)
        {
            _filterHelper = filterHelper;
        }

        public void Intercept(IInvocation invocation)
        {
            if (!invocation.MethodInvocationTarget.IsAbstract)
            {
                _filterHelper.Authenticate(invocation.MethodInvocationTarget, invocation.TargetType);
            }
            invocation.Proceed();
        }
    }
}
