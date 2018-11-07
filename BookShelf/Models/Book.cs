﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShelf.Models
{
    public class Book
    {
        static int counter = 0;
        public int Id { get; set; }
        public string Title { get; set; }
        public int? AuthorId { get; set; }

        public Book(string title, int? authorId = null)
        {
            this.Id = counter++;
            this.Title = title;
            this.AuthorId = authorId;
        }
    }
}