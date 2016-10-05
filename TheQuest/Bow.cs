using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheQuest
{
    class Bow : Weapon
    {
        public Bow(Game game, Point location)
            : base(game, location) { }

        public override string Name { get { return "Bow"; } }

        /// <summary>
        /// Attacks enemy if within range.
        /// </summary>
        /// <param name="direction">User selected direction on form.</param>
        /// <param name="random">Sets random damage amount.</param>
        public override void Attack(Direction direction, Random random)
        {
            DamageEnemy(direction, 30, 2, random);
        }
    }
}
