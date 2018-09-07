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

        public CardCatalog(string filename)
        {
            _filename = filename;

            //finds folder, checks if file exists, if it doesnt, creates files
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

        //private books; 




       


        public void ListBooks() 
        {
            /*string filename = _filename;
            string text = System.IO.File.ReadAllText(@"C:\Users\jessm\Documents\CodingTemple\Projects\LibraryCardCatalog\LibraryCardCatalog\" + filename);
            System.Console.WriteLine("Contents of WriteText.txt = {0}", text);
            return text;*/

            // Now we can read the serialized book ...  
            System.Xml.Serialization.XmlSerializer reader =
                new System.Xml.Serialization.XmlSerializer(typeof(Book));
            System.IO.StreamReader file = new System.IO.StreamReader(
                @"C:\Users\jessm\Documents" + "//SerializationOverview.xml");
            Book overview = (Book)reader.Deserialize(file);
            file.Close();

            Console.WriteLine(overview.Title);

            Console.ReadLine();
        }
        public void AddBook(string books)
        {
            Console.Clear();
            Console.WriteLine("Please Enter A book Title: ");
            string bookTitle = Console.ReadLine();
            Console.WriteLine("Please Enter The Book's Author: ");
            string author = Console.ReadLine();

            Book overview = new Book();
            overview.Title = bookTitle;
            overview.Author = author;
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(Book));

            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//SerializationOverview.xml";
            System.IO.FileStream file = System.IO.File.Create(path);

            writer.Serialize(file, overview);
            file.Close();

            Console.ReadLine();
        }

        public void Save() { } //prob not void

    }
}
