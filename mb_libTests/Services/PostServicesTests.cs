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
    public class PostServicesTests
    {

        /*[TestMethod()]
        public void PostDeletedTest()
        {
            var mockSet = new Mock<DbSet<Post>> ();
            var mockContext = new Mock<bloggingContext> ();
            mockContext.Setup(m => m.Posts).Returns(mockSet.Object);

            PostServices ps = new PostServices(mockContext.Object);
            ps.deletePostById(1);
            mockSet.Verify(p => p.)
            Assert.AreEqual(1, isPostDeleted);

        }*/
        [TestMethod()]
        public void PostDeletedFailsTest()
        {
            var postMock = new Mock<IPost>();
            postMock.Setup(p => p.DeletePostById(1)).Returns(1);

            var isPostDeleted = postMock.Object.DeletePostById(2);
            Assert.AreNotEqual(1, isPostDeleted);

        }
        [TestMethod()]

        public void getPostById()
        {
            var data = new List<Post>
            {
                new Post { PostId = 1, PostOwnerId = 100, Post1 = "h" },
                new Post { PostId = 2, PostOwnerId = 200, Post1 = "h" }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Post>>();
            mockSet.As<IQueryable<Post>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Post>>().Setup(m => m.Expression).Returns(data.Expression);
            /*mockSet.As<IQueryable<Post>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Post>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());*/

            var mockContext = new Mock<bloggingContext>();
            mockContext.Setup(c => c.Posts).Returns(mockSet.Object);

            PostServices ps = new PostServices(mockContext.Object);
            var post = ps.GetPostById(1);
            foreach (var p in post)
            {
                Assert.AreEqual(1, p.PostId);
                Assert.AreEqual(100, p.PostOwnerId);
                Assert.IsNotNull(p.Post1);
            }
        }

        [TestMethod()]

        public void getPost()
        {
            var data = new List<Post>
            {
                new Post { PostId = 1, PostOwnerId = 100, Post1 = "h" },
                new Post { PostId = 2, PostOwnerId = 200, Post1 = "h" }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Post>>();
            mockSet.As<IQueryable<Post>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Post>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Post>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Post>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<bloggingContext>();
            mockContext.Setup(c => c.Posts).Returns(mockSet.Object);

            PostServices ps = new PostServices(mockContext.Object);
            var post = ps.GetPost();

            foreach (var p in post)
            {
                Assert.IsNotNull(p.PostId);
                Assert.IsNotNull(p.PostOwnerId);
                Assert.IsNotNull(p.Post1);
            }
        }

    }
}
