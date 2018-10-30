using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookShelfBusinessLogic
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
    }
}
