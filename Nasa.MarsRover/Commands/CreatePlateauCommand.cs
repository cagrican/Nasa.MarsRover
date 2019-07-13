using Nasa.MarsRover.Models;
using Nasa.MarsRover.Services;

namespace Nasa.MarsRover.Commands
{
    public class CreatePlateauCommand:ICommand
    {
        private readonly IPlateauService _plateauService;
        private readonly int _width;
        private readonly int _height;
        
        public CreatePlateauCommand(IPlateauService plateauService,int width, int height)
        {
            _plateauService = plateauService; 
            _width = width;
            _height = height;      
        }
        
        public void Execute()
        {
            _plateauService.Create(_width, _height);
        }

    }
}