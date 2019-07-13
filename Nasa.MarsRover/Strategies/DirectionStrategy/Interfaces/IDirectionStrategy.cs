using Nasa.MarsRover.Enums;
using Nasa.MarsRover.Models;

namespace Nasa.MarsRover.Strategies.DirectionStrategy.Interfaces
{
    public interface IDirectionStrategy
    {
        RoverPositionModel MoveForward(RoverPositionModel roverPositionModel);
        Direction RotateLeft();
        Direction RotateRight();
   }
}