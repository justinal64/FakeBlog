using FakeBlog.Controllers.Published;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FakeBlog.Models;
using System.Data;

namespace FakeBlog.DAL.Repository
{
    public class AuthorRepository : IAuthorManager, IAuthorQuery
    {
        IDbConnection _blogConnection;

        AuthorRepository(IDbConnection blogConnection)
        {
            _blogConnection = blogConnection;
        }
        public void AddAuthor(int authorId, string fullName)
        {
            throw new NotImplementedException();
        }

        public void DeleteAuthor(int authorId)
        {
            throw new NotImplementedException();
        }

        public void EditAuthor(int authorId)
        {
            throw new NotImplementedException();
        }

        public Author GetAuthor(int authorId)
        {
            throw new NotImplementedException();
        }

        public List<Author> GetPostsByAuthor(int authorId)
        {
            throw new NotImplementedException();
        }
    }
}