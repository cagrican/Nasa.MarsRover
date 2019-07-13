using FluentAssertions;
using Nasa.MarsRover.Enums;
using Nasa.MarsRover.Models;
using Nasa.MarsRover.Strategies.DirectionStrategy;
using Xunit;

namespace Nasa.MarsRover.Tests.DirectionStrategies
{
    public class NorthStrategyTests
    {
        [Theory]
        [InlineData(1, 2, 1, 3)]
        [InlineData(3, 1, 3, 2)]
        public void MoveForward_Should_Move_Forward_Method_When_Expected_Value(int x,int y,int newX,int newY)
        { 
            //Arrange
            var roverPositionModel = new RoverPositionModel
            {
                X = x,
                Y = y,
                Direction = Direction.East
            };
            var eastStrategy = new NorthStrategy();
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
            var eastStrategy = new NorthStrategy();
            
            //Act
            var result = eastStrategy.RotateLeft();

            //Assert
            result.Should().Be(Direction.West);
        }
        
        [Fact]
        public void RotateRight_Should_Move_Forward_Method_When_Expected_Value()
        { 
            //Arrange
            var eastStrategy = new NorthStrategy();
            
            //Act
            var result = eastStrategy.RotateRight();

            //Assert
            result.Should().Be(Direction.East);
        }
    }
}