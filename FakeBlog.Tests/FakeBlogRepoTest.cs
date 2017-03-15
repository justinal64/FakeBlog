using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakeBlog.DAL;
using Moq;
using FakeBlog.Models;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace FakeBlog.Tests.DAL
{
    [TestClass]
    public class FakeTrelloRepoTests
    {
        public Mock<FakeBlogContext> fakeContext { get; set; }
        public FakeBlogRepository repo { get; set; }
        public Mock<DbSet<Post>> mockPostSet { get; set; }
        public IQueryable<Post> queryPost { get; set; }
        public List<Post> fakePostTable { get; set; }
        public ApplicationUser sally { get; set; }
        public ApplicationUser sammy { get; set; }

        [TestInitialize]
        public void Setup()
        {
            fakePostTable = new List<Post>();
            fakeContext = new Mock<FakeBlogContext>();
            mockPostSet = new Mock<DbSet<Post>>();
            repo = new FakeBlogRepository(fakeContext.Object);
            sally = new ApplicationUser { Id = "sally-id-1" };
            sammy = new ApplicationUser { Id = "sammy-id-1" };
        }

        public void CreateFakeDatabase()
        {
            queryPost = fakePostTable.AsQueryable(); // Re-express this list as something that understands queries

            //// Hey LINQ, use the Provider from our *cough* fake *cough* board table/list
            mockPostSet.As<IQueryable<Post>>().Setup(b => b.Provider).Returns(queryPost.Provider);
            mockPostSet.As<IQueryable<Post>>().Setup(b => b.Expression).Returns(queryPost.Expression);
            mockPostSet.As<IQueryable<Post>>().Setup(b => b.ElementType).Returns(queryPost.ElementType);
            mockPostSet.As<IQueryable<Post>>().Setup(b => b.GetEnumerator()).Returns(() => queryPost.GetEnumerator());

            mockPostSet.Setup(b => b.Add(It.IsAny<Post>())).Callback((Post post) => fakePostTable.Add(post));
            mockPostSet.Setup(b => b.Remove(It.IsAny<Post>())).Callback((Post post) => fakePostTable.Remove(post));

            fakeContext.Setup(c => c.Posts).Returns(mockPostSet.Object); // Context.Boards returns fakeBoardTable (a list)
        }

        [TestMethod]
        public void EnsureICanCreateInstanceofRepo()
        {
            FakeBlogRepository repo = new FakeBlogRepository();

            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void EnsureIHaveNotNullContext()
        {
            FakeBlogRepository repo = new FakeBlogRepository();

            Assert.IsNotNull(repo.Context);
        }

        [TestMethod]
        public void EnsureICanInjectContextInstance()
        {
            FakeBlogContext context = new FakeBlogContext();
            FakeBlogRepository repo = new FakeBlogRepository(context);

            Assert.IsNotNull(repo.Context);
        }

        [TestMethod]
        public void EnsureICanAddPost()
        {
            // Arrange
            CreateFakeDatabase();

            ApplicationUser aUser = new ApplicationUser {
                Id = "my-user-id",
                UserName = "Sammy",
                Email = "sammy@gmail.com"
            };

            // Act
            repo.AddPost("My Board", aUser);

            //// Assert
            Assert.AreEqual(1, repo.Context.Posts.Count());
        }

        [TestMethod]
        public void EnsureICanReturnPost()
        {
            // Arrange
            fakePostTable.Add(new Post { PostId = 1, Owner = "Justin Leggett" });
            CreateFakeDatabase();

            // Act
            int expectedBoardCount = 1;
            int actualBoardCount = repo.Context.Posts.Count();

            // Assert
            Assert.AreEqual(expectedBoardCount, actualBoardCount);
        }

        [TestMethod]
        public void EnsureICanFindAPost()
        {
            // Arrange
            fakePostTable.Add(new Post { PostId = 1, Owner = "Justin Leggett" });
            CreateFakeDatabase();

            // Act
            string expectedBoardName = "Justin Leggett";
            Post actualPost = repo.GetPost(1);
            string actualBoardName = repo.GetPost(1).Owner;

            Assert.IsNotNull(actualPost);
            Assert.AreEqual(expectedBoardName, actualBoardName);
        }

        [TestMethod]
        public void EnsureICanGetUserPosts()
        {
            // Arrange
            fakePostTable.Add(new Post { PostId = 1, Owner = "Justin Leggett" });
            fakePostTable.Add(new Post { PostId = 2, Owner = "Justin Leggett" });
            fakePostTable.Add(new Post { PostId = 3, Owner = "Justin Leggett" });
            CreateFakeDatabase();
            // Act 
            int expectedBoardCount = 3;
            int actualBoardCount = repo.GetPostsFromUser(sally.Id).Count();

            // Assert
            Assert.AreEqual(expectedBoardCount, actualBoardCount);
        }

        //[TestMethod]
        //public void EnsureICanRemoveBoard()
        //{
        //    // Arrange
        //    fakeBoardTable.Add(new Board { BoardId = 1, Name = "My Board", Owner = sally });
        //    fakeBoardTable.Add(new Board { BoardId = 2, Name = "My Board", Owner = sally });
        //    fakeBoardTable.Add(new Board { BoardId = 3, Name = "My Board", Owner = sammy });
        //    CreateFakeDatabase();

        //    // Act
        //    int expectedBoardCount = 2;
        //    repo.RemoveBoard(3);
        //    int actualBoardCount = repo.Context.Boards.Count();

        //    // Assert
        //    Assert.AreEqual(expectedBoardCount, actualBoardCount);
        //}
    }
}

