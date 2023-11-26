using Microsoft.EntityFrameworkCore;
using NotebookforContacts1.Database;
using NotebookforContacts1.Models;
using System.Numerics;

namespace NotebookforContacts1.Database
{
    public class NotebookContext1 : DbContext
    {
        public DbSet<Notebook> notebooks { get; set; }

        public NotebookContext1(DbContextOptions<NotebookContext1> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
