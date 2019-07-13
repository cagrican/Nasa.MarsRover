using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nasa.MarsRover.Commands;
using Nasa.MarsRover.Core;
using Nasa.MarsRover.Services;
using Nasa.MarsRover.Strategies.DirectionStrategy;
using Nasa.MarsRover.Strategies.DirectionStrategy.Interfaces;

namespace Nasa.MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {

            ServiceProvider serviceProvider = new ServiceCollection()
                   .AddLogging()
                   .AddScoped<IPlateauService, PlateauService>()
                   .AddScoped<IMarsRoverService, MarsRoverService>()
                   .AddScoped<ICommandInvoker, CommandInvoker>()
                   .AddScoped<IDirectionManagerStrategy, DirectionManagerStrategy>()

                   .BuildServiceProvider();

            serviceProvider.GetService<ILoggerFactory>()
                .AddConsole(LogLevel.Error);
            
            var commandStringBuilder = new StringBuilder();
            commandStringBuilder.AppendLine("5 5");
            commandStringBuilder.AppendLine("1 2 N");
            commandStringBuilder.AppendLine("LMLMLMLMM");
            commandStringBuilder.AppendLine("3 3 E");
            commandStringBuilder.Append("MMRMMRMRRM");
            
            var commandInvoker = serviceProvider.GetService<ICommandInvoker>();
            var plateau = serviceProvider.GetService<IPlateauService>();

            List<ICommand> commands = null;

            try
            {
                commands = commandInvoker.InvokeAll(commandStringBuilder.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            if (commands != null)
            {
                foreach (var command in commands)
                {
                    command.Execute();
                }

            }

            foreach (var roverPositionModel in plateau.GetMarsRovers())
            {
                Console.WriteLine($"{roverPositionModel.X}x{roverPositionModel.Y} - {roverPositionModel.Direction}");
            }
            Console.ReadLine();

        }
    }
}