
using System;
using System.Collections.Generic;

class Program
{
    static List<Book> books = new();
    static List<Magazine> magazines = new();
    static List<User> users = new();

    public static void Main()
    {
        string? menu = null;
        Console.WriteLine("Hello! This Library Management system allows you to borrow, add, delete, update books and magazines, and perform other tasks.");
        Console.Clear();
        while (menu != "0")
        {
            menu = Menu().ToLower();

            switch (menu)
            {
                case "1" or "manage":
                    ManageBook();
                    break;
                case "2" or "registeration":
                    RegisterMenu();
                    break;
                case "3" or "library reservations":
                    LibraryReservations();
                    break;
                case "4" or "books":
                    Books();
                    break;
                case "5" or "magazines":
                    Magazines();
                    break;
                case "6" or "search":
                    SearchBooks();
                    break;
                case "7" or "users":
                    Users();
                    break;
                case "0" or "close":
                    Console.WriteLine("The program is finishing....");
                    break;
                default:
                    Console.WriteLine("Invalid menu");
                    Thread.Sleep(2000);
                    break;
            }
        }
    }

    private static void LibraryReservations()
    {
        System.Console.WriteLine("Library Reservations");
       while (true)
        {
            Console.WriteLine("1. Reserve");
            Console.WriteLine("2. Available");
            Console.WriteLine("3. Borrowed");
            Console.WriteLine("0. Exit");
            Console.Write("Select an option (number or name): ");
            string choice = Console.ReadLine()?.ToLower().Trim()!;

            switch (choice)
            {
                case "1" or "reserve":
                   Bron();
                    break;
                case "2" or "available":
                    if (books.Count == 0 && magazines.Count == 0)
                    {
                        Console.WriteLine("No books or magazines have been added yet. Please add them first.");
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        System.Console.WriteLine("Available books and magazines");
                        Available();
                    }
                    break;
                case "3" or "borrowed":
                    Borrowed();
                    break;
                case "0" or "exit":
                    return;
                default:
                    Console.WriteLine("Invalid selection. Try again.");
                    Thread.Sleep(2000);
                    break;
            }
        }
    }

private static void Borrowed()
{
    bool hasBorrowedBooks = false;     // Olingan kitoblar flag
    bool hasBorrowedMagazines = false; // Olingan magazinlar flag

    // Hech qanday kitob ham, magazin ham mavjud emasligini tekshirish
    if (books.Count == 0 && magazines.Count == 0)
    {
        System.Console.WriteLine("No books or magazines available to borrow.");
        Thread.Sleep(2000);
        return;
    }
    // Kitoblar bo'yicha tekshiruv
    if (books.Count != 0)
    {
        System.Console.WriteLine();
        foreach (var book in books)
        {
            if (book.isReversed) // Kitob qarzga olinganmi tekshiradi
            {
                System.Console.WriteLine(book.ToString());
                hasBorrowedBooks = true;
            }
        }
        System.Console.WriteLine();
        if (!hasBorrowedBooks)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("No books have been borrowed.");
            Thread.Sleep(2000);
            System.Console.WriteLine();
        }
    }

