using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace dungeon.Classes
{
    class Hero : AnimatedSprite
    {
        private HeroType heroType;
        private EventHandler eventHandler;

        public enum HeroType
        {
            Elf_F,
            Elf_M,
            Knight_F,
            Knight_M,
            Wizard_F,
            Wizard_M
        };

        public Hero(HeroType heroType, EventHandler eventHandler)
        {
            this.eventHandler = eventHandler;
            SetHeroType(heroType);
        }

        private void SetHeroType(HeroType heroType)
        {
            this.heroType = heroType;
            string heroString = "";
            switch (heroType)
            {
                case HeroType.Elf_F:
                    heroString = "elf_f";
                    break;
                case HeroType.Elf_M:
                    heroString = "elf_m";
                    break;
                case HeroType.Knight_F:
                    heroString = "knight_f";
                    break;
                case HeroType.Knight_M:
                    heroString = "knight_m";
                    break;
                case HeroType.Wizard_F:
                    heroString = "wizard_f";
                    break;
                case HeroType.Wizard_M:
                    heroString = "wizard_m";
                    break;
            }

            idleAnimationName = heroString + "_idle_anim";
            moveAnimationName = heroString + "_run_anim";
            attackAnimationName = heroString + "_hit_anim";

            SetState(State.Moving);
        }

        public new void Update(GameTime gameTime)
        {
            if (eventHandler.CurrentActions.HasFlag(EventHandler.Actions.Up))
            {
                spritePos.Y -= 10;
            }

            base.Update(gameTime);
        }
    }
}
