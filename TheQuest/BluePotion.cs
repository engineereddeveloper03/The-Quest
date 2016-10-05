using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheQuest
{
    class BluePotion : Weapon, IPotion
    {
        public bool used = false;

        public bool Used
        {
            get { return used; }

        }

        public BluePotion(Game game, Point location)
            : base(game, location) { }

        public override string Name { get { return "Blue Potion"; } }

        public override void Attack(Direction direction, Random random)
        {
            game.IncreasePlayerHealth(6, random);
            used = true;
        }
    }
}
