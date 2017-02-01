﻿using ReferenceManager.DAL;
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
    }
}