using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceManager.DAL
{
    public class BookContext : DbContext
    {
        public BookContext() : base("ReferenceDB") { }

        public DbSet<Author> Authors { get; set; }
    }
}
