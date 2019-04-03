using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dungeon.Classes
{
    class AnimatedSprite : DungeonSprite
    {
        protected string idleAnimationName;
        protected string moveAnimationName;
        protected string attackAnimationName;

        protected enum State
        {
            Idle,
            Moving,
            Attack
        }

        State state = State.Idle;

        protected void SetState(State state)
        {
            this.state = state;

            var animName = "";
            switch (state)
            {
                case State.Idle:
                    animName = idleAnimationName;
                    break;
                case State.Moving:
                    animName = moveAnimationName;
                    break;
                case State.Attack:
                    animName = attackAnimationName;
                    break;
            }

            SetTileName(animName);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var rotation = 0f;
            var scale = 2f;
            var origin = new Vector2(tileData.sourceRect.Width / 2, tileData.sourceRect.Height / 2);
            var spriteEffects = SpriteEffects.None;
            var layerDepth = 0f;

            spriteBatch.Draw(spriteSheet, spritePos, tileData.sourceRect, Color.White, rotation, origin, scale, spriteEffects, layerDepth);
        }
    }
}
