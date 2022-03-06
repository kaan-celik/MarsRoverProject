using MarsRover.Business;
using MarsRover.Business.Entities;
using MarsRover.Business.Exceptions;
using MarsRover.Business.Managers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    class Program
    {
        public static CommandManager commandManager;
        public static List<Commands> commandList = new List<Commands>();
        public static RoverFactory factory;
        public static Planet planet;
        public static IEnumerable<string> Inputs;        
        

        #region Methods
        public static void Initialize()
        {
            try
            {
                Inputs = File.ReadLines(Constants.Path);
                commandManager = new CommandManager();
                factory = new RoverFactory();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        public static void CreatePlanet()
        {
            if (commandManager.IsPlanetBoundValid(Inputs.ElementAt(0)))
            {
                //If its true then create planet with the inputs
                Coordinate PlanetUpperCoordinate = commandManager.SendPlanetCoordinate(Inputs.ElementAt(0));
                planet = new Planet(PlanetUpperCoordinate);
            }
            else
            {
                throw new InvalidCommandException(Constants.InvalidCommand);
            }
        }
        public static IRover CreateRovers(Commands command)
        {
            List<object> coordinateParameters = commandManager.SendRoverCoordinates(command.CoordinateCommands);
            
            Coordinate roverCoordinate = coordinateParameters.ElementAt(0) as Coordinate;            
            string roverFace = coordinateParameters.ElementAt(1).ToString();
            
            IRover rover = factory.CreateRover(roverCoordinate, roverFace);

            return rover;
        }
        public static void MoveAndRotateRover(IRover rover, Commands command)
        {
            //Movement string converted to char array for obtain each command letter
            List<char> Movements = command.MovementCommands.ToList();

            foreach (char movement in Movements)
            {
                // Checks it is movement or rotation command
                if (movement.Equals(Constants.MoveChar))
                    rover.MoveOn(planet);
                else
                    rover.Rotate(movement.ToString());
            }
        }
        public static void AdaptCommands()
        {
            commandList = commandManager.CommandCreator(Inputs);
            
        }
        #endregion

        static void Main(string[] args)
        {
            try
            {

                //Initialize and Read inputs from file
                Initialize();


                //Checks Planet Bound Input Is Valid
                CreatePlanet();


                //Inputs are adapted to the Command objects
                AdaptCommands();



                foreach (Commands command in commandList)
                {
                    //Checks Rover Bound Input Is Valid
                    if (commandManager.IsRoverCoordinatesValid(command.CoordinateCommands))
                    {
                        //If its true then get the coordinates from command manager and creates the rover with the factory
                        IRover rover = CreateRovers(command);

                        //Send Rover to the Planet
                        planet.InsertRover(rover);


                        //Checks Rover Movement Input Is Valid
                        if (commandManager.IsRoverCommandsValid(command.MovementCommands))
                        {
                            //If its true then complete movements according to the commands.
                            MoveAndRotateRover(rover, command);


                            //Print the last state of rover.
                            Console.WriteLine(String.Format("{0} {1} {2}", rover.GetX(), rover.GetY(), rover.GetFace()));
                        }
                        else
                        {
                            throw new InvalidCommandException(Constants.InvalidCommand);
                        }

                    }
                    else
                    {
                        throw new InvalidRoverException(Constants.InvalidRover);
                    }
                }                    
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
