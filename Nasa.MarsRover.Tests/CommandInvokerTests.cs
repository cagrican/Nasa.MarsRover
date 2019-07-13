using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Nasa.MarsRover.Commands;
using Nasa.MarsRover.Core;
using Nasa.MarsRover.Enums;
using Nasa.MarsRover.Services;
using Nasa.MarsRover.Strategies.DirectionStrategy.Interfaces;
using Xunit;

namespace Nasa.MarsRover.Tests
{
    public class CommandInvokerTests
    {
        private readonly ILogger<CommandInvoker> _loggerMock;

        public CommandInvokerTests()
        {
            _loggerMock = Mock.Of<ILogger<CommandInvoker>>();
        }
        
        [Fact]
        public void InvokeAll_Should_Return_Command_List_When_Expected_Value()
        { 
            //Arrange
            var commandStringBuilder = new StringBuilder();
            commandStringBuilder.AppendLine("5 5");
            commandStringBuilder.AppendLine("1 2 N");
            commandStringBuilder.Append("LRMMRL");
            
            var  plateauService = new Mock<IPlateauService>();
            var  marsRoverService = new Mock<IMarsRoverService>();
            var  directionManagerStrategy = new Mock<IDirectionManagerStrategy>();

            var commandInvoker = new CommandInvoker(plateauService.Object,marsRoverService.Object,_loggerMock,directionManagerStrategy.Object);

            //Act
            var commands = commandInvoker.InvokeAll(commandStringBuilder.ToString());

            //Assert
            commands.Count.Should().Be(8);
            commands[0].GetType().Name.Should().Be("CreatePlateauCommand");
            commands[1].GetType().Name.Should().Be("CreateMarsRoverCommand");
            commands[2].GetType().Name.Should().Be("RotateLeftCommand");
            commands[3].GetType().Name.Should().Be("RotateRightCommand");
            commands[4].GetType().Name.Should().Be("MoveForwardCommand");
            commands[5].GetType().Name.Should().Be("MoveForwardCommand");
            commands[6].GetType().Name.Should().Be("RotateRightCommand");
            commands[7].GetType().Name.Should().Be("RotateLeftCommand");

        }

    }
}