using FakeBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeBlog.DAL
{
    interface IRepository
    {
        // List of methods to help deliver features
        // Create
        void AddPost(string name, ApplicationUser owner);
        void AddDraft(string name, Author author);
        //void AddList(string name, int boardId);
        //void AddCard(string name, List list, ApplicationUser owner);
        //void AddCard(string name, int listId, string ownerId);

        //// Read
        //List<Card> GetCardsFromList(int listId);
        //List<Card> GetCardsFromBoard(int boardId);
        //Card GetCard(int cardId);
        //List GetList(int listId);
        //List<List> GetListsFromBoard(int boardId); // List of Trello Lists
        //List<Board> GetBoardsFromUser(string userId);
        //Board GetBoard(int boardId);
        //List<ApplicationUser> GetCardAttendees(int cardId);

        //// Update
        //bool AttachUser(string userId, int cardId); // true: successful, false: not successful
        //bool MoveCard(int cardId, int oldListId, int newListId);
        //bool CopyCard(int cardId, int newListId, string newOwnerId);

        //// Delete
        bool RemovePost(int postId);
        //bool RemoveList(int listId);
        //bool RemoveCard(int cardId);
    }
}
