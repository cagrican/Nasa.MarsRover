using Moq;
using Nasa.MarsRover.Commands;
using Nasa.MarsRover.Enums;
using Nasa.MarsRover.Models;
using Nasa.MarsRover.Services;
using Nasa.MarsRover.Strategies.DirectionStrategy.Interfaces;
using Xunit;

namespace Nasa.MarsRover.Tests.Commands
{
    public class RotateRightCommandTests
    {
        [Theory]
        [InlineData(Direction.West)]
        [InlineData(Direction.North)]
        [InlineData(Direction.South)]
        [InlineData(Direction.East)]
        public void RotateRightCommand_Should_Call_Create_Method_When_Expected_Value(Direction direction)
        { 
            //Arrange
            var  marsRoverService = new Mock<IMarsRoverService>();
            var  directionManagerStrategy = new Mock<IDirectionManagerStrategy>();
            marsRoverService.Setup(s => s.GetCurrentRover()).Returns(new RoverPositionModel(1,1,direction));

            var moveForwardCommand = new RotateRightCommand(marsRoverService.Object,directionManagerStrategy.Object);

            //Act
            moveForwardCommand.Execute();

            //Assert
            directionManagerStrategy.Verify(mock => mock.RotateRight(direction), Times.Once);

        }
    }
}