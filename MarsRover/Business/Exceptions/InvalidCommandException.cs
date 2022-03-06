using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business.Exceptions
{
    public class InvalidCommandException : Exception
    {
        public InvalidCommandException()
        {

        }

        public InvalidCommandException(string message) : base(message)
        {

        }
    }
}
