using MarsRover.Business;
using MarsRover.Business.Entities;
using MarsRover.Business.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MarsRoverUnitTest.PlanetTest
{
    [TestClass]
    public class PlanetUnitTest
    {       


        [TestMethod]
        [DynamicData(nameof(GetValidPlanetRoverData), DynamicDataSourceType.Method)]
        
        public void IsValid_RoverPlanet_InputTest(Planet planet, IRover rover )
        {                       
            //Act
            bool Value = planet.IsRoverValid(rover); 

            //Assert
            Assert.IsTrue(Value);
        }


        [TestMethod]
        [DynamicData(nameof(GetInvalidPlanetRoverData), DynamicDataSourceType.Method)]

        public void IsNotValid_RoverPlanet_InputTest(Planet planet, IRover rover)
        {
            //Act
            bool Value = planet.IsRoverValid(rover);

            //Assert
            Assert.IsFalse(Value);
        }


        [TestMethod]
        [DynamicData(nameof(GetValidPlanetRoverData), DynamicDataSourceType.Method)]

        public void IsRoverInsertedToPlanet_Test(Planet planet, IRover rover)
        {
            //Act
            planet.InsertRover(rover);

            //Assert
            Assert.IsTrue(planet.Rovers.Contains(rover));
        }


        static IEnumerable<object[]> GetValidPlanetRoverData()
        {
            //Arrange
            yield return new object[]{ new Planet(new Coordinate(5,5)), new Rover(new Coordinate(5,5),"N") };
            yield return new object[] { new Planet(new Coordinate(10, 10)), new Rover(new Coordinate(4, 2), "S") };
            yield return new object[] { new Planet(new Coordinate(6, 6)), new Rover(new Coordinate(3, 3), "W") };
        }


        static IEnumerable<object[]> GetInvalidPlanetRoverData()
        {
            //Arrange
            yield return new object[] { new Planet(new Coordinate(5, 5)), new Rover(new Coordinate(-1, -1), "N") };
            yield return new object[] { new Planet(new Coordinate(5, 5)), new Rover(new Coordinate(6, 6), "N") };
            yield return new object[] { new Planet(new Coordinate(8, 8)), new Rover(new Coordinate(3, 3), "T") };
            yield return new object[] { new Planet(new Coordinate(4, 4)), new Rover(new Coordinate(3, 3), "A") };
        }



    }
}
