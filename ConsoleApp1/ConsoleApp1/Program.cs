using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCardCatalog
{
    class CardCatalog
    {
        //private string books;

        static void Main(string[] args)
        {
            SetFileName();
            ListBooks();

            /*MainMenu();

            bool displayMenu = true;
            while (displayMenu)
            {
                displayMenu = MainMenu();
            }*/

            Console.ReadLine();
        }


        //string folderName = @"C:\Users\jessm\Documents\CodingTemple\Projects\LibraryCardCatalog\LibraryCardCatalog";
        private static string _filename(string Username)
        {
            Console.WriteLine("Welcome, Please enter a username: ");
            Username = (Console.ReadLine() + ".txt");
            return Username;

        }
        private static void SetFileName()
        {

            string folderName = @"C:\Users\jessm\Documents\CodingTemple\Projects\LibraryCardCatalog\LibraryCardCatalog";
            string pathString = System.IO.Path.Combine(folderName, "Library Card Data");
            System.IO.Directory.CreateDirectory(pathString);
            string fileName = _filename();
            pathString = System.IO.Path.Combine(pathString, fileName);
            //Console.WriteLine("Path to my file: {0}\n", pathString);

            if (!System.IO.File.Exists(pathString))
            {
                using (System.IO.FileStream fs = System.IO.File.Create(pathString)) { }
            }
            else
            {
                byte[] readBuffer = System.IO.File.ReadAllBytes(pathString); //comeback to this part
                return;
            }

            // Read and display the data from your file.
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
            }


        }
        /* private static bool MainMenu()
        {
            Console.Clear();

            Console.WriteLine("Greetings, \n\n");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1) List All Books");
            Console.WriteLine("2) Add a Book");
            Console.WriteLine("3) Save and Exit");

            string result = Console.ReadLine();
            if (result == "1")
            {
                CardCatalog cardCatalog = new CardCatalog();
                return true;
            }
            if (result == "2")
            {


                return true;
            }
            if (result == "3")
            {
                Save();
                return true;
            }
            else
            {
                return false;
            }
        }*/

        public CardCatalog(string filename)
        {
            

        }
        public static string ListBooks() //prob not void
        {

            string text = System.IO.File.ReadAllText(@"C:\Users\jessm\Documents\CodingTemple\Projects\LibraryCardCatalog\LibraryCardCatalog\" + _filename);
            System.Console.WriteLine("Contents of WriteText.txt = {0}", text);
            return text;


        }
        public void AddBook(string books)
        {
           
            Console.WriteLine("Please Enter the Book's Title: ");

            Console.ReadLine();
        }
       
        public void Save() { } //prob not void

    }

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }


    }

}
