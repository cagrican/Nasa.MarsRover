using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Nasa.MarsRover.Exceptions;
using Nasa.MarsRover.Models;

namespace Nasa.MarsRover.Services
{
    public class PlateauService:IPlateauService
    {
        private readonly ILogger _logger;

        private List<RoverPositionModel> _roverPositionModels;
        private PlateauModel _plateauModel;
        
        public PlateauService(ILogger<PlateauService> logger)
        {
            _logger = logger;
        }

        public void Create(int width, int height)
        {
            var plateauModel = new PlateauModel
            {
                Width = width,
                Height = height
            };
            
            if (!IsValid(plateauModel))
            {
                var exception = new ValidatePlateauSizeException();
                _logger.LogError(exception.Message);
                throw exception;
            }
            _roverPositionModels = new List<RoverPositionModel>();
            _plateauModel = plateauModel;
            
            _logger.LogInformation($"Created plateau {width}x{height}");
        }
        
        private static bool IsValid(PlateauModel plateauModel)
        {
            return plateauModel.Width > 0 && plateauModel.Height > 0;
        }

        public void AddMarsRover(RoverPositionModel roverPositionModel)
        {
            _roverPositionModels.Add(roverPositionModel);
        }

        public List<RoverPositionModel> GetMarsRovers()
        {
            return _roverPositionModels;
        }
        public PlateauModel GetCurrentPlateau()
        {
            return _plateauModel;
        }
    }
}