using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;
using Nasa.MarsRover.Commands;
using Nasa.MarsRover.Constants;
using Nasa.MarsRover.Enums;
using Nasa.MarsRover.Models;
using Nasa.MarsRover.Services;
using Nasa.MarsRover.Strategies.DirectionStrategy.Interfaces;

namespace Nasa.MarsRover.Core
{
    public class CommandInvoker:ICommandInvoker
    {
        private readonly Dictionary<string, CommandType> _commandTypeDictionary = RoverConstants.CommandTypeDictionary;

        private readonly IPlateauService _plateauService;
        private readonly IMarsRoverService _marsRoverService;
        private readonly ILogger _logger;
        private readonly IDirectionManagerStrategy _directionManagerStrategy;

        
        public CommandInvoker(IPlateauService plateauService,IMarsRoverService marsRoverService,ILogger<CommandInvoker> logger, IDirectionManagerStrategy directionManagerStrategy)
        {
            _plateauService = plateauService;
            _marsRoverService = marsRoverService;
            _logger = logger;
            _directionManagerStrategy = directionManagerStrategy;
        }

        public List<ICommand> InvokeAll(string cmd)
        {
            var commandsString =  cmd
                .Split(new[] {Environment.NewLine}, StringSplitOptions.None)
                .ToList();

            var result = new List<ICommand>();
            foreach (var commandString in commandsString)
            {
                result.AddRange(ParseCommand(commandString));
            }

            return result;
        }

        private List<ICommand> ParseCommand(string commandString)
        {
            var commandType = _commandTypeDictionary.FirstOrDefault(regexToCommandType => new Regex(regexToCommandType.Key).IsMatch(commandString));         
            switch (commandType.Value)
            {
                case CommandType.CreatePlateauCommand:
                    return ParseCreatePlateauCommand(commandString);
                case CommandType.CreateMarsRoverCommand:
                    return ParseCreateMarsRoverCommand(commandString);
                case CommandType.MoveRoverCommand:
                    return ParseMoveRover(commandString);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        private List<ICommand> ParseMoveRover(string commandString)
        {
            var result = new List<ICommand>();
            foreach (var cmd in commandString)
            {
                Enum.TryParse(cmd.ToString(), out MoveRoverCommandType enumCmd);
                switch (enumCmd)
                {
                    case MoveRoverCommandType.L:
                        result.Add(new RotateLeftCommand(_marsRoverService, _directionManagerStrategy));
                        break;
                    case MoveRoverCommandType.R:
                        result.Add(new RotateRightCommand(_marsRoverService, _directionManagerStrategy));
                        break;
                    case MoveRoverCommandType.M:
                        result.Add(new MoveForwardCommand(_marsRoverService, _directionManagerStrategy));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return result;
        }
        private List<ICommand> ParseCreatePlateauCommand(string command)
        {
            var arguments = command.Split();
            var width = int.Parse(arguments[0]);
            var height = int.Parse(arguments[1]);

            return new List<ICommand>()
            {
                new CreatePlateauCommand(_plateauService, width, height)
            };
        }
        
        private List<ICommand> ParseCreateMarsRoverCommand(string command)
        {
            var arguments = command.Split();
            var x = int.Parse(arguments[0]);
            var y = int.Parse(arguments[1]);
            var directionString = arguments[2];

            var direction = default(Direction);
            
            switch (directionString)
            {
                case "N":
                    direction = Direction.North;
                    break;
                case "S":
                    direction = Direction.South;
                    break;
                case "W":
                    direction = Direction.West;
                    break;
                case "E":
                    direction = Direction.East;
                    break;
            }
            return new List<ICommand>()
            {
                new CreateMarsRoverCommand(_marsRoverService,_plateauService,x,y,direction)
            };        
        }
    }
}