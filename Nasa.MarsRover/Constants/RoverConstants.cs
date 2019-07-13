using System.Collections.Generic;
using Nasa.MarsRover.Enums;

namespace Nasa.MarsRover.Constants
{
    public static class RoverConstants
    {
        public static  Dictionary<string, CommandType> CommandTypeDictionary = new Dictionary<string, CommandType>
        {
            { @"^\d+ \d+$", CommandType.CreatePlateauCommand },
            { @"^\d+ \d+ [NSEW]$", CommandType.CreateMarsRoverCommand},
            { @"^[LMR]+$", CommandType.MoveRoverCommand }
        };
    }
}