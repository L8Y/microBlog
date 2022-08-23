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
    public class PostServicesTests
    {
        [TestMethod()]
        public void PostDeletedTest()
        {
            var postMock = new Mock<Ipost>();
            postMock.Setup(p => p.deletePostById(1)).Returns(1);

            var isPostDeleted = postMock.Object.deletePostById(1);
            Assert.AreEqual(1, isPostDeleted);

        }
        [TestMethod()]
        public void PostDeletedFailsTest()
        {
            var postMock = new Mock<Ipost>();
            postMock.Setup(p => p.deletePostById(1)).Returns(1);

            var isPostDeleted = postMock.Object.deletePostById(2);
            Assert.AreNotEqual(1, isPostDeleted);

        }
        [TestMethod()]

        public void CreatePost()
        {
            DateTime date = DateTime.Now;
            var postMock = new Mock<Ipost>();
            postMock.Setup(p => p.createPost(It.IsAny<string>(),It.IsAny<string>(),It.IsAny<int>(),It.IsAny<DateTime>())).Returns(1);
            var isPostCreated = postMock.Object.createPost("hi", "asd", 1, date );
            Assert.AreEqual(1, isPostCreated);

        }

        [TestMethod()]

        public void CreatePostFails()
        {
            DateTime date = DateTime.Now;
            var postMock = new Mock<Ipost>();
            postMock.Setup(p => p.createPost(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<DateTime>())).Returns(0);
            var isPostCreated = postMock.Object.createPost("hi", "asd", 1, date);
            Assert.AreNotEqual(1, isPostCreated);

        }



    }
}