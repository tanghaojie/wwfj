using Abp.AspNetCore.Mvc.Controllers;

namespace Backend.Web.Controllers
{
    public abstract class BackendControllerBase: AbpController
    {
        protected BackendControllerBase()
        {
            LocalizationSourceName = BackendConsts.LocalizationSourceName;
        }
    }
}