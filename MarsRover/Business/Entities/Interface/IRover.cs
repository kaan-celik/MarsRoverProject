using MarsRover.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business
{
    public interface IRover
    {
        int GetX();

        int GetY();

        string GetFace();

        void SetX(int X);

        void SetY(int Y);

        void SetFace(string Face);

        void MoveOn(Planet planet);

        void Rotate(string Side);
    }
}
