using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dungeon.Classes
{
    class EventHandler
    {
        public void Init()
        {
            //pull in config
        }

        public void Update()
        {
            var kstate = Keyboard.GetState();
            //var gpState = GamePad.GetState();

            kstate.GetPressedKeys();
        }
    }
}
