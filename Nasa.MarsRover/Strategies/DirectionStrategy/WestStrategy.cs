using Nasa.MarsRover.Enums;
using Nasa.MarsRover.Models;
using Nasa.MarsRover.Strategies.DirectionStrategy.Interfaces;

namespace Nasa.MarsRover.Strategies.DirectionStrategy
{
    public class WestStrategy:IDirectionStrategy
    {
        public RoverPositionModel MoveForward(RoverPositionModel roverPositionModel)
        {
            roverPositionModel.X -= 1;
            return roverPositionModel;
        }

        public Direction RotateLeft()
        {
            return Direction.South;
        }

        public Direction RotateRight()
        {
            return Direction.North;
        }
    }
}