using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace LibraryCardCatalog
{
    class CardCatalog
    {
        private string _filename;
        

        public CardCatalog(string filename)
        {
            _filename = filename;

            string folderName = @"C:\Users\jessm\Documents\CodingTemple\Projects\LibraryCardCatalog\";
            string pathString = System.IO.Path.Combine(folderName, "Library Card Data");
            System.IO.Directory.CreateDirectory(pathString);
            pathString = System.IO.Path.Combine(pathString, filename);

            if (!System.IO.File.Exists(pathString))
            {
                using (System.IO.FileStream fs = System.IO.File.Create(pathString)) { }
            }
            else
            {
                byte[] readBuffer = System.IO.File.ReadAllBytes(pathString); //comeback to this part
            }

            /* // Read and display the data from your file.
            try
            {
                byte[] readBuffer = System.IO.File.ReadAllBytes(pathString); //write bytes in order to read bytes
                foreach (byte b in readBuffer)
                {
                    Console.Write(b + " ");
                }
                Console.WriteLine();
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);
            }*/

        }

        public void ListBooks()
        {
            //------UI START------
            Console.Clear();
            Console.WriteLine("Here is a complete List of Books In List: \n\n");


            string filename;
            //------UI END------
            filename = _filename;

            System.Xml.Serialization.XmlSerializer reader =
            new System.Xml.Serialization.XmlSerializer(typeof(List<Book>));
            System.IO.StreamReader file = new System.IO.StreamReader(
                @"C:\Users\jessm\Documents\CodingTemple\Projects\LibraryCardCatalog\Library Card Data\" + filename);
            List<Book> bookList = (List<Book>)reader.Deserialize(file);
            file.Close();


            Console.WriteLine(bookList);

           /* foreach (Book b in bookList) {
                Console.WriteLine(bookList.ToString());
            }*/
        }
            
            
           
      
        }


        public void AddBook(string books)
        {
            //------UI START------
            Console.Clear();
            Console.WriteLine("Please Enter A book Title: ");
            string bookTitle = Console.ReadLine();

            Console.WriteLine("Please Enter The Book's Author: ");
            string author = Console.ReadLine();

            Console.WriteLine("Please Enter The Published Year: ");
            int published = int.Parse(Console.ReadLine());
            //------UI END------
           
        string filename;
            filename = _filename;

            List<Book> bookList = new List<Book>();
            bookList.Add(new Book {Title = bookTitle, Author= author, Published= published });
           


            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(List<Book>));

            string folderName = @"C:\Users\jessm\Documents\CodingTemple\Projects\LibraryCardCatalog\";
            string pathString = System.IO.Path.Combine(folderName, "Library Card Data");
            pathString = System.IO.Path.Combine(pathString, filename);
         
            System.IO.FileStream file = System.IO.File.Create(pathString);

            writer.Serialize(file, bookList);
            file.Close();

            Console.ReadLine();
        }

        public void Save() { } //prob not void

    }
}
