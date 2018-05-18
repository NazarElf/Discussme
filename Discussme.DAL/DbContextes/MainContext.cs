﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Discussme.DAL.Entities;

namespace Discussme.DAL.DbContextes
{
    class MainContext : DbContext
    {

        public MainContext(string connectionString) : base(connectionString) { }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
