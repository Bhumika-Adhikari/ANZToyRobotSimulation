using ToyRobotSimulation.Robot;
using ToyRobotSimulation.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace ToyRobotSimulation.Tests;

public class UnitTest
{
    
    [Fact]
    public void PlaceWithValidCoordinatesPlacesRobot()
    {
        // Arrange
        I2DPlayingBoard _board = new SquareBoard(5);
        ILogger<ToyRobot> logger = new NullLogger<ToyRobot>();
        ToyRobot _robot = new ToyRobot(_board,logger);
        ToyRobot _expected = new ToyRobot(_board,logger);
        _expected.positionX = 1;
        _expected.positionY = 1;
        _expected.direction = (Direction)Enum.Parse(typeof(Direction), "SOUTH");

        // Act
        _robot.Place(1,1,"SOUTH");

        // Assert
        Assert.Equal(_expected, _robot);
    }

    [Fact]
     public void PlaceWithInValidCoordinatesDoesNotMoveRobot()
    {
        // Arrange
        I2DPlayingBoard _board = new SquareBoard(5);
         ILogger<ToyRobot> logger = new NullLogger<ToyRobot>();
        ToyRobot _robot = new ToyRobot(_board,logger);
        ToyRobot _expected = new ToyRobot(_board,logger);

        // Act
        _robot.Place(6,1,"SOUTH");

        // Assert
        Assert.Equal(_expected, _robot);
    }

    [Fact]
     public void PlaceWithInValidDirectionDoesNotMoveRobot()
    {
        // Arrange
        I2DPlayingBoard _board = new SquareBoard(5);
         ILogger<ToyRobot> logger = new NullLogger<ToyRobot>();
        ToyRobot _robot = new ToyRobot(_board,logger);
        ToyRobot _expected = new ToyRobot(_board,logger);

        // Act
        _robot.Place(0,1,"SOUTHWEST");

        // Assert
        Assert.Equal(_expected, _robot);
    }

