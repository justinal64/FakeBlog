using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeBlog.Controllers.Published
{
    interface IPostManager
    {
        void AddPost(int boardId, string title);
        void EditPost(int boardId);
        void DeletePost(int boardId);
    }
}
