using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeBlog.Controllers.Published
{
    interface IAuthorManager
    {
        void AddAuthor(int authorId, string fullName);
        void EditAuthor(int authorId);
        void DeleteAuthor(int authorId);
    }
}
