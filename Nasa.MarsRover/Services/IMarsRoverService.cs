using Nasa.MarsRover.Models;

namespace Nasa.MarsRover.Services
{
    public interface IMarsRoverService
    {
        void CreateMarsRover(RoverPositionModel roverPositionModel, IPlateauService plateauService);
        RoverPositionModel GetCurrentRover();
        void ChangePosition(RoverPositionModel roverPositionModel);

    }
}