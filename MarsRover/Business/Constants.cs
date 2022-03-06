using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business
{
    public static class Constants
    {
        public static readonly string[] Faces = { "N", "E", "S", "W" };
        public static readonly string[] Commands = { "L", "R", "M" };
        public static readonly string InvalidRover = "Invalid Rover Founded";
        public static readonly string InvalidPlanet = "Invalid Planet Founded";
        public static readonly string InvalidCommand = "Invalid Command Founded";
        public static readonly string Left = "L";
        public static readonly string Right = "R";
        public static readonly char LeftChar = 'L';
        public static readonly char RightChar = 'R'; 
        public static readonly char MoveChar = 'M';
        public static readonly string Path = "Input\\input.txt";
        public const string North = "N";
        public const string East = "E";
        public const string South = "S";
        public const string West = "W";
        
    }
}
