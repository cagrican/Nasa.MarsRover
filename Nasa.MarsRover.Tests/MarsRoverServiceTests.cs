using System;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Nasa.MarsRover.Enums;
using Nasa.MarsRover.Exceptions;
using Nasa.MarsRover.Models;
using Nasa.MarsRover.Services;
using Xunit;

namespace Nasa.MarsRover.Tests
{
    public class MarsRoverServiceTests
    {
        private ILogger<MarsRoverService> _loggerMock;

        public MarsRoverServiceTests()
        {
            _loggerMock = Mock.Of<ILogger<MarsRoverService>>();
        }

        [Theory]
        [InlineData(6, 6, Direction.West)]
        [InlineData(6, 1, Direction.North)]
        [InlineData(1, 6, Direction.South)]
        [InlineData(-1, 2, Direction.East)]
        [InlineData(1, -2, Direction.East)]
        public void CreateMarsRover_Should_Throw_InvalidPosition_When_Negative_Or_Extreme(int x,int y,Direction direction)
        { 
            //Arrange
            var  plateauService = new Mock<IPlateauService>();
            plateauService.Setup(foo => foo.GetCurrentPlateau()).Returns(new PlateauModel
            {
                Width = 5,
                Height = 5
            });
            var roverPositionModel = new RoverPositionModel
            {
                X = x,
                Y = y,
                Direction = direction
            };
            var marsRoverService = new MarsRoverService(_loggerMock);

            //Act

            void Action()
            {
                marsRoverService.CreateMarsRover(roverPositionModel, plateauService.Object);
            }

            //Assert
            Assert.Throws<ValidateMarsRoverPositionException>((Action) Action);
        }

        [Fact]
        public void CreateMarsRover_Should_Create_Mars_Rover_When_Expected_Position()
        {
            //Arrange
            var  plateauService = new Mock<IPlateauService>();
            plateauService.Setup(foo => foo.GetCurrentPlateau()).Returns(new PlateauModel
            {
                Width = 5,
                Height = 5
            });
            var roverPositionModel = new RoverPositionModel
            {
                X = 1,
                Y = 3,
                Direction = Direction.East
            };
            //Act
            var marsRoverService = new MarsRoverService(_loggerMock);

            marsRoverService.CreateMarsRover(roverPositionModel, plateauService.Object);

            var currentRoverPositionModel = marsRoverService.GetCurrentRover();
            //Assert

            currentRoverPositionModel.X.Should().Be(roverPositionModel.X);
            currentRoverPositionModel.Y.Should().Be(roverPositionModel.Y);
            currentRoverPositionModel.Direction.Should().Be(roverPositionModel.Direction);
            
        }
        
        [Fact]
        public void ChangePosition_Should_Change_Position_When_Expected_Position()
        {
            //Arrange
            var  plateauService = new Mock<IPlateauService>();
            plateauService.Setup(foo => foo.GetCurrentPlateau()).Returns(new PlateauModel
            {
                Width = 5,
                Height = 5
            });
            var roverPositionModel = new RoverPositionModel
            {
                X = 2,
                Y = 4,
                Direction = Direction.East
            };
            //Act
            var marsRoverService = new MarsRoverService(_loggerMock);

            marsRoverService.ChangePosition(roverPositionModel);

            var currentRoverPositionModel = marsRoverService.GetCurrentRover();
            //Assert

            currentRoverPositionModel.X.Should().Be(roverPositionModel.X);
            currentRoverPositionModel.Y.Should().Be(roverPositionModel.Y);
            currentRoverPositionModel.Direction.Should().Be(roverPositionModel.Direction);



        }
        
    }
}