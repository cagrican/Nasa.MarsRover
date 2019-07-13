using Moq;
using Nasa.MarsRover.Commands;
using Nasa.MarsRover.Enums;
using Nasa.MarsRover.Models;
using Nasa.MarsRover.Services;
using Xunit;

namespace Nasa.MarsRover.Tests.Commands
{
    public class CreatePlateauCommandTests
    {
        [Theory]
        [InlineData(1, 2)]
        [InlineData(4, 3)]
        public void CreatePlateauCommand_Should_Call_Create_Method_When_Expected_Value(int width,int height)
        { 
            //Arrange
            var  plateauService = new Mock<IPlateauService>();

            var createPlateauCommand = new CreatePlateauCommand(plateauService.Object,width,height);

            //Act
            createPlateauCommand.Execute();

            //Assert
            plateauService.Verify(mock => mock.Create(width,height), Times.Once);

        }
    }
}