using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dungeon.Classes
{
    class EventHandler
    {
        [Flags]
        public enum Actions
        {
            None    = 0,
            Up      = 1 << 1,
            Down    = 1 << 2,
            Left    = 1 << 3, 
            Right   = 1 << 4
        }

        public Actions CurrentActions = Actions.None;
        private ConfigManager config;
        private Dictionary<Keys, Actions> mappings;

        public EventHandler(ConfigManager config)
        {
            this.config = config;
            mappings = new Dictionary<Keys, Actions>();
        }

        public void Init()
        {
            //pull in config
            var settings = config.GetControlConfig();
            if (settings.Count == 0)
            {
                // TODO: use default settings
                Logger.WriteLine("No control settings found");
            }

            foreach (var setting in settings)
            {
                if ( ! Enum.TryParse(setting.Key, true, out Actions action))
                {
                    Logger.WriteLine($"Unable to find action {setting.Key}");
                    continue;
                }

                foreach (var value in setting.Value.Split(' '))
                {
                    if (!Enum.TryParse(value, true, out Keys key))
                    {
                        Logger.WriteLine($"Unable to find key {value}");
                        continue;
                    }

                    mappings[key] = action;
                }
            }
        }

        public void Update()
        {
            CurrentActions = Actions.None;
            var keysPressed = Keyboard.GetState().GetPressedKeys();
            foreach (var key in keysPressed)
            {
                if (mappings.TryGetValue(key, out var action))
                {
                    CurrentActions |= action;
                }
            }
        }
    }
}
