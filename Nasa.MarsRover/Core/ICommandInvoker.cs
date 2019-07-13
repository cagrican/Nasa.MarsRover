using System.Collections.Generic;
using Nasa.MarsRover.Commands;

namespace Nasa.MarsRover.Core
{
    public interface ICommandInvoker
    {
        List<ICommand> InvokeAll(string commandString);
    }
}