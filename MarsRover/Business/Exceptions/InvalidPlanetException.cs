using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business.Exceptions
{
    public class InvalidPlanetException: Exception
    {
        public InvalidPlanetException()
        {

        }

        public InvalidPlanetException(string message) : base(message)
        {

        }
    }
}
