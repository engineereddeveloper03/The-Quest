using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheQuest
{
    abstract class Mover
    {
        private const int MoveInterval = 10;
        protected Point location;
        public Point Location { get { return location; } }
        protected Game game;

        public Mover(Game game, Point location)
        {
            this.game = game;
            this.location = location;
        }

        /// <summary>
        /// Checks if Enemy or Weapon is near.
        /// </summary>
        /// <param name="locationToCheck">Location of the Weapon or Enemy</param>
        /// <param name="distance">Distance apart to attack or pick up Weapon</param>
        /// <returns></returns>
        public bool Nearby(Point locationToCheck, Point target, int distance)
        {
            if (Math.Abs(target.X - locationToCheck.X) < distance &&
                (Math.Abs(target.Y - locationToCheck.Y) < distance))
            {
                return true;
            } else {
                return false;
            }
        }

        public Point Move(Direction direction, Point target, Rectangle boundaries)
        {
            Point newLocation = target;

            switch (direction)
            {
                case Direction.Up:
                    if (newLocation.Y - MoveInterval >= boundaries.Top)
                        newLocation.Y -= MoveInterval;
                    break;
                case Direction.Down:
                    if (newLocation.Y + MoveInterval <= boundaries.Bottom)
                        newLocation.Y += MoveInterval;
                    break;
                case Direction.Left:
                    if (newLocation.X - MoveInterval >= boundaries.Left)
                        newLocation.X -= MoveInterval;
                    break;
                case Direction.Right:
                    if (newLocation.X + MoveInterval <= boundaries.Right)
                        newLocation.X += MoveInterval;
                    break;
                default: break;
            }
            return newLocation;
        }
    }
}
