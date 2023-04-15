using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ANZToyRobotSimulation.Robot
{
    public class SquareBoard : IPlayingBoard
    {
        int dimension;

        public SquareBoard(){
            dimension = 5;
        }

        public int GetXDimension()
        {
           return dimension;
        }

        public int GetYDimension()
        {
            return dimension;
        }
    }
}