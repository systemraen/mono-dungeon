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
    class TileData
    {
        Rectangle sourceRect;
        public Rectangle SourceRect
        {
            set { sourceRect = value; }
            get
            {
                return new Rectangle(
                    sourceRect.X + OffsetX, sourceRect.Y + OffsetY, 
                    sourceRect.Width, sourceRect.Height);
            }
        }
        public int Frames;
        public int OffsetX = 0;
        public int OffsetY = 0;
    };

    class DungeonSprite
    {
        static protected Texture2D spriteSheet;
        static protected Dictionary<string, TileData> tiles = new Dictionary<string, TileData>();

        protected TileData tileData;
        protected Vector2 spritePos = new Vector2(100, 100);
        protected float rotation = 0f;
        protected float scale = 2f;
        protected Vector2 origin;
        protected SpriteEffects spriteEffects = SpriteEffects.None;
        protected float layerDepth = 0f;

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
                    SourceRect = new Rectangle
                    {
                        X = int.Parse(data[1]),
                        Y = int.Parse(data[2]),
                        Width = int.Parse(data[3]),
                        Height = int.Parse(data[4])
                    },
                    Frames = (data.Length == 6 ? int.Parse(data[5]) : 1)
                });
            }
        }

        protected void SetTileName(string tileName)
        {
            tileData = tiles[tileName];
            origin = new Vector2(tileData.SourceRect.Width / 2, tileData.SourceRect.Height / 2);
        }

        internal void Update(GameTime gameTime)
        {
            if (tileData.Frames > 1)
            {
                var frame = (int)(gameTime.TotalGameTime.TotalSeconds * 7) % tileData.Frames;
                tileData.OffsetX = tileData.SourceRect.Width * frame;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spriteSheet, spritePos, tileData.SourceRect, Color.White, rotation, origin, scale, spriteEffects, layerDepth);
        }        
    }
}
