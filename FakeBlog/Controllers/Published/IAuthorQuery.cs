using FakeBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeBlog.Controllers.Published
{
    interface IAuthorQuery
    {
        List<Author> GetPostsByAuthor(int authorId);
        Author GetAuthor(int authorId);
    }
}
