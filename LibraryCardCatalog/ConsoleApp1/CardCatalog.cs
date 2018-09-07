using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace LibraryCardCatalog
{
    class CardCatalog
    {
        private string _filename;
        //private books;

  
        List<Book> Books = new List<Book>();

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

        public void ListBooks(string books) 
        {
            //------UI START------
            Console.Clear();
            Console.WriteLine("Here is a complete List of Books In List: \n\n");


            //------UI END------
            string filename;
            filename = _filename;
            try
            {
                System.Xml.Serialization.XmlSerializer reader =
                new System.Xml.Serialization.XmlSerializer(typeof(Book));
                System.IO.StreamReader file = new System.IO.StreamReader(
                    @"C:\Users\jessm\Documents\CodingTemple\Projects\LibraryCardCatalog\Library Card Data\" + filename);
                Book overview = (Book)reader.Deserialize(file);
                file.Close();

                Console.WriteLine(overview.Title + "\n" + overview.Author);
            }
            catch (Exception)
            {
                Console.WriteLine("this list contains no books. Please adds books from the main menu!");

            }
            Console.ReadLine();
        }


        public void AddBook(string books)
        {
            //------UI START------
            Console.Clear();
            Console.WriteLine("Please Enter A book Title: ");
            string bookTitle = Console.ReadLine();
            Console.WriteLine("Please Enter The Book's Author: ");
            string author = Console.ReadLine();
            //------UI END------


            string filename;
            filename = _filename;

            Book overview = new Book();
            overview.Title = bookTitle;
            overview.Author = author;
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(Book));


            string folderName = @"C:\Users\jessm\Documents\CodingTemple\Projects\LibraryCardCatalog\";
            string pathString = System.IO.Path.Combine(folderName, "Library Card Data");
            pathString = System.IO.Path.Combine(pathString, filename);
         
            System.IO.FileStream file = System.IO.File.Create(pathString);

            writer.Serialize(file, overview);
            file.Close();

            Console.ReadLine();
        }

        public void Save() { } //prob not void

    }
}
