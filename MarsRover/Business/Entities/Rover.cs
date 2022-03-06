using MarsRover.Business.Entities;
using MarsRover.Business.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business
{
    public class Rover : IRover
    {
        #region Attributes
        private Coordinate Coordinate;
        private string Face;
        #endregion


        public Rover(Coordinate _Coordinate, string Face)
        {
            this.Coordinate = _Coordinate;
            this.Face = Face;
        }

        //---DELETE---
        #region GetterSetter
        public int GetX()
        {
            return this.Coordinate.X;
        }

        public int GetY()
        {
            return this.Coordinate.Y;
        }

        public string GetFace()
        {
            return this.Face;
        }

        public void SetX(int X)
        {
            this.Coordinate.X = X;
        }

        public void SetY(int Y)
        {
            this.Coordinate.Y = Y;
        }

        public void SetFace(string Face)
        {
            this.Face = Face;
        }
        #endregion


        #region Actions

     

        public void MoveOn(Planet planet)
        {
            switch (this.Face)
            {
                case Constants.North:
                    if(this.Coordinate.Y < planet.UpperBound.Y)
                        this.Coordinate.Y++;
                    break;
                case Constants.South:
                    if (this.Coordinate.Y > planet.LowerBound.Y)
                        this.Coordinate.Y--;
                    break;
                case Constants.East:
                    if (this.Coordinate.X < planet.UpperBound.X)
                        this.Coordinate.X++;
                    break;
                case Constants.West:
                    if (this.Coordinate.X > planet.LowerBound.X)
                        this.Coordinate.X--;
                    break;
                default:
                    break;
            }
        }

        public void Rotate(string Side)
        {
            int index = Array.IndexOf(Constants.Faces, this.Face);

            if(Side.Equals(Constants.Left))
            {
                index--;
                if (index < 0)
                    index = Constants.Faces.Length -1;

            }
            else if(Side.Equals(Constants.Right))
            {
                index++;
                if (index >= Constants.Faces.Length)
                    index = 0;
            }
            else
            {
                throw new InvalidCommandException(Constants.InvalidCommand);
            }

            this.Face = Constants.Faces.ElementAt(index);
        }
        #endregion

    }
}
