using Abp.AspNetCore.Mvc.Views;

namespace Backend.Web.Views
{
    public abstract class BackendRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected BackendRazorPage()
        {
            LocalizationSourceName = BackendConsts.LocalizationSourceName;
        }
    }
}
