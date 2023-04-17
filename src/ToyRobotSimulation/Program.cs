using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.IO;
using ToyRobotSimulation.Interfaces;
using ToyRobotSimulation.Robot;
using ToyRobotSimulation.Services;

namespace ToyRobotSimulation;
class Program
{

    static string runMode = "";
    static string filepath = "";
    static int dimension = 0;
    static void Main(string[] args)
    {
        initiateConfiguration(args);

        var builder = new ConfigurationBuilder();

        Log.Logger = new LoggerConfiguration()
                    .WriteTo.Console()
                    .WriteTo.File(@"Logs/log.txt", rollingInterval: RollingInterval.Hour)
                    .CreateLogger();

        Log.Logger.Information("Welcome to the Robot simulation");

        var host = CreatehostBuilder(args)
        .UseSerilog()
        .Build();

        var svc = ActivatorUtilities.CreateInstance<ToyRobotSimulationService>(host.Services);
        svc.Run(runMode, filepath);
    }

    static IHostBuilder CreatehostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
               .ConfigureServices((context, services) =>
               {
                   services.AddTransient<IRobot, ToyRobot>();
                   services.AddTransient<I2DPlayingBoard, SquareBoard>(serviceProvider => new SquareBoard(
                   sideDimension: dimension));
                   services.AddTransient<ToyRobotSimulationService>();
               });
    }
    static void initiateConfiguration(string[] args)
    {
        try{
        if (args.Length > 0)
        {
            dimension = Convert.ToInt32(args[0]);
            if (args.Length > 1)
            {
                runMode = args[1];
                if (runMode.ToLower() == "file")
                {
                    if (args.Length > 2)
                    {
                        filepath = args[2];
                    }
                }
            }
        }
        else
        {
            // assign default values
            runMode = "console";
            dimension = 5;
        }
        }
        catch(Exception ex)
        {
            Log.Logger.Error($"Could not initiate with given configuration - Proceeding with defualt configuration {ex.Message} " );
            runMode="console";
            dimension = 5;
        }
    }

}
