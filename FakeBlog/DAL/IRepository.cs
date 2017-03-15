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
        void AddPost(string Title, ApplicationUser owner);

        // Read
        Post GetPost(int postId);
        List<Post> GetPostsFromUser(string authorId);

        // Update
        bool EditPost(string postId); // true: successful, false: not successful
        bool PublishDraft(string postId);

        // Delete
        bool RemovePost(string postId);
    }
}