    [Fact]
    public void MoveValidLocationMovesTheRobotOneUnit()
    {
        // Arrange
        I2DPlayingBoard _board = new SquareBoard(5);
         ILogger<ToyRobot> logger = new NullLogger<ToyRobot>();
        ToyRobot _robot = new ToyRobot(_board,logger);
        ToyRobot _expected = new ToyRobot(_board,logger);
        _expected.positionX = 0;
        _expected.positionY = 2;
        _expected.direction = (Direction)Enum.Parse(typeof(Direction), "NORTH");

        // Act
        _robot.Place(0,1,"NORTH");
        _robot.Move();

        // Assert
        Assert.Equal(_expected, _robot);
    }
    [Fact]
    public void MoveInValidLocationDoesNotMoveTheRobot()
    {
        // Arrange
        I2DPlayingBoard _board = new SquareBoard(5);
         ILogger<ToyRobot> logger = new NullLogger<ToyRobot>();
        ToyRobot _robot = new ToyRobot(_board,logger);
        ToyRobot _expected = new ToyRobot(_board,logger);
        _expected.positionX = 0;
        _expected.positionY = 5;
        _expected.direction = (Direction)Enum.Parse(typeof(Direction), "NORTH");

        // Act
        _robot.Place(0,5,"NORTH");
        _robot.Move();

        // Assert
        Assert.Equal(_expected, _robot);
    }
    [Fact]
    public void LeftWhenFacingNorthMovesTheRobotFaceWest()
    {
        // Arrange
        I2DPlayingBoard _board = new SquareBoard(5);
         ILogger<ToyRobot> logger = new NullLogger<ToyRobot>();
        ToyRobot _robot = new ToyRobot(_board,logger);
        ToyRobot _expected = new ToyRobot(_board,logger);
        _expected.positionX = 0;
        _expected.positionY = 5;
        _expected.direction = (Direction)Enum.Parse(typeof(Direction), "WEST");

        // Act
        _robot.Place(0,5,"NORTH");
        _robot.Left();

        // Assert
        Assert.Equal(_expected, _robot);
    }
    [Fact]
    public void LeftWhenFacingWestMovesTheRobotFaceSouth()
    {
        // Arrange
        I2DPlayingBoard _board = new SquareBoard(5);
         ILogger<ToyRobot> logger = new NullLogger<ToyRobot>();
        ToyRobot _robot = new ToyRobot(_board,logger);
        ToyRobot _expected = new ToyRobot(_board,logger);
        _expected.positionX = 0;
        _expected.positionY = 5;
        _expected.direction = (Direction)Enum.Parse(typeof(Direction), "SOUTH");

        // Act
        _robot.Place(0,5,"WEST");
        _robot.Left();

        // Assert
        Assert.Equal(_expected, _robot);
    }
    [Fact]
    public void Left_WhenFacingsouth_MovesTheRobotFaceEast()
    {
        // Arrange
        I2DPlayingBoard _board = new SquareBoard(5);
         ILogger<ToyRobot> logger = new NullLogger<ToyRobot>();
        ToyRobot _robot = new ToyRobot(_board,logger);
        ToyRobot _expected = new ToyRobot(_board,logger);
        _expected.positionX = 0;
        _expected.positionY = 5;
        _expected.direction = (Direction)Enum.Parse(typeof(Direction), "EAST");

        // Act
        _robot.Place(0,5,"SOUTH");
        _robot.Left();

        // Assert
        Assert.Equal(_expected, _robot);
    }
    [Fact]
    public void LeftWhenFacingEastMovesTheRobotFaceNorth()
    {
        // Arrange
        I2DPlayingBoard _board = new SquareBoard(5);
         ILogger<ToyRobot> logger = new NullLogger<ToyRobot>();
        ToyRobot _robot = new ToyRobot(_board,logger);
        ToyRobot _expected = new ToyRobot(_board,logger);
        _expected.positionX = 0;
        _expected.positionY = 5;
        _expected.direction = (Direction)Enum.Parse(typeof(Direction), "NORTH");

        // Act
        _robot.Place(0,5,"EAST");
        _robot.Left();

        // Assert
        Assert.Equal(_expected, _robot);
    }
    [Fact]
    public void RightWhenFacingEastMovesTheRobotFaceSouth()
    {
        // Arrange
        I2DPlayingBoard _board = new SquareBoard(5);
         ILogger<ToyRobot> logger = new NullLogger<ToyRobot>();
        ToyRobot _robot = new ToyRobot(_board,logger);
        ToyRobot _expected = new ToyRobot(_board,logger);
        _expected.positionX = 0;
        _expected.positionY = 5;
        _expected.direction = (Direction)Enum.Parse(typeof(Direction), "SOUTH");

        // Act
        _robot.Place(0,5,"EAST");
        _robot.Right();

        // Assert
        Assert.Equal(_expected, _robot);
    }
    [Fact]
    public void RightWhenFacingSouthMovesTheRobotFaceWest()
    {
        // Arrange
        I2DPlayingBoard _board = new SquareBoard(5);
         ILogger<ToyRobot> logger = new NullLogger<ToyRobot>();
        ToyRobot _robot = new ToyRobot(_board,logger);
        ToyRobot _expected = new ToyRobot(_board,logger);
        _expected.positionX = 0;
        _expected.positionY = 5;
        _expected.direction = (Direction)Enum.Parse(typeof(Direction), "WEST");

        // Act
        _robot.Place(0,5,"SOUTH");
        _robot.Right();

        // Assert
        Assert.Equal(_expected, _robot);
    }
    [Fact]
    public void RightWhenFacingWestMovesTheRobotFaceNorth()
    {
        // Arrange
        I2DPlayingBoard _board = new SquareBoard(5);
         ILogger<ToyRobot> logger = new NullLogger<ToyRobot>();
        ToyRobot _robot = new ToyRobot(_board,logger);
        ToyRobot _expected = new ToyRobot(_board,logger);
        _expected.positionX = 0;
        _expected.positionY = 5;
        _expected.direction = (Direction)Enum.Parse(typeof(Direction), "NORTH");

        // Act
        _robot.Place(0,5,"WEST");
        _robot.Right();

        // Assert
        Assert.Equal(_expected, _robot);
    }
    [Fact]
    public void RightWhenFacingNorthMovesTheRobotFaceEast()
    {
        // Arrange
        I2DPlayingBoard _board = new SquareBoard(5);
         ILogger<ToyRobot> logger = new NullLogger<ToyRobot>();
        ToyRobot _robot = new ToyRobot(_board,logger);
        ToyRobot _expected = new ToyRobot(_board,logger);
        _expected.positionX = 0;
        _expected.positionY = 5;
        _expected.direction = (Direction)Enum.Parse(typeof(Direction), "EAST");

        // Act
        _robot.Place(0,5,"NORTH");
        _robot.Right();

        // Assert
        Assert.Equal(_expected, _robot);
    }
    [Fact]
    public void ReportReportsCurrentRobotPosition()
    {
        // Arrange
        I2DPlayingBoard _board = new SquareBoard(5);
         ILogger<ToyRobot> logger = new NullLogger<ToyRobot>();
        ToyRobot _robot = new ToyRobot(_board,logger);
        string _expected = String.Format("OUTPUT: " + 0 + "," + 1 + "," + "NORTH");

        // Act
        _robot.Place(0,1,"NORTH");
        string _actual = _robot.Report();

        // Assert
        Assert.Equal(_expected, _actual);
    }

    [Fact]
    public void ReportIgnoredWhenRobotIsNotPlaced(){
            
        // Arrange
        I2DPlayingBoard _board = new SquareBoard(5);
         ILogger<ToyRobot> logger = new NullLogger<ToyRobot>();
        ToyRobot _robot = new ToyRobot(_board,logger);
        string _expected = String.Empty;

        // Act
        string _actual = _robot.Report();

        // Assert
        Assert.Equal(_expected, _actual);
    }

    [Fact]
    public void MoveIgnoredWhenrobotIsNotPlaced(){
        // Arrange
        I2DPlayingBoard _board = new SquareBoard(5);
         ILogger<ToyRobot> logger = new NullLogger<ToyRobot>();
        ToyRobot _robot = new ToyRobot(_board,logger);
        ToyRobot _expected = new ToyRobot(_board,logger);
        // Act
        _robot.Move();

        // Assert
        Assert.Equal(_expected, _robot);
    }

    public void LeftIgnoredWhenrobotIsNotPlaced(){
        // Arrange
        I2DPlayingBoard _board = new SquareBoard(5);
         ILogger<ToyRobot> logger = new NullLogger<ToyRobot>();
        ToyRobot _robot = new ToyRobot(_board,logger);
        ToyRobot _expected = new ToyRobot(_board,logger);
        // Act
        _robot.Left();

        // Assert
        Assert.Equal(_expected, _robot);
    }

     public void RightIgnoredWhenrobotIsNotPlaced(){
        // Arrange
        I2DPlayingBoard _board = new SquareBoard(5);
         ILogger<ToyRobot> logger = new NullLogger<ToyRobot>();
        ToyRobot _robot = new ToyRobot(_board,logger);
        ToyRobot _expected = new ToyRobot(_board,logger);
        // Act
        _robot.Right();

        // Assert
        Assert.Equal(_expected, _robot);
    }
}
