using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using ConfigDict = System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<string, string>>;

namespace dungeon.Classes
{
    class ConfigManager
    {
        ConfigDict configs;

        public ConfigManager()
        {
            configs = new ConfigDict();
        }

        public void Init()
        {
            var configFile = File.ReadAllLines("Content/settings.cfg");
            
            foreach (var line in configFile)
            {
                var match = Regex.Match(line, @"(?<=\[).+(?=\])");
                if (match.Success)
                {
                    configs.Add(match.Value, new Dictionary<string, string>());
                }
                else
                {
                    var setting = Regex.Match(line, @"(?<Name>^\w+(?= ))(?> )(?<Value>.+)");
                    if (setting.Success)
                    {
                        var name = setting.Groups["Name"].Value;
                        configs.Last().Value[name] = setting.Groups["Value"].Value;
                    }
                }
            }
        }

        public Dictionary<string, string> GetControlConfig()
        {
            return configs.TryGetValue("Controls", out var settings)
                    ? settings
                    : null;
        }
    }
}
