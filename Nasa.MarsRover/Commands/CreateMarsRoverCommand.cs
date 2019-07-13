using Nasa.MarsRover.Enums;
using Nasa.MarsRover.Models;
using Nasa.MarsRover.Services;

namespace Nasa.MarsRover.Commands
{
    public class CreateMarsRoverCommand:ICommand
    {        
        private readonly IMarsRoverService _marsRoverService;
        private readonly int _x;
        private readonly int _y;
        private readonly Direction _direction;
        private readonly IPlateauService _plateauService;
        
        
        public CreateMarsRoverCommand(IMarsRoverService marsRoverService,IPlateauService plateauService,int x,int y,Direction direction)
        {
            _marsRoverService = marsRoverService;
            _x = x;
            _y = y;
            _direction = direction;
            _plateauService = plateauService;
        }
        
        public void Execute()
        {
            _marsRoverService.CreateMarsRover(new RoverPositionModel(_x,_y,_direction), _plateauService);
        }
    }
}