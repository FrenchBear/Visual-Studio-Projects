// Config and Resources tests in a DLL
// Example of a simple DLL
// To access ConfigurationManager, add a reference to System.Configuration and namespace System.Configuration
//
// 2015-10-01   PV
// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-12-20   PV      Net8 C#12  Doesn't work anymore, but I don't have time to investigate in depth
// 2024-11-15	PV		Net9 C#13

using System.Configuration;
using System.IO;
using System.Reflection;
using System.Resources;

[assembly: NeutralResourcesLanguage("en-US")]

namespace ArithmeticNamespace;

public class ArithmeticClass
{
    public static int Plus(int a, int b)
        => a + b;

    // Return applicationSetting from dll.config
    public string GetApplicationSetting(string settingName)
    {
        // Doesn't work, return the config for the application, not the DLL
        // Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        var dllPath = GetType().Assembly.Location;
        var config = ConfigurationManager.OpenExeConfiguration(dllPath);

        var applicationSectionGroup = config.GetSectionGroup("ApplicationSettings");
        var applicationConfigSection = applicationSectionGroup.Sections[GetDllNamespace() + ".Properties.Settings"];
        var clientSection = (ClientSettingsSection)applicationConfigSection;
        var applicationSetting = clientSection.Settings.Get(settingName);
        return applicationSetting?.Value.ValueXml.InnerText;
    }

    // Trick to get base namespace instead of hardcoding the string
    private string GetDllNamespace()
    {
        var type = GetType();
        return type.FullName?[..type.FullName.LastIndexOf('.')] ?? "";
    }

    // Returns a specific applicationSetting from dll.config using typed access
    public static string GetTypedApplicationSetting(string settingName)
        => (string)Properties.Settings.Default[settingName];

    // Return appSetting from dll.config
    public string GetAppSetting(string settingName)
    {
        var config = ConfigurationManager.OpenExeConfiguration(GetType().Assembly.Location);
        return config.AppSettings.Settings[settingName].Value;
    }

    // Returns a string embedded in dll resources
    public static string GetStringResource(string stringName)
        => Properties.Resources.ResourceManager.GetString(stringName);

    public static Stream GetImageResource(string imageName, string defaultValue)
    {
        const string myNameSpace = "Arithmetic";
        var assembly = Assembly.GetExecutingAssembly();
        var imageStream = assembly.GetManifestResourceStream(myNameSpace + "." + imageName);
        return imageStream;
    }
}
