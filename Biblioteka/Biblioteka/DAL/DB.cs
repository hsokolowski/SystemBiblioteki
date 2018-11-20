using Biblioteka.App_Start;
using Biblioteka.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Biblioteka.DAL
{
    public class DB : DbContext
    {
        public DB() : base("MyDB")
        {
            
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Borrowing> Borrowings { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Penalty> Penalties { get; set; }
        public DbSet<Queue> Queues { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<FileBook> Files { get; set; }
        public DbSet<AutBook> AutBooks { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Specimen> Specimens { get; set; }

    }
}