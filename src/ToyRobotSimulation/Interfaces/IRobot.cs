namespace ToyRobotSimulation.Interfaces
{
    public interface IRobot
    {
        bool Move();
        bool Place(int xCoordinate, int yCoordinate, string facing);
        string Report();
        bool Left();
        bool Right();
    }
}