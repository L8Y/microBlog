using Microsoft.VisualStudio.TestTools.UnitTesting;
using mb_lib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mb_lib.Interface;
using Moq;

namespace mb_lib.Services.Tests
{
    [TestClass()]
    public class RegisterServicesTests
    {
        [TestMethod()]
        public void getUserIdTest()
        {
            var registerMock = new Mock<Iregister>();
            registerMock.Setup(m => m.getUserId("abc@g.com")).Returns(1);
            
            var registerResult = registerMock.Object.getUserId("abc@g.com");
            Assert.AreEqual(1, registerResult);
        }

        [TestMethod()]
        public void getUseridIfitIsGivenWrongTest()
        {
            var registerMock = new Mock<Iregister>();
            registerMock.Setup(m => m.getUserId("abc@g.com")).Returns(1);

            var registerResult = registerMock.Object.getUserId("bc@g.com");
            Assert.AreEqual(0, registerResult);
        }


        [TestMethod()]
        public void checkUseridIsNotNullTest()
        {
            var registerMock = new Mock<Iregister>();
            registerMock.Setup(m => m.getUserId("abc@g.com")).Returns(1);

            var registerResult = registerMock.Object.getUserId("abc@g.com");
            Assert.IsNotNull(registerResult);
        }

        [TestMethod()]

        public void loginTest()
        {
            var registerMock = new Mock<Iregister>();
            registerMock.Setup(m => m.login("abc@g.com", "ab")).Returns(true);
            var loginResult = registerMock.Object.login("abc@g.com", "ab");
            Assert.IsTrue(loginResult); 
        }
        [TestMethod()]

        public void loginFailTest()
        {
            var registerMock = new Mock<Iregister>();
            registerMock.Setup(m => m.login("abc@g.com", "ab")).Returns(true);
            var loginResult = registerMock.Object.login("bc@g.com", "ab");
            Assert.IsFalse(loginResult);
        }
        [TestMethod()]
        public void registerNewUser()
        {
            var registerMock = new Mock<Iregister>();
            registerMock.Setup(m => m.add_user(It.IsAny<Register>())).Returns(1);
            Register r = new Register()
            {
                UserId = 1,
                Name = "ar",
                Email = "aa@gmail.com",
                Password = "aa"
                
            };
            int isuserCreated = registerMock.Object.add_user(r);
            Assert.AreEqual(1, isuserCreated);
        }

        [TestMethod()]
        public void registerNewUserFails()
        {
            var registerMock = new Mock<Iregister>();
            registerMock.Setup(m => m.add_user(It.IsAny<Register>())).Returns(0);
            Register r = new Register()
            {
                UserId = 1,
                Name = "ar",
                Email = "aa@gmail.com"

            };
            int isuserCreated = registerMock.Object.add_user(r);
            Assert.AreEqual(0, isuserCreated);
        }

    }
}