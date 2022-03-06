using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business.Exceptions
{
    public class InvalidRoverException : Exception
    {
        public InvalidRoverException()
        {
        }

        public InvalidRoverException(string message) : base(message)
        {
        }
    }
}
