using System;

namespace Nasa.MarsRover.Exceptions
{
    public class ValidatePlateauSizeException : Exception
    {
        public ValidatePlateauSizeException() : base(@"Plateau size not validated given parameters")
        {

        }
    }
}