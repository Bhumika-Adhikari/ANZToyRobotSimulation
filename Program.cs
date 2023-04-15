using ANZToyRobotSimulation.Robot;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;

namespace ANZToyRobotSimulation;
class Program
{
    static void Main(string[] args)
    {
        var builder = new ConfigurationBuilder();
        BuildConfiguration(builder);
        Log.Logger = new LoggerConfiguration()
                    .ReadFrom
                    .Configuration(builder.Build())
                    .Enrich.FromLogContext()
                    .WriteTo.Console()
                    .CreateLogger();

        Log.Logger.Information("Welcome to the Robot simulation");

        var host = Host.CreateDefaultBuilder()
        .ConfigureServices((context, services) =>
        {
            services.AddTransient<IRobot, ToyRobot>();
            services.AddTransient<IPlayingBoard, SquareBoard>();
            services.AddTransient<ToyRobotSimulationService>();
        })
        .UseSerilog()
        .Build();

        var svc = ActivatorUtilities.CreateInstance<ToyRobotSimulationService>(host.Services);
        svc.Run();
    }

    static void BuildConfiguration(IConfigurationBuilder builder)
    {
        builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
        // .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true);

    }


}

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

    public void Run()
    {
        string input = "";
        bool isPlaced = false;

        while (input != "exit")
        {
            input = Console.ReadLine();

            string[] arguments = input.Split(" ");
            string command = arguments[0];

            if (arguments.Length > 1)
            {
                string[] positions = arguments[1].Split(",");
                Direction facing = (Direction)Enum.Parse(typeof(Direction), positions[2].ToUpper());
                if (command.ToLower() == "place")
                {

                    if (_robot.Place(Convert.ToInt32(positions[0]), Convert.ToInt32(positions[1]), facing))
                    {
                        isPlaced = true;
                    }
                }
            }

            else if (isPlaced == false)
            {
                Log.Logger.Information("Skipped the command as first valid command should be place");
                continue;
            }
            else
            {
                bool success = false;
                switch (command.ToLower())
                {
                    case "left":
                        _robot.Left();
                        break;
                    case "right":
                        _robot.Right();
                        break;
                    case "move":
                        success = _robot.Move();
                        break;
                    case "report":
                        _robot.Report();
                        break;
                }
            }

        }
    }
}
