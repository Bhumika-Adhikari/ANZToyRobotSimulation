using ToyRobotSimulation.Interfaces;

namespace ToyRobotSimulation.Robot
{
    public class SquareBoard : I2DPlayingBoard
    {
        int dimension;

        public SquareBoard(int sideDimension){
            dimension = sideDimension;
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