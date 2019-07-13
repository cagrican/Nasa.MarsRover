# Mars Rover Problem Solutions
## Part 1
A squad of robotic rovers are to be landed by NASA on a plateau on Mars. This plateau, which is curiously rectangular, must be navigated by the rovers so that their on board cameras can get a complete view of the surrounding terrain to send back to Earth.
A rover's position and location is represented by a combination of x and y co-ordinates and a letter representing one of the four cardinal compass points. The plateau is divided up into a grid to simplify navigation. An example position might be 0, 0, N, which means the rover is in the bottom left corner and facing North.
In order to control a rover, NASA sends a simple string of letters. The possible letters are 'L', 'R' and 'M'. 'L' and 'R' makes the rover spin 90 degrees left or right respectively, without moving from its current spot. 'M' means move forward one grid point, and maintain the same heading.
Assume that the square directly North from (x, y) is (x, y+1).
### Input:
The first line of input is the upper-right coordinates of the plateau, the lower-left coordinates are assumed to be 0,0.
The rest of the input is information pertaining to the rovers that have been deployed. Each rover has two lines of input. The first line gives the rover's position, and the second line is a series of instructions telling the rover how to explore the plateau.

The position is made up of two integers and a letter separated by spaces, corresponding to the x and y co-ordinates and the rover's orientation.
Each rover will be finished sequentially, which means that the second rover won't start to move until the first one has finished moving.
### Output:
The output for each rover should be its final co-ordinates and heading.
### Input and Output
#### Test Input:
5 5
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM
#### Expected Output:
1 3 N
5 1 E

# Installation
Install .Net Core Sdk - https://dotnet.microsoft.com/download/dotnet-core/2.2
1. `$ cd Nasa.MarsRover`
2. `$ dotnet build`
3. `$ dotnet run`
# Test
1. `$ dotnet run`

# Features
1. C# / .Net Core - .NET Core is a free and open-source, managed computer software framework for the Windows, Linux, and macOS operating systems.
2. Dependency Injection - Dependency injection is a technique whereby one object supplies the dependencies of another object. 
3. Command pattern - The command pattern is a behavioral design pattern in which an object is used to encapsulate all information needed to perform an action or trigger an event at a later time.
4. Strategy pattern - The Strategy pattern is a behavioral software design pattern that enables selecting an algorithm at runtime.
5. xUnit - xUnit.net is an open-source unit testing tool.
6. Moq - Moq is a mocking framework for C#/.NET.