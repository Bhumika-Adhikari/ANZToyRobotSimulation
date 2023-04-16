﻿using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using ToyRobotSimulation.Interfaces;
using ToyRobotSimulation.Robot;

namespace ToyRobotSimulation.Services
{
    public class ToyRobotSimulationService
    {
        private readonly ILogger<ToyRobotSimulationService> _logger;
        private readonly IConfiguration _config;

        private IRobot _robot;


        public ToyRobotSimulationService(ILogger<ToyRobotSimulationService> log, IConfiguration config, IRobot robot)
        {
            _logger = log;
            _config = config;
            _robot = robot;
        }



        internal bool verifyAndRunCommand(string input)
        {
            string[] arguments = input.Split(" ");
            string command = arguments[0];
            if (Enum.IsDefined(typeof(CommandType), command.ToUpper()))
            {
                int positionX = 0, positionY = 0;
                string facing = "";
                if (arguments.Length > 1)
                {
                    string[] values = arguments[1].Split(",");
                    if (values.Length == 3)
                    {
                        positionX = Convert.ToInt32(values[0]);
                        positionY = Convert.ToInt32(values[1]);
                        facing = values[2];
                        if (HandleCommands(command, positionX, positionY, facing.ToUpper()))
                            return true;
                        else
                        {
                            _logger.LogInformation("Could not Execute command");
                            return false;
                        }

                    }
                    else
                    {
                        _logger.LogInformation("Wrong Format of the command");
                        return false;
                    }
                }
                else
                {
                    if (HandleCommands(command, positionX, positionY, facing))
                        return true;
                    else
                    {
                        _logger.LogInformation("Could not Execute command");
                        return false;
                    }
                }
            }
            else
            {
                _logger.LogInformation("Wrong Command entered");
                return false;
            }
        }

        internal bool HandleCommands(string command, int positionX, int positionY, string facing)
        {
            bool success = false;
            switch (command.ToLower())
            {
                case "left":
                    success = _robot.Left();
                    break;
                case "right":
                    success = _robot.Right();
                    break;
                case "move":
                    success = _robot.Move();
                    break;
                case "report":
                    Log.Logger.Information(_robot.Report());
                    success = true;
                    break;
                case "place":
                    success = _robot.Place(positionX, positionY, facing);
                    break;
                default:
                    Log.Logger.Error("Wrong command");
                    break;
            }
            return success;
        }

        public void ConsoleRun()
        {
            string? input = "";
            while (input != "exit")
            {
                input = Console.ReadLine();
                if (input != null)
                {
                    if (!verifyAndRunCommand(input))
                    {
                        continue;
                    }
                }
            }
        }
        public void FileRun(string filepath)
        {
            var lines = File.ReadLines(filepath);
            foreach (var line in lines)
            {
                verifyAndRunCommand(line);
            }

        }
    }
}
