using System.Collections.Generic;
using Nasa.MarsRover.Models;

namespace Nasa.MarsRover.Services
{
    public interface IPlateauService
    {
        void Create(int width, int height);
        PlateauModel GetCurrentPlateau();
        List<RoverPositionModel> GetMarsRovers();
        void AddMarsRover(RoverPositionModel roverPositionModel);
    }
}