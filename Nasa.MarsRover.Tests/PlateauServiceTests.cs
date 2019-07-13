using System;
using System.Linq;
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
    public class PlateauServiceTests
    {
        private ILogger<PlateauService> _loggerMock;

        public PlateauServiceTests()
        {
            _loggerMock = Mock.Of<ILogger<PlateauService>>();
        }
        
        [Theory]
        [InlineData(-1, 6)]
        [InlineData(6, -1)]
        public void Create_Should_Throw_InvalidSizeException_When_Negative_Size(int width,int height)
        { 
            //Arrange
            var  plateauService = new PlateauService(_loggerMock);
           
            //Act
            void Action()
            {
                plateauService.Create(width,height);
            }

            //Assert
            Assert.Throws<ValidatePlateauSizeException>((Action)Action);
        }
        
        [Fact]
        public void Create_Should_Create_Plateau_When_Expected_Size()
        { 
            //Arrange
            var  plateauService = new PlateauService(_loggerMock);
            const int width = 5;
            const int height = 4;
            
            //Act
            plateauService.Create(width,height);
            //Assert

            plateauService.GetCurrentPlateau().Width.Should().Be(width);
            plateauService.GetCurrentPlateau().Height.Should().Be(height);
           
        }
 
        [Fact]
        public void AddMarsRover_Should_Add_Mars_Rover_Plateau_When_One_Expected_Value()
        { 
            //Arrange
            var  plateauService = new PlateauService(_loggerMock);
            var roverPositionModel = new RoverPositionModel
            {
                Direction = Direction.East,
                X = 5,
                Y = 3
            };
            plateauService.Create(6,6);

            
            //Act
            plateauService.AddMarsRover(roverPositionModel);
            //Assert

            plateauService.GetMarsRovers().Count.Should().Be(1);
            plateauService.GetMarsRovers().First().X.Should().Be(roverPositionModel.X);
            plateauService.GetMarsRovers().First().Y.Should().Be(roverPositionModel.Y);
            plateauService.GetMarsRovers().First().Direction.Should().Be(roverPositionModel.Direction);

        }
        
        [Fact]
        public void AddMarsRover_Should_Add_Mars_Rover_Plateau_When_Second_Expected_Value()
        { 
            //Arrange
            var  plateauService = new PlateauService(_loggerMock);
            plateauService.Create(6,6);
            plateauService.AddMarsRover(new RoverPositionModel
            {
                Direction = Direction.East,
                X = 5,
                Y = 3
            });
            
            var roverPositionModel = new RoverPositionModel
            {
                Direction = Direction.East,
                X = 1,
                Y = 2
            };

            
            //Act
            plateauService.AddMarsRover(roverPositionModel);
            //Assert

            plateauService.GetMarsRovers().Count.Should().Be(2);
            plateauService.GetMarsRovers().Last().X.Should().Be(roverPositionModel.X);
            plateauService.GetMarsRovers().Last().Y.Should().Be(roverPositionModel.Y);
            plateauService.GetMarsRovers().Last().Direction.Should().Be(roverPositionModel.Direction);

        }

    }
}