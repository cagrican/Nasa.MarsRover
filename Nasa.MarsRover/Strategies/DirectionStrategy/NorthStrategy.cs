using Nasa.MarsRover.Enums;
using Nasa.MarsRover.Models;
using Nasa.MarsRover.Strategies.DirectionStrategy.Interfaces;

namespace Nasa.MarsRover.Strategies.DirectionStrategy
{
    public class NorthStrategy: IDirectionStrategy
    {
        public RoverPositionModel MoveForward(RoverPositionModel roverPositionModel)
        {
            roverPositionModel.Y += 1;
            return roverPositionModel;
        }

        public Direction RotateLeft()
        {
            return Direction.West;
        }

        public Direction RotateRight()
        {
            return Direction.East;
        }
    }
}