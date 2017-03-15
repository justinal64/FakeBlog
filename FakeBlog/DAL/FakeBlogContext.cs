﻿using FakeBlog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FakeBlog.DAL
{
    public class FakeBlogContext
    {
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
    }
}