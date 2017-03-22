using FakeBlog.Controllers.Published;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FakeBlog.Models;

namespace FakeBlog.DAL.Repository
{
    public class PostRepository : IPostManager, IPostQuery
    {
        public void AddPost(int boardId, string title)
        {
            throw new NotImplementedException();
        }

        public void DeletePost(int boardId)
        {
            throw new NotImplementedException();
        }

        public void EditPost(int boardId)
        {
            throw new NotImplementedException();
        }

        public Post GetPost(int postId)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetPostsByUser(int authorId)
        {
            throw new NotImplementedException();
        }
    }
}