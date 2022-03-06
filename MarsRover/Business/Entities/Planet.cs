using MarsRover.Business.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business.Entities
{
    public class Planet
    {
        #region Attributes
        public Coordinate UpperBound { get; set; }       
        public Coordinate LowerBound { get; set; }
        public List<IRover> Rovers { get; set; }
        #endregion

        #region Constructor
        public Planet(Coordinate UpperBound)
        {
            this.UpperBound = UpperBound;
            this.LowerBound = new Coordinate(0, 0);
            Rovers = new List<IRover>();
        }
        #endregion

        #region Actions
        public void InsertRover(IRover rover)
        {
            if (IsRoverValid(rover))
                Rovers.Add(rover);
            else
                throw new InvalidRoverException(Constants.InvalidRover);
        }

        public bool IsRoverValid(IRover rover)
        {
            if (rover.GetX() < LowerBound.X || rover.GetY() < LowerBound.Y)
                return false;
            else if (rover.GetX() > UpperBound.X || rover.GetY() > UpperBound.Y)
                return false;
            else if (!Constants.Faces.Contains(rover.GetFace()))
                return false;
            else
                return true;

        }
        #endregion

    }
}
