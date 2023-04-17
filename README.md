# ANZToyRobotSimulation

This repo contains a console application that simulates a Toy robot moving on a square tabletop.


- [Getting started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Running locally](#running-locally)
- [Features](#features)
- [Test cases](#test-cases)

## Getting started

### Prerequisites

1. .NET Runtime (.NET 6.0)
2. Visual Studio Code / Visual Studio

### Running locally

1. Clone the repository.
2. Open terminal and navigate to checkout Folder.
3. `dotnet dist/ToyRobotSimulation.dll` to run the project using standard input. This command by default runs the application for a 5 x 5 unit square tabletop using standard input (`console` mode) from the user.
4. To exit the project while running in standard input mode, use the command `exit`. 
5. `dotnet dist/ToyRobotSimulation.dll 5 file src/ToyRobotSimulation/FileCommands.txt` to run the project with arguments where the first argument denotes the dimension of the square tabletop (default 5), the second argument denotes the run mode of the application (`console/file`) defaults to `console` and the last argument to denotes the filepath to read the commands from.

## Features
- The Robot can understand the following commands - 
  - PLACE X,Y,F
  - MOVE
  - LEFT
  - RIGHT
  - REPORT
- PLACE will put the toy robot on the table in position X,Y and facing NORTH, SOUTH,EAST or WEST.
-  MOVE will move the toy robot one unit forward in the direction it is currently facing.
- LEFT and RIGHT will rotate the robot 90 degrees in the specified direction without changing the position of the robot.
- REPORT will announce the X,Y and F of the robot.
- Any Move which can result into the robot fall is ignored.

## Publish to `dist` folder

1. cd `src/ToyRobotSimulation`.
2. Run `dotnet publish -o ../../dist` in your working directory.

## Test cases

| Test Number | Test Type   | Scenario                                                              | Expected Output                                                                   | Status |
| ----------- | ----------- | --------------------------------------------------------------------- | --------------------------------------------------------------------------------- | ------ |
| 1           | Requirement | Robot Can be placed on the Tabletop                             | Robot should be placed on the mentioned coordinates                                             | Passed |
| 2           | Requirement | Robot cannot be placed on invalid coordinates                     | Robot should not move if invalid coordinates have been passed                                                               | Passed |
| 3           | Requirement | Move should move the robot by one unit in the direction it is currently facing             | Robot should move by one unit in the current direction if possible |Passed
|4             | Requirement | Robot should ignore a move command if it's on the edge| Robot should not move if it's on the edge | Passed
| 5           | Requirement | Left should rotate the robot face left by 90 degrees                                | Robot direction changes to it's left by 90 degrees     | Passed |
| 6           | Requirement | Right should rotate robot face to the rigth by 90 degrees | Robot direction changes to it's right by 90 degrees                                 | Passed |
| 7           | Requirement | Report should announce the current position and direction the robot is facing               | Report shows the current position and direction of robot                | Passed |
| 8           | Validation | No other command should run unless the robot has been placed on the tabletop                 | All commands should be ignored unless the first place command is successfully run                                                      | Passed |
| 9           | Valdiation | The User should not be able to enter any other commands than the ones allowed                               | Wrong command message should be displayed                                                 | Passed |
| 10           | Validation  | The direction given to the robot can only be East,West,North,South                            | Appropriate message should be shown for a wrong direction entered                                                 | Passed |
| 11          | Validation  | Correct format of commands should be followed                           | Appropriate error message should be shown if the format of command is not correct                                              | Passed |