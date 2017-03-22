using FakeBlog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FakeBlog.DAL
{
    public class FakeBlogContext : ApplicationDbContext
    {
        public virtual DbSet<Author> authors { get; set; }
        public virtual DbSet<Post> posts { get; set; }
    }
}