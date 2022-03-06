using MarsRover.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business.Managers
{
    public class RoverFactory
    {
        public IRover CreateRover(Coordinate _Coordinate, string Face)
        {
            return new Rover(_Coordinate, Face);
        }
    }
}
