using Microsoft.VisualStudio.TestTools.UnitTesting;
using microblog.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mb_lib.Interface;
using Moq;
using Microsoft.AspNetCore.Mvc;
using mb_lib;

namespace microblog.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {

        [TestMethod()]
        public void CommentsTest()
        {
            var commentMock = new Mock<Icomments>();
            var postMock = new Mock<Ipost>();
            var registerMpck = new Mock<Iregister>();
            postMock.Setup(p => p.getPostById(It.IsAny<int>())).Returns(new List<Post>
            {
               new Post
               {
                   PostId = 2,
                   PostOwnerId = 100,
               }
            });
            HomeController hc = new HomeController(postMock.Object, commentMock.Object, registerMpck.Object);

            var commentsResult = hc.Comments(999);
           Assert.IsInstanceOfType(commentsResult, typeof(ViewResult));
        }
    }
}