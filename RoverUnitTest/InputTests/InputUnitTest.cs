using MarsRover.Business.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MarsRoverUnitTest.InputTests
{
    [TestClass]
    public class InputUnitTest
    {
        [TestMethod]
        [DataRow("15 15")]
        [DataRow("5 5")]
        public void IsValid_PlanetInput_Test(string coordinate)
        {
            //Arrange
            CommandManager manager = new CommandManager();

            //Act
            bool Value = manager.IsPlanetBoundValid(coordinate);

            //Assert
            Assert.IsTrue(Value);
        }

        [TestMethod]
        [DataRow("0 0")]
        [DataRow("-1 -1")]
        public void IsNotValid_PlanetInput_Test(string coordinate)
        {
            //Arrange
            CommandManager manager = new CommandManager();

            //Act
            bool Value = manager.IsPlanetBoundValid(coordinate);

            //Assert
            Assert.IsFalse(Value);
        }

        [TestMethod]
        [DataRow("0 4 N")]
        [DataRow("1 6 S")]
        [DataRow("5 2 W")]
        [DataRow("4 4 E")]
        public void IsValid_Rover_Coordinate_Input_Test(string coordinate)
        {
            //Arrange
            CommandManager manager = new CommandManager();

            //Act
            bool Value = manager.IsRoverCoordinatesValid(coordinate);

            //Assert
            Assert.IsTrue(Value);
        }


        [TestMethod]
        [DataRow("0 4 T")]
        [DataRow("16S")]
        [DataRow("5,2,W")]
        [DataRow("A A 1")]
        public void IsNotValid_Rover_Coordinate_Input_Test(string coordinate)
        {
            //Arrange
            CommandManager manager = new CommandManager();

            //Act
            bool Value = manager.IsRoverCoordinatesValid(coordinate);

            //Assert
            Assert.IsFalse(Value);
        }


        [TestMethod]
        [DataRow("LRLRLRMRMLRLR")]
        [DataRow("RRRRRRRRRRRRR")]
        [DataRow("LLLLLLLLLLLLL")]
        [DataRow("MRLRMRLRMLRML")]
        public void IsValid_Rover_Command_Input_Test(string coordinate)
        {
            //Arrange
            CommandManager manager = new CommandManager();

            //Act
            bool Value = manager.IsRoverCommandsValid(coordinate);

            //Assert
            Assert.IsTrue(Value);
        }


        [TestMethod]
        [DataRow("LRLRLRMAMLRLR")]
        [DataRow("AAAAAAAAAAAAA")]
        [DataRow("0000000000000")]
        [DataRow("L R M L RM LR")]
        public void IsNotValid_Rover_Command_Input_Test(string coordinate)
        {
            //Arrange
            CommandManager manager = new CommandManager();

            //Act
            bool Value = manager.IsRoverCommandsValid(coordinate);

            //Assert
            Assert.IsFalse(Value);
        }

    }
}
