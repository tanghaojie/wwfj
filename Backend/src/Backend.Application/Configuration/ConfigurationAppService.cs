using Backend.Configuration.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Configuration
{
    public class ConfigurationAppService : BackendAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForApplicationAsync(AppSettingNames.UiTheme, input.Theme);
        }

        public string GetUITheme()
        {
            return SettingManager.GetSettingValue(AppSettingNames.UiTheme);
        }
    }
}
