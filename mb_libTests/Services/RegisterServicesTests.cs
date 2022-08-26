using Microsoft.VisualStudio.TestTools.UnitTesting;
using mb_lib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mb_lib.Interface;
using Moq;
using Microsoft.EntityFrameworkCore;

namespace mb_lib.Services.Tests
{
    [TestClass()]
    public class RegisterServicesTests
    {
        [TestMethod()]
        public void SuccessfullLoginTest()
        {
            var data = new List<Register>
            {
                new Register {  Email = "a@g.com", Password = "a", Name = "a" },
                new Register {  Email = "b@g.com", Password = "b", Name = "b" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Register>>();
            mockSet.As<IQueryable<Register>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Register>>().Setup(m => m.Expression).Returns(data.Expression);

            var mockContext = new Mock<bloggingContext>();
            mockContext.Setup(c => c.Registers).Returns(mockSet.Object);

            RegisterServices rs = new RegisterServices(mockContext.Object);
            var login = rs.Login("a@g.com", "a");
            Assert.IsTrue(login);
        }
        [TestMethod()]
        public void UnSuccessfullLoginTest()
        {
            var data = new List<Register>
            {
                new Register {  Email = "a@g.com", Password = "a", Name = "a" },
                new Register {  Email = "b@g.com", Password = "b", Name = "b" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Register>>();
            mockSet.As<IQueryable<Register>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Register>>().Setup(m => m.Expression).Returns(data.Expression);

            var mockContext = new Mock<bloggingContext>();
            mockContext.Setup(c => c.Registers).Returns(mockSet.Object);

            RegisterServices rs = new RegisterServices(mockContext.Object);
            var login = rs.Login("ap@gmail.com", "a");
            Assert.IsFalse(login);
        }


    }
}