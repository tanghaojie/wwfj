using Abp.Application.Services;
using Backend.Configuration.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Configuration
{
    public interface IConfigurationAppService : IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);

        string GetUITheme();
    }
}
