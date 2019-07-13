using Nasa.MarsRover.Enums;

namespace Nasa.MarsRover.Models
{
    public class RoverPositionModel
    {
        public RoverPositionModel()
        {
            
        }
        public RoverPositionModel(int x, int y, Direction direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public Direction  Direction { get; set; }
    }
}