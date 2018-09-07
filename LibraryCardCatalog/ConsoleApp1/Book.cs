using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCardCatalog
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        /*
        public DateTime Published {get; set;}
        public static int Count { get; set; }

        public Book(string title, string author, DateTime published)
        {
            Title = title;
            Author = author;
            Published = published;
            Count++;
        }*/
    }
}
