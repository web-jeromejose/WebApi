using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpensesAPI.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
      
        public ICollection<BookCategory> BookCategories { get; set; }
    }
}