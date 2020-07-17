using Abp.AspNetCore.Mvc.Controllers;

namespace Backend.Web.Host.Controllers
{
    public class BackendWebHostControllerBase : AbpController
    {
        protected BackendWebHostControllerBase()
        {
            LocalizationSourceName = BackendConsts.LocalizationSourceName;
        }
    }
}
