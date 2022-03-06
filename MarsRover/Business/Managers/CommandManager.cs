using MarsRover.Business.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MarsRover.Business.Managers
{
    public class CommandManager
    {
        public CommandManager(){}

        #region PlanetInputControl
        public Coordinate SendPlanetCoordinate(string _Cooridante)
        {
            string[] CoordinateString = _Cooridante.Split(' ');
            return new Coordinate(Convert.ToInt32(CoordinateString[0]), Convert.ToInt32(CoordinateString[1]));
        }

        public bool IsPlanetBoundValid(string _Cooridante)
        {
            if (Regex.IsMatch(_Cooridante, "^[1-9][0-9]*\\s[1-9][0-9]*$"))
                return true;
            else        
                return false;
        }
        #endregion

        #region RoverInputControl


        public List<object> SendRoverCoordinates(string _Coordinate)
        {
            string[] CoordinateString = _Coordinate.Split(' ');
            List<object> coordinateParametes = new List<object>(); 
            coordinateParametes.Add(new Coordinate(Convert.ToInt32(CoordinateString[0]), Convert.ToInt32(CoordinateString[1])));
            coordinateParametes.Add(CoordinateString[2]);
            return coordinateParametes;
        }


        public bool IsRoverCoordinatesValid(string _Cooridante)
        {
            if (Regex.IsMatch(_Cooridante, "^[0-9]+\\s[0-9]+\\s[NEWS]$"))
                return true;
            else
                return false;
        }

        public bool IsRoverCommandsValid(string _Cooridante)
        {
            if (Regex.IsMatch(_Cooridante, "^[LRM]+$"))
                return true;
            else
                return false;
        }
        #endregion

        #region InputAdapter
        public List<Commands> CommandCreator(IEnumerable<string> Inputs)
        {
            
            List<Commands> commandList = new List<Commands>();
            if(Inputs != null)
            {
                if (Inputs.Count() > 1 && (Inputs.Count()-1) % 2 == 0)
                {
                    for (int i = 1; i < Inputs.Count(); i= i+2)
                    {
                        Commands command = new Commands()
                        {
                            CoordinateCommands = Inputs.ElementAt(i),
                            MovementCommands = Inputs.ElementAt(i+1)
                        };

                        commandList.Add(command);
                    }
                }
            }

            return commandList;
        }
        #endregion

    }
}
