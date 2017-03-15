using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FakeBlog.Models;

namespace FakeBlog.DAL
{
    public class FakeBlogRepository : IRepository
    {
        public FakeBlogContext Context { get; set; }

        public FakeBlogRepository()
        {
            Context = new FakeBlogContext();
        }

        public FakeBlogRepository(FakeBlogContext context)
        {
            Context = context;
        }

        public void AddPost(string Title, ApplicationUser owner)
        {
            Post post = new Post { PostId = 1, Owner = "The Title" };
            Context.Posts.Add(post);
            //Context.SaveChanges();
        }

        public bool EditPost(string postId)
        {
            throw new NotImplementedException();
        }

        public Post GetPost(int postId)
        {
            return Context.Posts.FirstOrDefault(p => p.PostId == postId);
        }

        public List<Post> GetPostsFromUser(string authorId)
        {
            throw new NotImplementedException();
        }

        public bool PublishDraft(string postId)
        {
            throw new NotImplementedException();
        }

        public bool RemovePost(string postId)
        {
            throw new NotImplementedException();
        }
    }
}