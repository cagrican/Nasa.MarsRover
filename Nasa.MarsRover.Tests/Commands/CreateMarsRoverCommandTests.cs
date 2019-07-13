using Microsoft.Extensions.Logging;
using Moq;
using Nasa.MarsRover.Commands;
using Nasa.MarsRover.Core;
using Nasa.MarsRover.Enums;
using Nasa.MarsRover.Exceptions;
using Nasa.MarsRover.Models;
using Nasa.MarsRover.Services;
using Xunit;

namespace Nasa.MarsRover.Tests.Commands
{
    public class CreateMarsRoverCommandTests
    {
        
        [Theory]
        [InlineData(1, 2, Direction.West)]
        [InlineData(4, 3, Direction.North)]
        public void CreateMarsRover_Should_Call_Create_Method_When_Expected_Value(int x,int y,Direction direction)
        { 
            //Arrange
            var  plateauService = new Mock<IPlateauService>();
            var  marsRoverService = new Mock<IMarsRoverService>();

            var createMarsRoverCommand = new CreateMarsRoverCommand(marsRoverService.Object,plateauService.Object,x,y,direction);

            //Act
            createMarsRoverCommand.Execute();

            //Assert
            marsRoverService.Verify(mock => mock.CreateMarsRover(It.IsAny<RoverPositionModel>(),plateauService.Object), Times.Once);

        }
    }
}