using FakeBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeBlog.Controllers.Published
{
    interface IPostQuery
    {
        List<Post> GetPostsByUser(int authorId);
        Post GetPost(int postId);
    }
}
