using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheQuest
{
    class Bat : Enemy
    {
        public Bat(Game game, Point location)
            : base(game, location, 6)
        { }

        /// <summary>
        /// Moves toward player 50% of time.  If location is near player, will attack.
        /// </summary>
        /// <param name="random">Moves the Bat randomly</param>
        public override void Move(Random random)
        {
            if (HitPoints > 0)
            {
                int choice = random.Next(2);
                Direction directionToMove;

                if (choice == 0)
                {
                    directionToMove = FindPlayerDirection(game.PlayerLocation);
                }
                else
                {
                    directionToMove = (Direction)random.Next(4);
                }
                base.location = Move(directionToMove, location, game.Boundaries);

                if (NearPlayer())
                {
                    game.HitPlayer(3, random);
                }
            }
        }
    }
}
