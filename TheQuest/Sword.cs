using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheQuest
{
    class Sword : Weapon
    {
        public Sword(Game game, Point location)
            : base(game, location) { }

        public override string Name { get { return "Sword"; } }

        /// <summary>
        /// Attacks enemy if within range.
        /// </summary>
        /// <param name="direction">User selected direction on form.</param>
        /// <param name="random">Sets random damage amount.</param>
        public override void Attack(Direction direction, Random random)
        {

            // Loops three times to hit in three directions.  Stops if hits enemy.
            for (int i = 0; i <= 2; i++)
            {
                int attackNumber = (int)direction;

                if (i == 1)
                {
                        if (attackNumber == 3)
                            attackNumber = 0;
                        else
                            attackNumber++;
                }
                if (i == 2)
                {
                        if (attackNumber == 0)
                            attackNumber = 3;
                        else
                            attackNumber--;
                }

                if (DamageEnemy((Direction)attackNumber, 10, 4, random))
                    break;
            }
        }
    }
}