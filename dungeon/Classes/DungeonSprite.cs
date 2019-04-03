using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dungeon.Classes
{
    struct TileData
    {
        public Rectangle sourceRect;
        public int frames;
    };

    class DungeonSprite
    {
        static protected Texture2D spriteSheet;
        static protected Dictionary<string, TileData> tiles = new Dictionary<string, TileData>();

        protected TileData tileData;
        protected Vector2 spritePos = new Vector2(0, 0);

        public static void Init()
        {
            var tileList = File.ReadAllLines("Content/tiles_list.txt");
            ParseTileList(tileList);
        }

        public static void LoadContent(ContentManager Content)
        {
            spriteSheet = Content.Load<Texture2D>("dungeon_sprites");            
        }

        private static void ParseTileList(string[] tileList)
        {
            foreach (var tileInfo in tileList)
            {
                if (String.IsNullOrWhiteSpace(tileInfo)) { continue; }

                var data = tileInfo.Split(' ');
                tiles.Add(data[0], new TileData
                {
                    sourceRect = new Rectangle
                    {
                        X = int.Parse(data[1]),
                        Y = int.Parse(data[2]),
                        Width = int.Parse(data[3]),
                        Height = int.Parse(data[4])
                    },
                    frames = (data.Length == 6 ? int.Parse(data[5]) : 1)
                });
            }
        }

        protected void SetTileName(string tileName)
        {
            tileData = tiles[tileName];
        }
    }
}
