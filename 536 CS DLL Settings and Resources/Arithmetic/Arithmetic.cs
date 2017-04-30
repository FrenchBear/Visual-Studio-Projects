// Config and Resources tests in a DLL
// Example of a simple DLL
// 2015-10-01   PV
// To access ConfigurationManager, add a reference to System.Configuration and namespace System.Configuration

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticNamespace
{
    public class ArithmeticClass
    {
        public int Plus(int a, int b)
        {
            return a + b;
        }


        // Return applicationSetting from dll.config
        public string GetApplicationSetting(string settingName)
        {
            // Doesn't work, return the config for the application, not the DLL
            //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            string dllPath = this.GetType().Assembly.Location;
            Configuration config = ConfigurationManager.OpenExeConfiguration(dllPath);

            ConfigurationSectionGroup applicationSectionGroup = config.GetSectionGroup("applicationSettings");
            ConfigurationSection applicationConfigSection = applicationSectionGroup.Sections[GetDllNamespace() + ".Properties.Settings"];
            ClientSettingsSection clientSection = (ClientSettingsSection)applicationConfigSection;
            SettingElement applicationSetting = clientSection.Settings.Get(settingName);
            return applicationSetting?.Value.ValueXml.InnerText;
        }

        // Trick to get base namespace instead of hardcoding the string
        private string GetDllNamespace()
        {
            Type type = this.GetType();
            return type.FullName.Substring(0, type.FullName.LastIndexOf('.'));
        }

        // Returns a specific applicationSetting from dll.config using typed access
        public string GetTypedApplicationSetting(string settingName)
        {
            return (string)ArithmeticNamespace.Properties.Settings.Default[settingName];
        }


        // Return appSetting from dll.config
        public string GetAppSetting(string settingName)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(this.GetType().Assembly.Location);
            return config.AppSettings.Settings[settingName].Value;
        }


        // Returns a string embedded in dll resources
        public string GetStringResource(string stringName)
        {
            return Properties.Resources.ResourceManager.GetString(stringName);
        }

        public Stream GetImageResource(string imageName, string defaultValue)
        {
            Assembly _assembly;
            Stream _imageStream;
            const string MyNameSpace = "Arithmetic";

            _assembly = Assembly.GetExecutingAssembly();
            _imageStream = _assembly.GetManifestResourceStream(MyNameSpace + "." + imageName);
            return _imageStream;
        }

    }
}
