using System;
using Nasa.MarsRover.Enums;
using Nasa.MarsRover.Models;
using Nasa.MarsRover.Services;
using Nasa.MarsRover.Strategies.DirectionStrategy.Interfaces;

namespace Nasa.MarsRover.Commands
{
    public class MoveForwardCommand:ICommand
    {
        private readonly IMarsRoverService _marsRoverService;
        private readonly IDirectionManagerStrategy _directionManagerStrategy;

        public MoveForwardCommand(IMarsRoverService marsRoverService,IDirectionManagerStrategy directionManagerStrategy)
        {
            _marsRoverService = marsRoverService;
            _directionManagerStrategy = directionManagerStrategy;
        }
        public void Execute()
        {
            var roverPosition = _marsRoverService.GetCurrentRover();
            _directionManagerStrategy.MoveForward(roverPosition);
            _marsRoverService.ChangePosition(roverPosition);
        }
    }
}