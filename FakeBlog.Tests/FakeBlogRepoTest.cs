using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakeBlog.DAL;
using Moq;
using FakeBlog.Models;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace FakeTrello.Tests.DAL
{
    [TestClass]
    public class FakeTrelloRepoTests
    {
        public Mock<FakeBlogContext> fakeContext { get; set; }
        public FakeBlogRepository repo { get; set; }
        public Mock<DbSet<Post>> mockPostsSet { get; set; }
        public ApplicationUser sally { get; set; }
        public ApplicationUser sammy { get; set; }

        [TestInitialize]
        public void Setup()
        {
            //fakeBoardTable = new List<Post>();
            //fakeContext = new Mock<FakeTrelloContext>();
            //mockBoardsSet = new Mock<DbSet<Board>>();
            //repo = new FakeTrelloRepository(fakeContext.Object);
            //sally = new ApplicationUser { Id = "sally-id-1" };
            //sammy = new ApplicationUser { Id = "sammy-id-1" };
        }

        public void CreateFakeDatabase()
        {
            //queryBoards = fakeBoardTable.AsQueryable(); // Re-express this list as something that understands queries

            //// Hey LINQ, use the Provider from our *cough* fake *cough* board table/list
            //mockBoardsSet.As<IQueryable<Board>>().Setup(b => b.Provider).Returns(queryBoards.Provider);
            //mockBoardsSet.As<IQueryable<Board>>().Setup(b => b.Expression).Returns(queryBoards.Expression);
            //mockBoardsSet.As<IQueryable<Board>>().Setup(b => b.ElementType).Returns(queryBoards.ElementType);
            //mockBoardsSet.As<IQueryable<Board>>().Setup(b => b.GetEnumerator()).Returns(() => queryBoards.GetEnumerator());

            //mockBoardsSet.Setup(b => b.Add(It.IsAny<Board>())).Callback((Board board) => fakeBoardTable.Add(board));
            //mockBoardsSet.Setup(b => b.Remove(It.IsAny<Board>())).Callback((Board board) => fakeBoardTable.Remove(board));

            //fakeContext.Setup(c => c.Boards).Returns(mockBoardsSet.Object); // Context.Boards returns fakeBoardTable (a list)
        }

        [TestMethod]
        public void EnsureICanCreateInstanceofRepo()
        {
            //FakeTrelloRepository repo = new FakeTrelloRepository();

            //Assert.IsNotNull(repo);
        }

        //[TestMethod]
        //public void EnsureIHaveNotNullContext()
        //{
        //    FakeTrelloRepository repo = new FakeTrelloRepository();

        //    Assert.IsNotNull(repo.Context);
        //}

        //[TestMethod]
        //public void EnsureICanInjectContextInstance()
        //{
        //    FakeTrelloContext context = new FakeTrelloContext();
        //    FakeTrelloRepository repo = new FakeTrelloRepository(context);

        //    Assert.IsNotNull(repo.Context);
        //}

        //[TestMethod]
        //public void EnsureICanAddBoard()
        //{
        //    // Arrange
        //    CreateFakeDatabase();

        //    ApplicationUser a_user = new ApplicationUser
        //    {
        //        Id = "my-user-id",
        //        UserName = "Sammy",
        //        Email = "sammy@gmail.com"
        //    };

        //    // Act
        //    repo.AddBoard("My Board", a_user);

        //    // Assert
        //    Assert.AreEqual(1, repo.Context.Boards.Count());
        //}

        //[TestMethod]
        //public void EnsureICanReturnBoards()
        //{
        //    // Arrange
        //    fakeBoardTable.Add(new Board { Name = "My Board" });
        //    CreateFakeDatabase();

        //    // Act
        //    int expected_board_count = 1;
        //    int actual_board_count = repo.Context.Boards.Count();

        //    // Assert
        //    Assert.AreEqual(expected_board_count, actual_board_count);
        //}

        //[TestMethod]
        //public void EnsureICanFindABoard()
        //{
        //    // Arrange
        //    fakeBoardTable.Add(new Board { BoardId = 1, Name = "My Board" });
        //    CreateFakeDatabase();

        //    // Act
        //    string expected_board_name = "My Board";
        //    Board actual_board = repo.GetBoard(1);
        //    string actual_board_name = repo.GetBoard(1).Name;

        //    // Assert
        //    Assert.IsNotNull(actual_board);
        //    Assert.AreEqual(expected_board_name, actual_board_name);
        //}

        //[TestMethod]
        //public void EnsureICanGetUserBoards()
        //{
        //    // Arrange
        //    fakeBoardTable.Add(new Board { BoardId = 1, Name = "My Board", Owner = sally });
        //    fakeBoardTable.Add(new Board { BoardId = 2, Name = "My Board", Owner = sally });
        //    fakeBoardTable.Add(new Board { BoardId = 3, Name = "My Board", Owner = sammy });
        //    CreateFakeDatabase();
        //    // Act 
        //    int expectedBoardCount = 2;
        //    int actualBoardCount = repo.GetBoardsFromUser(sally.Id).Count();

        //    // Assert
        //    Assert.AreEqual(expectedBoardCount, actualBoardCount);
        //}

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

