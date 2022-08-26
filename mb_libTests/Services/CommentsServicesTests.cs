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
    public class CommentsServicesTests
    {
        [TestMethod()]
        public void addCommentsTest()
        {
            var mockSet = new Mock<DbSet<Comment>>();
            var mockContext = new Mock<bloggingContext>();
            mockContext.Setup(m => m.Comments).Returns(mockSet.Object);

            mockSet.Setup(c => c.Add(It.IsAny<Comment>()));
            CommentsServices cs = new CommentsServices(mockContext.Object);

            bool result = cs.AddComments(1, 2, "h");
            mockSet.Verify(c => c.Add(It.IsAny<Comment>()), Times.Once());
            
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
            
        }

    }
}