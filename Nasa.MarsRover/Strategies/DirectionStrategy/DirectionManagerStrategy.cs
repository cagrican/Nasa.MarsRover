using System.Collections.Generic;
using Nasa.MarsRover.Enums;
using Nasa.MarsRover.Models;
using Nasa.MarsRover.Strategies.DirectionStrategy.Interfaces;

namespace Nasa.MarsRover.Strategies.DirectionStrategy
{
    public class DirectionManagerStrategy : IDirectionManagerStrategy
    {
        private readonly Dictionary<Direction,IDirectionStrategy> _directionStrategies;

        public DirectionManagerStrategy()
        {
            _directionStrategies = new Dictionary<Direction, IDirectionStrategy>
            {
                {Direction.North, new NorthStrategy()},
                {Direction.South, new SouthStrategy()},
                {Direction.West, new WestStrategy()},
                {Direction.East, new EastStrategy()}
            };
        }

        public RoverPositionModel MoveForward(RoverPositionModel roverPositionModel)
        {
            return _directionStrategies[roverPositionModel.Direction].MoveForward(roverPositionModel);
        }

        public Direction RotateLeft(Direction direction)
        {
            return _directionStrategies[direction].RotateLeft();
        }

        public Direction RotateRight(Direction direction)
        {
            return _directionStrategies[direction].RotateRight();
        }
    }
}