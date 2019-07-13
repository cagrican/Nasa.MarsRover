using Nasa.MarsRover.Enums;
using Nasa.MarsRover.Models;

namespace Nasa.MarsRover.Strategies.DirectionStrategy.Interfaces
{
    public interface IDirectionManagerStrategy
    {
        RoverPositionModel MoveForward(RoverPositionModel roverPositionModel);
        Direction RotateLeft(Direction direction);
        Direction RotateRight(Direction direction);

    }
}