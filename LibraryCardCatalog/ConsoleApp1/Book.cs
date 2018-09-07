using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCardCatalog
{
    [Serializable()] 
    public class Book 
    {
        public string Title { get; set; }
        public string Author { get; set; }
    }
}
