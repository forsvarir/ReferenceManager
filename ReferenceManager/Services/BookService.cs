using ReferenceManager.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceManager.Services
{
    public interface IBookService
    {
        void AddAuthor(Author author);
        List<Author> FindAuthors();
        void AddLocation(Location location);
        List<Location> FindLocations();
        void AddPublisher(Publisher publishers);
        List<Publisher> FindPublishers();
    }

    public class BookService : IBookService
    {
        public void AddAuthor(Author author)
        {
            using (var db = new BookContext())
            {
                db.Authors.Add(author);
                db.SaveChanges();
            }
        }

        public void AddLocation(Location location)
        {
            using (var db = new BookContext())
            {
                db.Locations.Add(location);
                db.SaveChanges();
            }
        }

        public void AddPublisher(Publisher publisher)
        {
            using (var db = new BookContext())
            {
                db.Publishers.Add(publisher);
                db.SaveChanges();
            }
        }

        public List<Author> FindAuthors()
        {
            using(var db = new BookContext())
            {
                return db.Authors.ToList();
            }
        }

        public List<Location> FindLocations()
        {
            using (var db = new BookContext())
            {
                return db.Locations.ToList();
            }
        }

        public List<Publisher> FindPublishers()
        {
            using (var db = new BookContext())
            {
                return db.Publishers.ToList();
            }
        }
    }
}
