This is a simple application for movement of robot on the table of 5x5.
The robot accepts 5 commands (Place, Move, Left, Right, Report) from console and acts according without falling off the table.

Examples to run: 
PLACE 3,3,WEST
MOVE
MOVE
MOVE
RIGHT
MOVE
REPORT
Output: 0,4,NORTH

PLACE 4,4,EAST
MOVE
MOVE
RIGHT
MOVE
MOVE
REPORT
Output: 5,2,SOUTH

PLACE 0,0,SOUTH
MOVE
MOVE
MOVE
RIGHT
MOVE
REPORT
Output: 0,0,WEST

PLACE 2,3,NORTH
LEFT
MOVE
MOVE
MOVE
REPORT
Output: 0,3,WEST

PLACE 1,1,EAST
MOVE
RIGHT
MOVE
MOVE
MOVE
REPORT
Output: 2,0,SOUTH

PLACE 4,0,WEST
MOVE
LEFT
MOVE
MOVE
REPORT
Output: 3,0,SOUTH


Testing:
Unit tests are provided to ensure the correctness of the application.
Run tests using xUnit:
`dotnet test`
