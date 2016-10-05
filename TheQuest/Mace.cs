using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheQuest
{
    class Mace : Weapon
    {
        public Mace(Game game, Point location)
            : base(game, location) { }

        public override string Name { get { return "Mace"; } }

        /// <summary>
        /// Attacks enemy if within range.
        /// </summary>
        /// <param name="direction">User selected direction on form.</param>
        /// <param name="random">Sets random damage amount.</param>
        public override void Attack(Direction direction, Random random)
        {


            // Loops four times to hit in all directions.  Stops if hits enemy.
            for (int i = 0; i < 4; i++)
            {
                int attackNumber = (int)direction - i;

                // loops direction enum if drop below 0 value
                if (attackNumber == -1)
                    attackNumber = 3;

                if (attackNumber == -2)
                    attackNumber = 2;

                if (attackNumber == -3)
                    attackNumber = 1;

                if (DamageEnemy((Direction)attackNumber, 20, 7, random))
                    break;
            }
        }
    }
}
