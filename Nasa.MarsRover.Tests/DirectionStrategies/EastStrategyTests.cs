using FluentAssertions;
using Moq;
using Nasa.MarsRover.Commands;
using Nasa.MarsRover.Enums;
using Nasa.MarsRover.Models;
using Nasa.MarsRover.Services;
using Nasa.MarsRover.Strategies.DirectionStrategy;
using Xunit;

namespace Nasa.MarsRover.Tests.DirectionStrategies
{
    public class EastStrategyTests
    {
        [Theory]
        [InlineData(1, 2, 2, 2)]
        [InlineData(3, 1, 4, 1)]
        public void MoveForward_Should_Move_Forward_Method_When_Expected_Value(int x,int y,int newX,int newY)
        { 
            //Arrange
            var roverPositionModel = new RoverPositionModel
            {
                X = x,
                Y = y,
                Direction = Direction.East
            };
            var eastStrategy = new EastStrategy();
            //Act
            var result = eastStrategy.MoveForward(roverPositionModel);

            //Assert
            result.X.Should().Be(newX);
            result.Y.Should().Be(newY);
        }
        
        [Fact]
        public void RotateLeft_Should_Move_Forward_Method_When_Expected_Value()
        { 
            //Arrange
            var eastStrategy = new EastStrategy();
            
            //Act
            var result = eastStrategy.RotateLeft();

            //Assert
            result.Should().Be(Direction.North);
        }
        
        [Fact]
        public void RotateRight_Should_Move_Forward_Method_When_Expected_Value()
        { 
            //Arrange
            var eastStrategy = new EastStrategy();
            
            //Act
            var result = eastStrategy.RotateRight();

            //Assert
            result.Should().Be(Direction.South);
        }
    }
}