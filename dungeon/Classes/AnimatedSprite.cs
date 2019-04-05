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
    }
}
