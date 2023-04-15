using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ANZToyRobotSimulation.Robot
{
    public interface IRobot
    {
        bool Move();
        bool Place(int xCoordinate,int yCoordinate, Direction facing);
        void Report();
        void Left();
        void Right();
    }
}