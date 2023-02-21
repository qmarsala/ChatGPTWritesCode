# Console Quest
Console Quest is a simple console game that generates mazes and challenges the player to navigate through them. The player starts at the beginning of the maze and must find their way to the end while avoiding obstacles.

## About the Code
The code for this game was written by ChatGPT, a large language model developed by OpenAI. The human user provided the initial idea and design for the game, and ChatGPT implemented the game mechanics and generated the mazes using various algorithms. The code was written in C# using the .NET Core framework and the Console application template.

The game was developed using an iterative approach, with the user providing feedback and making suggestions throughout the development process. ChatGPT used their natural language processing capabilities to interpret and respond to the user's feedback, making updates and changes to the code as needed.

While the game is relatively simple, it serves as an example of how language models like ChatGPT can be used to generate code and work collaboratively with humans on software development projects.

## How to Play
When the game starts, you will be asked to select a difficulty level. The available options are easy, medium, and hard. The difficulty level will determine how far you can see around you in the maze.

Once you have selected a difficulty level, the game will generate a maze and display it on the console. The maze will be a grid of squares with walls and paths. Your position in the maze will be represented by the letter P.

To navigate through the maze, use the arrow keys on your keyboard. You can move up, down, left, and right. If you run into a wall, you will lose the game.

Your goal is to find your way to the end of the maze, which is represented by the letter E. If you make it to the end, you win the game!

## How it Works
Console Quest is built using C# and .NET Core. It uses a recursive backtracking algorithm to generate the maze and the ConsoleKeyInfo class to read keyboard input from the player. The game also includes a timer that records how long it takes the player to complete the maze.

The game consists of four main classes: Program.cs, Maze.cs, MazeGenerator.cs, and Renderer.cs. Program.cs is the entry point for the application and is responsible for setting up the game loop. Maze.cs represents the maze and provides methods for setting walls, checking if a cell is a wall, and checking if a cell is the end of the maze. MazeGenerator.cs is responsible for generating the maze using the recursive backtracking algorithm. Renderer.cs is responsible for rendering the maze and the player on the console.

## Getting Started
To run Console Quest on your local machine, you will need to have .NET Core installed. You can download it from the .NET Core website.

To start the game, open a terminal window, navigate to the root directory of the project, and run the following command:

```
dotnet run --project ./ConsoleQuest.GreatEscape/ConsoleQuest.GreatEscape.csproj
```

## Conclusion
Console Quest is a fun and challenging game that demonstrates the power of C# and .NET Core. The game is a great example of how to use recursion to generate mazes and how to read keyboard input from the user. With a little bit of polish, Console Quest could be a great addition to any game collection.