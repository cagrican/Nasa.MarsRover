using System;

namespace Nasa.MarsRover.Exceptions
{
    public class ValidateMarsRoverPositionException: Exception
    {
        public ValidateMarsRoverPositionException():base("Mars rover position not validated given parameters")
        {
            
        }
    }
}