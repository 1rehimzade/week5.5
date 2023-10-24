//using System;
//using System.Collections.Generic;

//class ProgrammingLanguage
//{
//    public string Name { get; set; }
//    public int YearCreated { get; set; }
//}

//class Program
//{
//    static void Main()
//    {
//        List<ProgrammingLanguage> programmingLanguages = new List<ProgrammingLanguage>();


//        programmingLanguages.Add(new ProgrammingLanguage { Name = "C", YearCreated = 1972 });
//        programmingLanguages.Add(new ProgrammingLanguage { Name = "C++", YearCreated = 1983 });
//        programmingLanguages.Add(new ProgrammingLanguage { Name = "Java", YearCreated = 1995 });
//        programmingLanguages.Add(new ProgrammingLanguage { Name = "Python", YearCreated = 1989 });
//        programmingLanguages.Add(new ProgrammingLanguage { Name = "JavaScript", YearCreated = 1995 });
//        programmingLanguages.Add(new ProgrammingLanguage { Name = "C#", YearCreated = 2000 });


//        programmingLanguages.Sort((a, b) => a.YearCreated.CompareTo(b.YearCreated));


//        Console.WriteLine("Programlama Dilleri ve Yaratıldıgi Iller:");
//        foreach (var language in programmingLanguages)
//        {
//            Console.WriteLine($"{language.Name} - {language.YearCreated}");
//        }
//    }
//}

using System;
using System.Collections.Generic;

class Item
{
    public string Name { get; protected set; }

    public Item(string name)
    {
        Name = name;
    }
}

class Library : Item
{
    public List<Book> Books { get; } = new List<Book>();

    public Library(string name) : base(name)
    {
    }

    public void AddBook(Book book)
    {
        Books.Add(book);
        Console.WriteLine($"Added book '{book.Name}' to library '{Name}'.");
    }

    public void ListBooks()
    {
        Console.WriteLine($"Books in library '{Name}':");
        foreach (var book in Books)
        {
            Console.WriteLine(book.Name);
        }
    }
}

class Book : Item
{
    public Book(string name) : base(name)
    {
    }
}

class Program
{
    static List<Library> libraries = new List<Library>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Create a new library");
            Console.WriteLine("2. Add a book to a library");
            Console.WriteLine("3. List books in a library");
            Console.WriteLine("4. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateLibrary();
                    break;
                case "2":
                    AddBookToLibrary();
                    break;
                case "3":
                    ShowBooksInLibrary();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }
        }
    }

    static void CreateLibrary()
    {
        Console.WriteLine("Enter the name of the library: ");
        string name = Console.ReadLine();
        var library = new Library(name);
        libraries.Add(library);
        Console.WriteLine($"Library '{library.Name}' created.");
    }

    static void AddBookToLibrary()
    {
        if (libraries.Count == 0)
        {
            Console.WriteLine("No libraries available. Create a library first.");
            return;
        }

        Console.WriteLine("Select a library to add a book to: ");
        for (int i = 0; i < libraries.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {libraries[i].Name}");
        }

        if (int.TryParse(Console.ReadLine(), out int libraryIndex) && libraryIndex > 0 && libraryIndex <= libraries.Count)
        {
            Console.WriteLine("Enter the name of the book to add: ");
            string bookName = Console.ReadLine();

            var book = new Book(bookName);
            libraries[libraryIndex - 1].AddBook(book);
        }
        else
        {
            Console.WriteLine("Invalid input. Please try again.");
        }
    }

    static void ShowBooksInLibrary()
    {
        if (libraries.Count == 0)
        {
            Console.WriteLine("No libraries available. Create a library first.");
            return;
        }

        Console.WriteLine("Select a library to show books: ");
        for (int i = 0; i < libraries.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {libraries[i].Name}");
        }

        if (int.TryParse(Console.ReadLine(), out int libraryIndex) && libraryIndex > 0 && libraryIndex <= libraries.Count)
        {
            libraries[libraryIndex - 1].ListBooks();
        }
        else
        {
            Console.WriteLine("Invalid input. Please try again.");
        }
    }
}

