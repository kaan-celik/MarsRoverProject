using MarsRover.Business;
using MarsRover.Business.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MarsRoverUnitTest.RoverTest
{
    [TestClass]
    public class RoverUnitTest
    {
        [TestMethod]
        [DynamicData(nameof(GetRoverData), DynamicDataSourceType.Method)]
        public void GetXTest(IRover rover, int valueX, int valueY, string value)
        {
            Assert.AreEqual(rover.GetX(), valueX);
        }

        [TestMethod]
        [DynamicData(nameof(GetRoverData), DynamicDataSourceType.Method)]
        public void GetYTest(IRover rover, int valueX, int valueY, string value)
        {
            Assert.AreEqual(rover.GetY(), valueY);
        }

        [TestMethod]
        [DynamicData(nameof(GetRoverData), DynamicDataSourceType.Method)]
        public void GetFaceTest(IRover rover, int valueX, int valueY, string value)
        {
            Assert.AreEqual(rover.GetFace(), value);
        }

        [TestMethod]
        [DynamicData(nameof(GetRoverData), DynamicDataSourceType.Method)]
        public void SetXTest(IRover rover, int valueX, int valueY, string value)
        {
            rover.SetX(valueX);
            Assert.AreEqual(valueX, rover.GetX());
        }
        [TestMethod]
        [DynamicData(nameof(GetRoverData), DynamicDataSourceType.Method)]
        public void SetYTest(IRover rover, int valueX, int valueY, string value)
        {
            rover.SetY(valueY);
            Assert.AreEqual(valueY, rover.GetY());
        }           
                    
        [TestMethod]
        [DynamicData(nameof(GetRoverData), DynamicDataSourceType.Method)]
        public void SetFaceTest(IRover rover, int valueX, int valueY, string value)
        {
            rover.SetFace(value);
            Assert.AreEqual(value, rover.GetFace());
        }


        [TestMethod]
        [DynamicData(nameof(GetRover_CoordinateData), DynamicDataSourceType.Method)]
        public void MoveOnTest(IRover rover, Coordinate coordinate, Planet planet)
        {
            rover.MoveOn(planet);
            Assert.AreEqual(rover.GetX(),coordinate.X);
            Assert.AreEqual(rover.GetY(), coordinate.Y);
        }

        [TestMethod]
        [DynamicData(nameof(GetRover_FaceData), DynamicDataSourceType.Method)]
        public void RotateTest(IRover rover, string command, string face)
        {
            rover.Rotate(command);
            Assert.AreEqual(rover.GetFace(), face);
        }



        static IEnumerable<object[]> GetRoverData()
        {
            //Arrange
            yield return new object[] { new Rover(new Coordinate(5, 5), "N"), 5 ,5 ,"N" };
            yield return new object[] { new Rover(new Coordinate(4, 2), "S"), 4, 2, "S" };
            yield return new object[] { new Rover(new Coordinate(3, 3), "W"), 3, 3, "W" };
        }

        static IEnumerable<object[]> GetRover_CoordinateData()
        {
            //Arrange
            yield return new object[] { new Rover(new Coordinate(4, 5), "N"), new Coordinate(4, 5), new Planet(new Coordinate(5, 5)) };
            yield return new object[] { new Rover(new Coordinate(4, 2), "S"), new Coordinate(4, 1), new Planet(new Coordinate(6, 6)) };
            yield return new object[] { new Rover(new Coordinate(3, 3), "W"), new Coordinate(2, 3), new Planet(new Coordinate(6, 6)) };
            yield return new object[] { new Rover(new Coordinate(3, 3), "E"), new Coordinate(4, 3), new Planet(new Coordinate(6, 6)) };
        }

        static IEnumerable<object[]> GetRover_FaceData()
        {
            //Arrange
            yield return new object[] { new Rover(new Coordinate(5, 5), "N"), "L", "W" };
            yield return new object[] { new Rover(new Coordinate(4, 2), "S"), "R", "W" };
            yield return new object[] { new Rover(new Coordinate(3, 3), "W"), "R", "N" };
        }


    }
}
