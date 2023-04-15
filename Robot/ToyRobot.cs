using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ANZToyRobotSimulation.Robot
{
    public class ToyRobot : IRobot
    {
        int positionX;
        int positionY;
        IPlayingBoard playingBoard;
        Direction direction;

        public ToyRobot(IPlayingBoard board)
        {
            playingBoard = board;
            positionX = 0;
            positionY = 0;
        }

        // public bool robotfunction(string command, int positionx = 0, int positiony = 0, Direction facing = 0)
        // {
        //     bool success = false;
        //     switch (command.ToLower())
        //     {
        //         case "left":
        //             Left();
        //             success = true;
        //             break;
        //         case "right":
        //             Right();
        //             success = true;
        //             break;
        //         case "place":
        //             success = Place(positionx, positiony, facing);
        //             break;
        //         case "move":
        //             success = Move();
        //             break;
        //         case "report":
        //             Report();
        //             success = true;
        //             break;
        //     }
        //     return success;
        // }
        public void Left()
        {
            if ((int)direction + 90 > 360)
            {
                direction = (Direction)((int)direction + 45);
            }
            else
                direction = direction + 90;
        }

        public bool Move()
        {
            bool _sucess = false;
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

                // case Direction.NORTHEAST:
                // case Direction.NORTHWEST:
                // case Direction.SOUTHEAST:
                // case Direction.SOUTHWEST:
                //     if (safeToMove(positionX + 1, positionY + 1))
                //     {
                //         positionX = positionX + 1;
                //         positionY = positionY + 1;
                //         _sucess = true;
                //     }
                //     break;
            }
            return _sucess;
        }

        public bool Place(int xCoordinate, int yCoordinate, Direction facing)
        {
            if (safeToMove(xCoordinate, yCoordinate))
            {
                positionX = xCoordinate;
                positionY = yCoordinate;
                direction = facing;
                return true;
            }
            return false;
        }

        public void Report()
        {
            Console.WriteLine(positionX + "," + positionY + "," + direction);
        }

        public void Right()
        {
            if ((int)direction - 90 < 0)
            {
                direction = (Direction)((int)direction - 45);
            }
            else
                direction = direction - 90;
        }

        private bool safeToMove(int xCoordinate, int yCoordinate)
        {
            if (xCoordinate >= 0 && yCoordinate >=0 && xCoordinate <= playingBoard.GetXDimension() && yCoordinate <= playingBoard.GetYDimension())
                return true;

            else
                return false;
        }
    }
}