    // Magazinlar bo'yicha tekshiruv
    if (magazines.Count != 0)
    {
        System.Console.WriteLine();
        foreach (var magazine in magazines)
        {
            if (magazine.isReversed) // Magazin qarzga olinganmi tekshiradi
            {
                System.Console.WriteLine(magazine.ToString());
                hasBorrowedMagazines = true;
            }
        }
        System.Console.WriteLine();
        if (!hasBorrowedMagazines)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("No magazines have been borrowed.");
            Thread.Sleep(2000);
            System.Console.WriteLine();
        }
    }

    // Agar hech narsa qarzga olinmagan bo'lsa
    if (!hasBorrowedBooks && !hasBorrowedMagazines)
    {
        System.Console.WriteLine("No books or magazines have been borrowed.");
    }
}



   private static void Available()
{
    bool hasAvailableBooks = false;     // Mavjud kitoblar flagi
    bool hasAvailableMagazines = false; // Mavjud magazinlar flagi

    // Kitoblar bo'yicha tekshiruv
    foreach (var book in books)
    {
        if (!book.isReversed) // Agar kitob qarzga olinmagan bo'lsa
        {
            System.Console.WriteLine(book.ToString());
            hasAvailableBooks = true;
        }
    }

    // Magazinlar bo'yicha tekshiruv
    foreach (var magazine in magazines)
    {
        if (!magazine.isReversed) // Agar magazin qarzga olinmagan bo'lsa
        {
            System.Console.WriteLine(magazine.ToString());
            hasAvailableMagazines = true;
        }
    }

    // Agar mavjud kitoblar yoki magazinlar bo'lmasa
    if (!hasAvailableBooks && !hasAvailableMagazines)
    {
        System.Console.WriteLine("No available books or magazines at the moment.");
    }

    System.Console.WriteLine();
    System.Console.WriteLine("If you want to read the news, please reserve first.");
}


    private static void Users()
    {
        System.Console.WriteLine("Users");
        foreach(var i in users)
        {
            System.Console.WriteLine(i.ToString());
        }
    }

    private static void RegisterMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Update");
            Console.WriteLine("3. Delete");
            Console.WriteLine("0. Exit");
            Console.Write("Select an option (number or name): ");
            string choice = Console.ReadLine()?.ToLower().Trim()!;

            switch (choice)
            {
                case "1" or "register":
                    Register();
                    break;
                case "2" or "update":
                    if (users.Count == 0)
                    {
                        Console.WriteLine("No users registered. Please register first.");
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        UpdateUser();
                    }
                    break;
                case "3" or "delete":
                    if (users.Count == 0)
                    {
                        Console.WriteLine("No users registered. Please register first.");
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        DeleteUser();
                    }
                    break;
                case "0" or "exit":
                    return;
                default:
                    Console.WriteLine("Invalid selection. Try again.");
                    Thread.Sleep(2000);
                    break;
            }
        }
    }

    private static void Register()
    {
        string name;
        int age;
        string password;

        Console.WriteLine("Registration:");
        Console.Write("Enter your name: ");
        name = Console.ReadLine()!.Trim();

        while (string.IsNullOrWhiteSpace(name))
        {
            Console.Write("Name cannot be empty. Please enter again: ");
            name = Console.ReadLine()!.Trim();
        }

        Console.Write("Enter your age: ");
        while (!int.TryParse(Console.ReadLine(), out age) || age <= 0 || age >= 100)
        {
            Console.Write("Invalid age. Please enter a valid age (0-100): ");
        }

        Console.Write("Enter your password (at least 6 characters): ");
        password = Console.ReadLine()!.Trim();

        while (string.IsNullOrWhiteSpace(password) || password.Length < 6)
        {
            Console.Write("Password must be at least 6 characters. Try again: ");
            password = Console.ReadLine()!.Trim();
        }

        User newUser = new User { Name = name, Year = age, Password = password };
        users.Add(newUser);

        Console.WriteLine("Registration successful!");
        Console.WriteLine($"Name: {newUser.Name}, Age: {newUser.Year}, Password: {new string('*', newUser.Password.Length)}");

        Thread.Sleep(3000);
    }

    private static void UpdateUser()
    {
        Console.Write("Enter the name of the user to update: ");
        string name = Console.ReadLine()!.Trim();

        User userToUpdate = users.Find(u => u.Name == name)!;

        if (userToUpdate != null)
        {
            string newName;
            int newAge;
            string newPassword;

            Console.Write("Enter new name: ");
            newName = Console.ReadLine()!.Trim();

            while (string.IsNullOrWhiteSpace(newName))
            {
                Console.Write("Name cannot be empty. Please enter again: ");
                newName = Console.ReadLine()!.Trim();
            }

            Console.Write("Enter new age: ");
            while (!int.TryParse(Console.ReadLine(), out newAge) || newAge <= 0 || newAge >= 100)
            {
                Console.Write("Invalid age. Enter a valid age (0-100): ");
            }

            Console.Write("Enter new password (at least 6 characters): ");
            newPassword = Console.ReadLine()!.Trim();

            while (string.IsNullOrWhiteSpace(newPassword) || newPassword.Length < 6)
            {
                Console.Write("Password must be at least 6 characters. Try again: ");
                newPassword = Console.ReadLine()!.Trim();
            }

            userToUpdate.Name = newName;
            userToUpdate.Year = newAge;
            userToUpdate.Password = newPassword;

            Console.WriteLine("User updated successfully.");
        }
        else
        {
            Console.WriteLine("User not found.");
        }

        Thread.Sleep(3000);
    }

    private static void DeleteUser()
    {
        Console.Write("Enter the name of the user to delete: ");
        string name = Console.ReadLine()!.Trim();

        User userToDelete = users.Find(u => u.Name == name)!;

        if (userToDelete != null)
        {
            users.Remove(userToDelete);
            Console.WriteLine("User deleted successfully.");
        }
        else
        {
            Console.WriteLine("User not found.");
        }

        Thread.Sleep(3000);
    }

    private static void Magazines()
    {
        if(magazines.Count == 0)
        {
            System.Console.WriteLine("Magazines are empty");
        }
        else
        {
            foreach (var magazine in magazines)
            {
                Console.WriteLine(magazine.ToString());
            }
        }
    }

 private static void SearchBooks()
    {
        Console.WriteLine("Search by: 1) Title, 2) Author, 3) ISBN");
        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine()!.Trim().ToLower();

        switch (choice)
        {
            case "1" or "title":
                Console.Write("Enter book/magazine title to search: ");
                string title = Console.ReadLine()!.Trim();
                bool foundTitle = false;

                Console.WriteLine("Books:");
                for (int i = 0; i < books.Count; i++)
                {
                    if (books[i].Title != null && books[i].Title!.Equals(title, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine(books[i].ToString());
                        foundTitle = true;
                    }
                }

                Console.WriteLine("Magazines:");
                for (int i = 0; i < magazines.Count; i++)
                {
                    if (magazines[i].Title != null && magazines[i].Title!.Equals(title, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine(magazines[i].ToString());
                        foundTitle = true;
                    }
                }

                if (!foundTitle)
                {
                    Console.WriteLine("No books or magazines found by that title.");
                    Thread.Sleep(2000);
                }
                break;

            case "2" or "author":
                Console.Write("Enter author to search: ");
                string author = Console.ReadLine()!.Trim();
                bool foundAuthor = false;

                for (int i = 0; i < books.Count; i++)
                {
                    if (books[i].Author != null && books[i].Author!.Equals(author, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine(books[i].ToString());
                        foundAuthor = true;
                    }
                }

                if (!foundAuthor)
                {
                    Console.WriteLine("No books found by that author.");
                    Thread.Sleep(2000);
                }
                break;

            case "3" or "isbn" or "issue number":
                Console.Write("Enter ISBN to search: ");
                try
                {
                    int isbn = int.Parse(Console.ReadLine()!);
                    bool foundISBN = false;

                    for (int i = 0; i < books.Count; i++)
                    {
                        if (books[i].ISBN == isbn)
                        {
                            Console.WriteLine(books[i].ToString());
                            foundISBN = true;
                        }
                    }

                    for (int i = 0; i < magazines.Count; i++)
                    {
                        if (magazines[i].IssueNumber == isbn)
                        {
                            Console.WriteLine(magazines[i].ToString());
                            foundISBN = true;
                        }
                    }

                    if (!foundISBN)
                    {
                        Console.WriteLine("No books or magazines found with that ISBN.");
                        Thread.Sleep(2000);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input! Please enter a valid ISBN number.");
                    Thread.Sleep(3500);
                }
                break;

            default:
                Console.WriteLine("Invalid choice! Please choose 1, 2, or 3.");
                Thread.Sleep(2000);
                break;
        }
    }

    private static void Books()
    {
        if(books.Count == 0)
        {
            System.Console.WriteLine("Books are empty");
        }
        else
        {
            foreach (var book in books)
            {
                Console.WriteLine(book.ToString());
            }
        }
    }

private static void Bron()
{
    bool hasAvailableBooks = books.Any(b => !b.isReversed);
    bool hasAvailableMagazines = magazines.Any(m => !m.isReversed);

    if (!hasAvailableBooks && !hasAvailableMagazines)
    {
        Console.WriteLine("There are no books or magazines available to reserve.");
        Thread.Sleep(2000);
        return;
    }

    Console.WriteLine("Available books:");
    foreach (var book in books)
    {
        if (!book.isReversed) 
        {
            Console.WriteLine(book.ToString());
        }
    }
    Console.WriteLine();
    
    Console.WriteLine("Available magazines:");
    foreach (var magazine in magazines)
    {
        if (!magazine.isReversed) 
        {
            Console.WriteLine(magazine.ToString());
        }
    }
    Console.WriteLine();
    
    Console.Write("Enter ISBN to reserve book/magazine: ");
    try
    {
        int isbn = int.Parse(Console.ReadLine()!);

        Book? bookToReserve = null;
        foreach (var book in books)
        {
            if (book.ISBN == isbn)
            {
                if (book.isReversed) 
                {
                    Console.WriteLine("This book is already reserved.");
                    Thread.Sleep(2000);
                    return; 
                }
                bookToReserve = book;
                break;
            }
        }

        Magazine? magazineToReserve = null;
        foreach (var magazine in magazines)
        {
            if (magazine.IssueNumber == isbn)
            {
                if (magazine.isReversed)
                {
                    Console.WriteLine("This magazine is already reserved.");
                    return; 
                }
                magazineToReserve = magazine;
                break;
            }
        }

        if (bookToReserve != null)
        {
            bookToReserve.Reverse(); 
            Console.WriteLine("Book is reserved.");
            Thread.Sleep(3000);
        }
        else if (magazineToReserve != null)
        {
            magazineToReserve.Reverse(); 
            Console.WriteLine("Magazine is reserved.");
            Thread.Sleep(3000);
        }
        else
        {
            Console.WriteLine("No available book or magazine found with that ISBN.");
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Invalid input! Please enter a valid ISBN number.");
    }
}



    
    private static void ManageBook()
    {
        string submenu = "";
        while(submenu != "0")
        {
            Console.Clear();
            Console.WriteLine();
            System.Console.WriteLine("Submenu");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Update");
            Console.WriteLine("3. Delete");
            Console.WriteLine("0. Menu");
            Console.WriteLine();

            Console.Write("Enter the submenu name or number: ");
            submenu = Console.ReadLine()!.Trim().ToLower();
            switch (submenu)
            {
                case "1" or "add":
                    Add();
                    break;
                case "2" or "update":
                    Update();
                    break;
                case "3" or "delete":
                    foreach(var i in books)
                    {
                        System.Console.WriteLine(i.ToString());
                    }
                    foreach(var i in magazines)
                    {
                        System.Console.WriteLine(i.ToString());
                    }
                    System.Console.WriteLine();
                    Delete();
                    break;
                case "0" or "menu": 
                break;
                default: System.Console.WriteLine("Invalid submenu!");
                Thread.Sleep(1500);
                break;
            }
            Console.Clear();
        }
    }
private static void Delete()
{
    foreach(var i in books)
    {
        i.ToString();
    }
    foreach(var i in magazines)
    {
        i.ToString();
    }

    if(books.Count > 0 || magazines.Count > 0)
    {
        Console.WriteLine();
        Console.Write("Enter ISBN to delete book/magazine: ");
        int isbn = int.Parse(Console.ReadLine()!);

        var bookToDelete = books.FirstOrDefault(b => b.ISBN == isbn);  
        var magazineToDelete = magazines.FirstOrDefault(m => m.IssueNumber == isbn);  

        if (bookToDelete != null)
        {
            books.Remove(bookToDelete);  
            Console.WriteLine("Book is deleted");
            Thread.Sleep(3000);
        }
        else if(magazineToDelete != null )
        {
            magazines.Remove(magazineToDelete);  
            Console.WriteLine("Magazine is deleted");
            Thread.Sleep(3000);
        }
        else
        {
            Console.WriteLine("Book not found");
            Thread.Sleep(2000);
        }
    }
    else
    {
        System.Console.WriteLine("Error! Library is empty");
        Thread.Sleep(2000);
    }
}


   private static void Update()
{
    if (books.Count == 0 && magazines.Count == 0)
    {
        Console.WriteLine("No books or magazines available to update.");
        Thread.Sleep(2000);
        return;
    }
    
    string type = "";
    while (type != "book" && type != "magazine")
    {
        Console.Write("Enter the type (book or magazine) to update: ");
        type = Console.ReadLine()!.Trim().ToLower();

        if (type != "book" && type != "magazine")
        {
            Console.WriteLine("Invalid type. Please enter 'book' or 'magazine'.");
        }
    }

    if (type == "book")
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No books available to update.");
            Thread.Sleep(2000);
            return;
        }

        Book? bookToUpdate = null;
        while (bookToUpdate == null)
        {
            Console.Write("Enter the book name to update: ");
            string title = Console.ReadLine()!.Trim();

            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Title != null && books[i].Title!.Equals(title, StringComparison.OrdinalIgnoreCase))
                {
                    bookToUpdate = books[i];
                    break;
                }
            }

            if (bookToUpdate == null)
            {
                Console.WriteLine("Book not found. Try again.");
            }
        }

        string newTitle = "";
        while (string.IsNullOrWhiteSpace(newTitle))
        {
            Console.Clear();
            System.Console.WriteLine();
            Console.Write("Enter the new book title: ");
            newTitle = Console.ReadLine()!.Trim();
            if (string.IsNullOrWhiteSpace(newTitle))
            {
                Console.WriteLine("Invalid input! Title cannot be empty.");
            }
        }

        string newAuthor = "";
        while (string.IsNullOrWhiteSpace(newAuthor))
        {
            Console.Write("Enter the new book author: ");
            newAuthor = Console.ReadLine()!.Trim();
            if (string.IsNullOrWhiteSpace(newAuthor))
            {
                Console.WriteLine("Invalid input! Author cannot be empty.");
            }
        }

        int newYear = -1;
        while (newYear < 0)
        {
            Console.Write("Enter the new publication year: ");
            try
            {
                newYear = int.Parse(Console.ReadLine()!.Trim());
                if (newYear < 0)
                {
                    Console.WriteLine("Publication year cannot be negative.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input! Please enter a valid year.");
            }
        }

        bookToUpdate.Title = newTitle;
        bookToUpdate.Author = newAuthor;
        bookToUpdate.PublicationYear = newYear;

        Console.WriteLine("The book has been updated successfully!");
        Thread.Sleep(3000);
    }
    else if (type == "magazine")
    {
        if (magazines.Count == 0)
        {
            Console.WriteLine("No magazines available to update.");
            Thread.Sleep(2000);

            return;
        }

        Magazine? magazineToUpdate = null;
        while (magazineToUpdate == null)
        {
            Console.Write("Enter the magazine title to update: ");
            string title = Console.ReadLine()!.Trim();

            for (int i = 0; i < magazines.Count; i++)
            {
                if (magazines[i].Title != null && magazines[i].Title!.Equals(title, StringComparison.OrdinalIgnoreCase))
                {
                    magazineToUpdate = magazines[i];
                    break;
                }
            }

            if (magazineToUpdate == null)
            {
                Console.WriteLine("Magazine not found. Try again.");
            }
        }

        string newTitle = "";
        while (string.IsNullOrWhiteSpace(newTitle))
        {
            Console.Clear();
            System.Console.WriteLine();
            Console.Write("Enter the new magazine title: ");
            newTitle = Console.ReadLine()!.Trim();
            if (string.IsNullOrWhiteSpace(newTitle))
            {
                Console.WriteLine("Invalid input! Title cannot be empty.");
            }
        }

        string newAuthor = "";
        while (string.IsNullOrWhiteSpace(newAuthor))
        {
            Console.Write("Enter the new magazine author: ");
            newAuthor = Console.ReadLine()!.Trim();
            if (string.IsNullOrWhiteSpace(newAuthor))
            {
                Console.WriteLine("Invalid input! Author cannot be empty.");
            }
        }

        int newYear = -1;
        while (newYear < 0)
        {
            Console.Write("Enter the new publication year: ");
            try
            {
                newYear = int.Parse(Console.ReadLine()!.Trim());
                if (newYear < 0)
                {
                    Console.WriteLine("Publication year cannot be negative.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input! Please enter a valid year.");
            }
        }

        magazineToUpdate.Title = newTitle;
        magazineToUpdate.Author = newAuthor;
        magazineToUpdate.PublicationYear = newYear;

        Console.WriteLine("The magazine has been updated successfully!");
        Thread.Sleep(3000);
    }
}


    private static void Add()
    {
        bool isTitle = false;
        bool isAuthor = false;
        bool isYear = false;
        bool isType = false;

        Console.WriteLine("Please enter the book/magazine details:");

        Console.Write("Title: ");
        string title = Console.ReadLine()!.Trim();
        while (!isTitle)
        {
            if (title.Length >= 2)
            {
                isTitle = true;
            }
            else
            {
                Console.WriteLine("Invalid title. Please retry:");
                Console.Write("Title: ");
                title = Console.ReadLine()!.Trim();
            }
        }

        Console.Write("Author: ");
        string author = Console.ReadLine()!.Trim();
        while (!isAuthor)
        {
            if (author.Length >= 3)
            {
                isAuthor = true;
            }
            else
            {
                Console.WriteLine("Invalid author name. Please retry:");
                Console.Write("Author: ");
                author = Console.ReadLine()!.Trim();
            }
        }

        int year = 0;
        while (!isYear)
        {
            try
            {
                Console.Write("Publication Year: ");
                year = int.Parse(Console.ReadLine()!);

                if (year < 0 || year > DateTime.Now.Year)
                {
                    Console.WriteLine("Invalid year. Please retry.");
                }
                else
                {
                    isYear = true;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("The year must be a number. Please try again.");
            }
        }

        Console.Write("Enter the type (book or magazine): ");
        string type = Console.ReadLine()!.Trim();
        while (!isType)
        {
            if (type.Length > 0 && (type == "book" || type == "magazine"))
            {
                isType = true;
            }
            else
            {
                Console.WriteLine("Invalid type. Please enter 'book' or 'magazine'.");
                Console.Write("Type: ");
                type = Console.ReadLine()!.Trim();
            }
        }

        if (isTitle && isAuthor && isYear && isType)
        {
            Random random = new Random();
            int isbn = random.Next(1000000, 1000000000);

            if (type == "book")
            {
                Book newBook = new Book
                {
                    Title = title,
                    Author = author,
                    PublicationYear = year,
                    ISBN = isbn
                };
                books.Add(newBook);
                Console.WriteLine("The book has been successfully added!");
            }
            else if (type == "magazine")
            {
                Magazine newMagazine = new Magazine
                {
                    Title = title,
                    Author = author,
                    PublicationYear = year,
                    IssueNumber = isbn 
                };
                magazines.Add(newMagazine);
                Console.WriteLine("The magazine has been successfully added!");
            }
        }
    }

    static string Menu()
    {
        System.Console.WriteLine();
        Console.WriteLine("Library Menu");
        Console.WriteLine("1. Manage");
        Console.WriteLine("2. Registeration");
        Console.WriteLine("3. Library Reservations");
        Console.WriteLine("4. Books");
        Console.WriteLine("5. Magazines");
        Console.WriteLine("6. Search");
        Console.WriteLine("7. Users");
        Console.WriteLine("0. Close");

        Console.WriteLine();
        Console.Write("Please enter the menu number or menu name: ");
        string menu = Console.ReadLine()!.Trim();

        return menu;
    }
}

public class User
{
    public string? Name { get; set; }
    public int Year { get; set; }
    public string? Password { get; set; }

    public override string ToString()
    {
        return $"Name: {Name}, Year: {Year}";
    }
}
abstract class Library
{
    public bool isReversed { get; set; } = false;
    public string? Title { get; set; }
    public string? Author { get; set; }
    public int ISBN { get; set; }
    public int PublicationYear { get; set; }
    public string? Type { get; set; }

    public virtual void AddItem(string title, string author, int year, int isbn)
    {
        Console.WriteLine("Adding item to the library...");
    }

    public abstract void Reverse();
}

class PublicLibrary : Library
{
    public override void Reverse()
    {
        Console.WriteLine("Reverse operation for PublicLibrary.");
    }
}

class Book : Library, IBorrowable, ISearchable
{
    public override void AddItem(string title, string author, int year, int isbn)
    {
        Title = title;
        Author = author;
        PublicationYear = year;
        ISBN = isbn;
        Console.WriteLine($"Added Book: {title} by {author}, published in {year}");
    }

    public void Borrow()
    {
        if (!isReversed)
        {
            Console.WriteLine($"Borrowed Book: {Title} (ISBN: {ISBN})");
        }
        else
        {
            Console.WriteLine($"Cannot borrow Book: {Title}, as it is reversed.");
        }
    }

    public void Return()
    {
        Console.WriteLine($"Returned Book: {Title} (ISBN: {ISBN})");
    }

    public void Search(string query)
    {
        if (Title?.Contains(query) == true || Author?.Contains(query) == true)
        {
            Console.WriteLine($"Found: {Title} by {Author}");
        }
    }

    public override void Reverse()
    {
        isReversed = !isReversed;
        Console.WriteLine(isReversed ? "Book borrowing reversed." : "Book borrowing restored.");
    }

    public override string ToString()
    {
        return $"Book Title: {Title}, Author: {Author}, Year: {PublicationYear}, ISBN: {ISBN} isBron: {isReversed}";
    }
}

class Magazine : Library, IBorrowable, ISearchable
{
    public int IssueNumber { get; set; }

    public override void AddItem(string title, string author, int year, int issueNumber)
    {
        Title = title;
        Author = author;
        PublicationYear = year;
        IssueNumber = issueNumber;
        Console.WriteLine($"Added Magazine: {title}, Issue {IssueNumber}, published in {year}");
    }

    public void Borrow()
    {
        if (!isReversed)
        {
            Console.WriteLine($"Borrowed Magazine: {Title} (Issue: {IssueNumber})");
        }
        else
        {
            Console.WriteLine($"Cannot borrow Magazine: {Title}, as it is reversed.");
        }
    }

    public void Return()
    {
        Console.WriteLine($"Returned Magazine: {Title} (Issue: {IssueNumber})");
    }

    public void Search(string query)
    {
        if (Title?.Contains(query) == true || Author?.Contains(query) == true)
        {
            Console.WriteLine($"Found: {Title}, Issue: {IssueNumber}");
        }
    }

    public override void Reverse()
    {
        isReversed = !isReversed;
        Console.WriteLine(isReversed ? "Magazine borrowing reversed." : "Magazine borrowing restored.");
    }

    public override string ToString()
    {
        return $"Magazine Title: {Title}, Author: {Author}, Year: {PublicationYear}, Issue Number: {IssueNumber} isBron: {isReversed}";
    }
}

interface IBorrowable
{
    void Borrow();
    void Return();
}

interface ISearchable
{
    void Search(string query);
}