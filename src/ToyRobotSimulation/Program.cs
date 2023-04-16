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

        // 

        var builder = new ConfigurationBuilder();

        // Log.Logger = new LoggerConfiguration()
        //             .ReadFrom
        //             .Configuration(builder.Build())
        //             .Enrich.FromLogContext()
        //             .WriteTo.Console()
        //             .CreateLogger();

        Log.Logger.Information("Welcome to the Robot simulation");

        var host = CreatehostBuilder(args)
        .UseSerilog()
        .Build();

        var svc = ActivatorUtilities.CreateInstance<ToyRobotSimulationService>(host.Services);
        if (runMode.ToLower() == "console")
            svc.ConsoleRun();
        else
            svc.FileRun(filepath);
    }

    static void BuildConfiguration(IConfigurationBuilder builder)
    {
        builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

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
            runMode = "console";
            dimension = 5;
        }
    }

}
