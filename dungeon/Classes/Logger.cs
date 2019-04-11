using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dungeon.Classes
{
    static class Logger
    {
        public static void WriteLine(params object[] value)
        {
            // TODO: update logger to go to different places

            Console.WriteLine(value);
        }
    }
}
