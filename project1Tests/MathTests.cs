using Microsoft.VisualStudio.TestTools.UnitTesting;
using project1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1.Tests
{
    [TestClass()]
    public class MathTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            Math m = new Math();
            int num1 = 2;
            int num2 = 2;
            int expected = 4;
            //Act
            int addResult = m.Add(num1, num2);
            //Assert
            Assert.AreEqual(expected, addResult);
        }

        [TestMethod()]

        public void Multiple()
        {
            Math m = new Math();
            int num1 = 47000;
            int num2 = 47000;
            int expected = 4;


            int result = m.Multiple(num1, num2);

            Assert.AreEqual(expected, result); 
        }

       
    }
}