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
    public class CommentsServicesTests
    {
        [TestMethod()]
        public void addCommentsTest()
        {
            var commentMock = new Mock<Icomments>();

            commentMock.Setup(c => c.addComments(1, 10, "yes")).Returns(true);

            var isCommentsAdded = commentMock.Object.addComments(1, 10, "yes");
            Assert.IsTrue(isCommentsAdded); 
        }

        [TestMethod()]
        public void addCommentsFailsTest()
        {
            var commentMock = new Mock<Icomments>();

            commentMock.Setup(c => c.addComments(1, 10, "yes")).Returns(true);

            var isCommentsAdded = commentMock.Object.addComments(1, 1, "yes");
            Assert.IsFalse(isCommentsAdded);
        }
    }
}