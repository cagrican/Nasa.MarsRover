using Moq;
using Nasa.MarsRover.Commands;
using Nasa.MarsRover.Models;
using Nasa.MarsRover.Services;
using Nasa.MarsRover.Strategies.DirectionStrategy.Interfaces;
using Xunit;

namespace Nasa.MarsRover.Tests.Commands
{
    public class MoveForwardCommandTests
    {
        [Fact]
        public void MoveForwardCommand_Should_Call_Create_Method_When_Expected_Value()
        { 
            //Arrange
            var  marsRoverService = new Mock<IMarsRoverService>();
            var  directionManagerStrategy = new Mock<IDirectionManagerStrategy>();
 
            var moveForwardCommand = new MoveForwardCommand(marsRoverService.Object,directionManagerStrategy.Object);

            //Act
            moveForwardCommand.Execute();

            //Assert
            directionManagerStrategy.Verify(mock => mock.MoveForward(It.IsAny<RoverPositionModel>()), Times.Once);

        }
    }
}