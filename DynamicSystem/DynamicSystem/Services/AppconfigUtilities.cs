using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace DynamicSystem.Services
{
    public class AppconfigUtilities
    {
        public AppconfigUtilities() { }

        public string GetConnectionString()
        {
            return ConfigurationManager.AppSettings.Get(Constant.APP_CONNECTION_STRING);
        }

        public string GetCreatorUserId()
        {
            return ConfigurationManager.AppSettings.Get(Constant.APP_CREATOR_USERID);
        }

        public List<string> GetLastCheckedTable()
        {
            if (ConfigurationManager.AppSettings[Constant.APP_KEY_TABLE] != null)
            {
                return ConfigurationManager.AppSettings.Get(Constant.APP_KEY_TABLE).Replace(" ", "").Split(',').ToList();
            }

            return new List<string>();
        }

        public void SaveToAppConfig(string key, string value, string method)
        {
            // Open App.Config of executable
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Add an Application Setting.
            if (method.Equals(Constant.METHOD_ADD))
            {
                config.AppSettings.Settings.Add(key, value);
            }
            else
            {
                config.AppSettings.Settings[key].Value = value;
            }
            // Save the changes in App.config file.
            config.Save(ConfigurationSaveMode.Modified);

            // Force a reload of a changed section.
            ConfigurationManager.RefreshSection("appSettings");
        }

        public void ClearDataAppConfig(string key)
        {
            // Open App.Config of executable
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[key].Value = "";
            // Save the changes in App.config file.
            config.Save(ConfigurationSaveMode.Modified);

            // Force a reload of a changed section.
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
