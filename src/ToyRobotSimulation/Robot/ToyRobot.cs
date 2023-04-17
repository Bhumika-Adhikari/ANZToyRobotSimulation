using System;
using Microsoft.Extensions.Logging;
using ToyRobotSimulation.Interfaces;
using ToyRobotSimulation.Robot;

namespace ToyRobotSimulation.Robot
{
    public class ToyRobot : IRobot
    {
        private readonly ILogger<ToyRobot> _logger;
        public int positionX;
        public int positionY;
        I2DPlayingBoard playingBoard;
        public Direction direction;
        public bool placedOnBoard;

        public ToyRobot(I2DPlayingBoard board, ILogger<ToyRobot> logger)
        {
            playingBoard = board;
            positionX = 0;
            positionY = 0;
            placedOnBoard = false;
            _logger = logger;
        }
        public bool Left()
        {
            try
            {
                if (placedOnBoard)
                {
                    if ((int)direction + 90 == 360)
                    {
                        direction = (Direction)(0);
                    }
                    else
                        direction = direction + 90;

                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception Occurred while tryign to move left :{ex.Message} ");
                return false;
            }
        }

        public bool Move()
        {
            try
            {
                bool _sucess = false;
                if (placedOnBoard)
                {
                    switch (direction)
                    {
                        case Direction.EAST:
                            if (safeToMove(positionX + 1, positionY))
                            {
                                positionX = positionX + 1;
                                _sucess = true;
                            }
                            break;
                        case Direction.WEST:
                            if (safeToMove(positionX - 1, positionY))
                            {
                                positionX = positionX - 1;
                                _sucess = true;
                            }
                            break;
                        case Direction.NORTH:
                            if (safeToMove(positionX, positionY + 1))
                            {
                                positionY = positionY + 1;
                                _sucess = true;
                            }
                            break;
                        case Direction.SOUTH:
                            if (safeToMove(positionX, positionY - 1))
                            {
                                positionY = positionY - 1;
                                _sucess = true;
                            }
                            break;
                    }
                }
                return _sucess;
            }
            catch (Exception ex)
            {
               _logger.LogError($"Exception Occurred while tryign to move : {ex.Message}");
                return false;
            }
        }

        public bool Place(int xCoordinate, int yCoordinate, string facing)
        {
            try
            {
                Direction newDirection = (Direction)Enum.Parse(typeof(Direction), facing);
                if (safeToMove(xCoordinate, yCoordinate))
                {
                    positionX = xCoordinate;
                    positionY = yCoordinate;
                    direction = newDirection;
                    if (placedOnBoard == false)
                        placedOnBoard = true;
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception Occurred while tryign to Place robot : {ex.Message}");
                return false;
            }
        }

        public string Report()
        {
            if (placedOnBoard)
                return String.Format($"OUTPUT: {positionX},{positionY},{direction}");
            else return String.Empty;
        }

        public bool Right()
        {
            try
            {
                if (placedOnBoard)
                {
                    if ((int)direction - 90 < 0)
                    {
                        direction = (Direction)(270);
                    }
                    else
                        direction = direction - 90;
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception Occurred while tryign to move Right : {ex.Message}");
                return false;
            }
        }

        private bool safeToMove(int xCoordinate, int yCoordinate)
        {
            try
            {
                if (xCoordinate >= 0 && yCoordinate >= 0 && xCoordinate <= playingBoard.GetXDimension() && yCoordinate <= playingBoard.GetYDimension())
                    return true;

                else
                    return false;
            }
            catch (Exception ex)
            {
               _logger.LogError($"Exception Occurred while checking safety of robot : {ex.Message}");
                return false;
            }
        }

        public override bool Equals(object? obj)
        {
            var item = obj as ToyRobot;

            if (item == null)
            {
                return false;
            }

            return this.positionX.Equals(item.positionX) && this.positionY.Equals(item.positionY) && this.direction.Equals(item.direction);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(positionX, positionY, direction);
        }
    }
}