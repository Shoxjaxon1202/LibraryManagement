using Spectre.Console;
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
        Console.Clear();
        AnsiConsole.Markup("[blue]Hello! This Library Management system allows you to borrow, add, delete, update books and magazines, and perform other tasks.[/]");
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
                    AnsiConsole.MarkupLine("[red]The program is finishing....[/]");
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
    while (true)
    {
        AnsiConsole.Clear();
        AnsiConsole.MarkupLine("[bold cyan]Library Reservations[/]");

        var menuSelection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[yellow]Select an option:[/]")
                .PageSize(4)
                .AddChoices("Reserve", "Available", "Borrowed", "Exit")
                .HighlightStyle(new Style(foreground: Color.Cyan1))
        );

        switch (menuSelection.ToLower())
        {
            case "reserve":
                Bron();
                break;

            case "available":
                if (books.Count == 0 && magazines.Count == 0)
                {
                    AnsiConsole.MarkupLine("[red]No books or magazines have been added yet. Please add them first.[/]");
                    Console.WriteLine();
                    AnsiConsole.Status().Start("Waiting...", ctx => Thread.Sleep(2000));
                }
                else
                {
                    AnsiConsole.MarkupLine("[bold yellow]Available books and magazines:[/]");
                    Available();
                }
                break;

            case "borrowed":
                Borrowed();
                break;

            case "exit":
                AnsiConsole.MarkupLine("[bold red]Exiting the Library Reservation system...[/]");
                AnsiConsole.Status().Start("Waiting...", ctx => Thread.Sleep(1000));
                return;

            default:
                AnsiConsole.MarkupLine("[red]Invalid selection. Try again.[/]");
                AnsiConsole.Status().Start("Waiting...", ctx => Thread.Sleep(2000));
                break;
        }
    }
}

private static void Borrowed()
{
    AnsiConsole.Clear();
    AnsiConsole.MarkupLine("[bold cyan]Borrowed Books and Magazines[/]");

    bool hasBorrowedBooks = false;
    bool hasBorrowedMagazines = false;

    if (books.Count == 0 && magazines.Count == 0)
    {
        AnsiConsole.MarkupLine("[red]No books or magazines available to borrow.[/]");
        Thread.Sleep(2000);
        return;
    }

    if (books.Count != 0)
    {
        AnsiConsole.MarkupLine("[bold yellow]Borrowed Books:[/]");
        foreach (var book in books.Where(b => b.isReversed))
        {
            AnsiConsole.MarkupLine($"[green]{book.ToString()}[/]");
            hasBorrowedBooks = true;
        }

        if (!hasBorrowedBooks)
        {
            AnsiConsole.MarkupLine("[red]No books have been borrowed.[/]");
        }
    }

    Console.WriteLine();

    if (magazines.Count != 0)
    {
        AnsiConsole.MarkupLine("[bold yellow]Borrowed Magazines:[/]");
        foreach (var magazine in magazines.Where(m => m.isReversed))
        {
            AnsiConsole.MarkupLine($"[green]{magazine.ToString()}[/]");
            hasBorrowedMagazines = true;
        }

        if (!hasBorrowedMagazines)
        {
            AnsiConsole.MarkupLine("[red]No magazines have been borrowed.[/]");
        }
    }

    Console.WriteLine();

    if (!hasBorrowedBooks && !hasBorrowedMagazines)
    {
        AnsiConsole.MarkupLine("[red]No books or magazines have been borrowed.[/]");
    }

    Console.WriteLine();
    AnsiConsole.Status().Start("Waiting...", ctx => Thread.Sleep(3000));
}
private static void Available()
{
    AnsiConsole.Clear();
    AnsiConsole.MarkupLine("[bold cyan]Available Books and Magazines[/]");

    bool hasAvailableBooks = false;
    bool hasAvailableMagazines = false;

    AnsiConsole.MarkupLine("[bold yellow]Available Books:[/]");
    foreach (var book in books.Where(b => !b.isReversed))
    {
        AnsiConsole.MarkupLine($"[green]{book.ToString()}[/]");
        hasAvailableBooks = true;
    }

    if (!hasAvailableBooks)
    {
        AnsiConsole.MarkupLine("[red]No available books at the moment.[/]");
    }

    Console.WriteLine();

    AnsiConsole.MarkupLine("[bold yellow]Available Magazines:[/]");
    foreach (var magazine in magazines.Where(m => !m.isReversed))
    {
        AnsiConsole.MarkupLine($"[green]{magazine.ToString()}[/]");
        hasAvailableMagazines = true;
    }

    if (!hasAvailableMagazines)
    {
        AnsiConsole.MarkupLine("[red]No available magazines at the moment.[/]");
    }

    Console.WriteLine();

    if (!hasAvailableBooks && !hasAvailableMagazines)
    {
        AnsiConsole.MarkupLine("[red]No available books or magazines at the moment.[/]");
        Console.WriteLine();
    }

    Console.WriteLine();
    AnsiConsole.MarkupLine("[bold blue]If you want to read, please reserve first.[/]");
    Console.WriteLine();
    
    AnsiConsole.MarkupLine("[bold yellow]Press any key to go back to the main menu...[/]");
    Console.ReadKey(true);
}

 private static void Users()
{
    AnsiConsole.Clear();
    AnsiConsole.MarkupLine("[bold cyan]Users[/]");
    
    if (users.Count == 0)
    {
        AnsiConsole.Markup("[red]No users found.[/]");
        Console.WriteLine();
        AnsiConsole.Status().Start("Waiting...", ctx => Thread.Sleep(2000));
        return;
    }

    foreach (var user in users)
    {
        AnsiConsole.MarkupLine(user.ToString());
    }

    AnsiConsole.Markup("[yellow]Press any key to continue...[/]");
    Console.ReadKey();
}




    private static void RegisterMenu()
    {
        while (true)
        {
            AnsiConsole.Clear();
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[green]Select an option:[/]")
                    .AddChoices(new[] { "Register", "Update", "Delete", "Exit" })
            );

            switch (choice.ToLower())
            {
                case "register":
                    Register();
                    break;

                case "update":
                    if (users.Count == 0)
                    {
                        AnsiConsole.MarkupLine("[red]No users registered. Please register first.[/]");
                        AnsiConsole.Status().Start("Waiting...", ctx => Thread.Sleep(2000));
                    }
                    else
                    {
                        UpdateUser();
                    }
                    break;

                case "delete":
                    if (users.Count == 0)
                    {
                        AnsiConsole.MarkupLine("[red]No users registered. Please register first.[/]");
                        AnsiConsole.Status().Start("Waiting...", ctx => Thread.Sleep(2000));
                    }
                    else
                    {
                        DeleteUser();
                    }
                    break;

                case "exit":
                    return;

                default:
                    AnsiConsole.MarkupLine("[red]Invalid selection. Try again.[/]");
                    AnsiConsole.Status().Start("Waiting...", ctx => Thread.Sleep(2000));
                    break;
            }
        }
    }


private static void Register()
{
    AnsiConsole.Clear();
    AnsiConsole.MarkupLine("[bold green]Registration:[/]");

    string name = AnsiConsole.Ask<string>("Enter your [yellow]name[/]:");

    while (string.IsNullOrWhiteSpace(name))
    {
        AnsiConsole.Markup("[red]Name cannot be empty. Please enter again:[/]");
        name = AnsiConsole.Ask<string>("Enter your [yellow]name[/]:");
    }

    int age = AnsiConsole.Prompt(
        new TextPrompt<int>("Enter your [yellow]age[/]:")
            .PromptStyle("yellow")
            .Validate(age => age > 0 && age < 100 
                ? ValidationResult.Success() 
                : ValidationResult.Error("[red]Please enter a valid age between 1 and 99.[/]"))
    );

    string password = AnsiConsole.Prompt(
        new TextPrompt<string>("Enter your [yellow]password[/] (at least 6 characters):")
            .PromptStyle("yellow")
            .Secret()
            .Validate(pw => pw.Length >= 6 
                ? ValidationResult.Success() 
                : ValidationResult.Error("[red]Password must be at least 6 characters.[/]"))
    );

    User newUser = new User { Name = name, Year = age, Password = password };
    users.Add(newUser);

    AnsiConsole.MarkupLine("[green]Registration successful![/]");
    AnsiConsole.MarkupLine($"[yellow]Name:[/] {newUser.Name}, [yellow]Age:[/] {newUser.Year}, [yellow]Password:[/] {new string('*', newUser.Password.Length)}");

    AnsiConsole.Status().Start("Waiting...", ctx => Thread.Sleep(3000));
}


private static void UpdateUser()
{
    AnsiConsole.Clear();
    AnsiConsole.MarkupLine("[bold green]Update User:[/]");

    string name = AnsiConsole.Ask<string>("Enter the name of the user to update:");
    User? userToUpdate = users.FirstOrDefault(u => u.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

    if (userToUpdate != null)
    {
        string currentPassword = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter your current password:")
                .PromptStyle("yellow")
                .Secret()
        );

        if (currentPassword != userToUpdate.Password)
        {
            AnsiConsole.Markup("[red]Incorrect password. Update canceled.[/]");
            System.Console.WriteLine();
            AnsiConsole.Status().Start("Waiting...", ctx => Thread.Sleep(3000));
            return;
        }

        string newName = AnsiConsole.Ask<string>("Enter new name:");

        while (string.IsNullOrWhiteSpace(newName))
        {
            AnsiConsole.Markup("[red]Name cannot be empty. Please enter again:[/]");
            newName = AnsiConsole.Ask<string>("Enter new name:");
        }

        int newAge;
        do
        {
            newAge = AnsiConsole.Ask<int>("Enter new age (1-99):");

            if (newAge <= 0 || newAge >= 100)
            {
                AnsiConsole.Markup("[red]Invalid age. Please enter a valid age (1-99):[/]");
            }

        } while (newAge <= 0 || newAge >= 100);

        string newPassword = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter new password (at least 6 characters):")
                .PromptStyle("yellow")
                .Secret()
                .Validate(pw => pw.Length >= 6 
                    ? ValidationResult.Success() 
                    : ValidationResult.Error("[red]Password must be at least 6 characters.[/]"))
        );

        userToUpdate.Name = newName;
        userToUpdate.Year = newAge;
        userToUpdate.Password = newPassword;

        AnsiConsole.MarkupLine("[green]User updated successfully.[/]");
    }
    else
    {
        AnsiConsole.Markup("[red]User not found.[/]");
        System.Console.WriteLine();
    }

    AnsiConsole.Status().Start("Waiting...", ctx => Thread.Sleep(3000));
}

private static void DeleteUser()
{
    AnsiConsole.Clear();
    AnsiConsole.MarkupLine("[bold red]Delete User:[/]");

    string name = AnsiConsole.Ask<string>("Enter the name of the user to delete:");

    User? userToDelete = users.FirstOrDefault(u => u.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

    if (userToDelete != null)
    {
        string password = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter the password to confirm deletion:")
                .PromptStyle("yellow")
                .Secret()
        );

        if (userToDelete.Password == password)
        {
            users.Remove(userToDelete);
            AnsiConsole.MarkupLine("[green]User deleted successfully.[/]");
        }
        else
        {
            AnsiConsole.Markup("[red]Incorrect password. User deletion cancelled.[/]");
            Console.WriteLine();
        }
    }
    else
    {
        AnsiConsole.Markup("[red]User not found.[/]");
        Console.WriteLine();
    }

    AnsiConsole.Status().Start("Waiting...", ctx => Thread.Sleep(3000));
}
private static void Magazines()
{
    AnsiConsole.Clear();
    AnsiConsole.MarkupLine("[bold cyan]Magazines[/]");

    if (magazines.Count == 0)
    {
        AnsiConsole.Markup("[red]Magazines are empty.[/]");
    }
    else
    {
        var table = new Table();
        table.AddColumn("[bold]ID[/]");
        table.AddColumn("[bold]Title[/]");
        table.AddColumn("[bold]Publisher[/]");
        table.AddColumn("[bold]Issue Number[/]");
        table.AddColumn("[bold]Year[/]");

        foreach (var magazine in magazines)
        {
            table.AddRow(magazine.IssueNumber.ToString(), magazine.Title!, magazine.PublicationYear.ToString(), 
                         magazine.IssueNumber.ToString(), magazine.PublicationYear.ToString());
        }

        AnsiConsole.Write(table);
    }

    AnsiConsole.MarkupLine("\nPress any key to return...");
    Console.ReadKey();
}

private static void SearchBooks()
{
    AnsiConsole.Clear();
    AnsiConsole.MarkupLine("[bold cyan]Search Books and Magazines[/]");
    AnsiConsole.MarkupLine("Search by: [yellow]1)[/] Title, [yellow]2)[/] Author, [yellow]3)[/] ISBN");

    string choice = AnsiConsole.Ask<string>("Enter your choice:");

    switch (choice)
    {
        case "1" or "title":
            string title = AnsiConsole.Ask<string>("Enter book/magazine title to search:").Trim();
            if (string.IsNullOrWhiteSpace(title))
            {
                AnsiConsole.Markup("[red]Invalid input! Title cannot be empty.[/]");
                Console.WriteLine();
                AnsiConsole.Status().Start("Waiting...", ctx => Thread.Sleep(2000));
                return;
            }

            bool foundTitle = false;

            AnsiConsole.MarkupLine("[bold yellow]Books:[/]");
            foreach (var book in books)
            {
                if (book.Title != null && book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                {
                    AnsiConsole.MarkupLine(book.ToString());
                    foundTitle = true;
                }
            }

            AnsiConsole.MarkupLine("[bold yellow]Magazines:[/]");
            foreach (var magazine in magazines)
            {
                if (magazine.Title != null && magazine.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                {
                    AnsiConsole.MarkupLine(magazine.ToString());
                    foundTitle = true;
                }
            }

            if (!foundTitle)
            {
                AnsiConsole.Markup("[red]No books or magazines found by that title.[/]");
                Console.WriteLine();
                AnsiConsole.Status().Start("Waiting...", ctx => Thread.Sleep(2000));
            }
            else
            {
                AnsiConsole.Markup("[yellow]Press any key to continue...[/]");
                Console.ReadKey(); 
            }
            break;

        case "2" or "author":
            string author = AnsiConsole.Ask<string>("Enter author to search:").Trim();
            if (string.IsNullOrWhiteSpace(author))
            {
                AnsiConsole.Markup("[red]Invalid input! Author cannot be empty.[/]");
                Console.WriteLine();
                AnsiConsole.Status().Start("Waiting...", ctx => Thread.Sleep(2000));
                return;
            }

            bool foundAuthor = false;

            foreach (var book in books)
            {
                if (book.Author != null && book.Author.Equals(author, StringComparison.OrdinalIgnoreCase))
                {
                    AnsiConsole.MarkupLine(book.ToString());
                    foundAuthor = true;
                }
            }

            if (!foundAuthor)
            {
                AnsiConsole.Markup("[red]No books found by that author.[/]");
                Console.WriteLine();
                AnsiConsole.Status().Start("Waiting...", ctx => Thread.Sleep(2000));
            }
            else
            {
                AnsiConsole.Markup("[yellow]Press any key to continue...[/]");
                Console.ReadKey(); 
            }
            break;

        case "3" or "isbn" or "issue number":
            try
            {
                int isbn = AnsiConsole.Ask<int>("Enter ISBN to search:");
                bool foundISBN = false;

                foreach (var book in books)
                {
                    if (book.ISBN == isbn)
                    {
                        AnsiConsole.MarkupLine(book.ToString());
                        foundISBN = true;
                    }
                }

                foreach (var magazine in magazines)
                {
                    if (magazine.IssueNumber == isbn)
                    {
                        AnsiConsole.MarkupLine(magazine.ToString());
                        foundISBN = true;
                    }
                }

                if (!foundISBN)
                {
                    AnsiConsole.Markup("[red]No books or magazines found with that ISBN.[/]");
                    Console.WriteLine();
                    AnsiConsole.Status().Start("Waiting...", ctx => Thread.Sleep(2000));
                }
                else
                {
                    AnsiConsole.Markup("[yellow]Press any key to continue...[/]");
                    Console.ReadKey(); 
                }
            }
            catch (FormatException)
            {
                AnsiConsole.Markup("[red]Invalid input! Please enter a valid ISBN number.[/]");
                Console.WriteLine();
                AnsiConsole.Status().Start("Waiting...", ctx => Thread.Sleep(2000));
            }
            break;

        default:
            AnsiConsole.Markup("[red]Invalid choice! Please choose 1, 2, or 3.[/]");
            Console.WriteLine();
            AnsiConsole.Status().Start("Waiting...", ctx => Thread.Sleep(2000));
            break;
    }
}

private static void Books()
{
    AnsiConsole.Clear();
    AnsiConsole.MarkupLine("[bold cyan]List of Books[/]");

    if (books.Count == 0)
    {
        AnsiConsole.MarkupLine("[red]No books available.[/]");
        Console.WriteLine();
    }
    else
    {
        AnsiConsole.MarkupLine("[bold yellow]Available Books:[/]");

        var table = new Table();
        table.AddColumn("[bold]ID[/]");
        table.AddColumn("[bold]Title[/]");
        table.AddColumn("[bold]Author[/]");
        table.AddColumn("[bold]Year[/]");

        foreach (var book in books)
        {
            table.AddRow(book.ISBN.ToString(), book.Title!, book.Author!, book.PublicationYear.ToString());
        }

        AnsiConsole.Write(table);
    }

    Console.WriteLine();
    AnsiConsole.MarkupLine("[bold yellow]Press any key to go back to the main menu...[/]");
    Console.ReadKey(true); 
    }



private static void Bron()
{
    AnsiConsole.Clear();
    AnsiConsole.MarkupLine("[bold cyan]Reserve Books or Magazines[/]");

    bool hasAvailableBooks = books.Any(b => !b.isReversed);
    bool hasAvailableMagazines = magazines.Any(m => !m.isReversed);

    if (!hasAvailableBooks && !hasAvailableMagazines)
    {
        AnsiConsole.MarkupLine("[red]There are no books or magazines available to reserve.[/]");
        Console.WriteLine();
        AnsiConsole.Status().Start("Waiting...", ctx => Thread.Sleep(2000));
        return;
    }

    if (hasAvailableBooks)
    {
        AnsiConsole.MarkupLine("[bold yellow]Available books:[/]");
        foreach (var book in books.Where(b => !b.isReversed))
        {
            AnsiConsole.MarkupLine($"[green]{book.ToString()}[/]");
        }
        Console.WriteLine();
    }

    if (hasAvailableMagazines)
    {
        AnsiConsole.MarkupLine("[bold yellow]Available magazines:[/]");
        foreach (var magazine in magazines.Where(m => !m.isReversed))
        {
            AnsiConsole.MarkupLine($"[green]{magazine.ToString()}[/]");
        }
        Console.WriteLine();
    }

    string isbnInput = AnsiConsole.Ask<string>("Enter [yellow]ISBN[/] to reserve book/magazine:");

    try
    {
        int isbn = int.Parse(isbnInput);

        Book? bookToReserve = books.FirstOrDefault(b => b.ISBN == isbn && !b.isReversed);
        Magazine? magazineToReserve = magazines.FirstOrDefault(m => m.IssueNumber == isbn && !m.isReversed);

        if (bookToReserve != null)
        {
            bookToReserve.Reverse();
            AnsiConsole.MarkupLine("[green]Book has been reserved successfully![/]");
        }
        else if (magazineToReserve != null)
        {
            magazineToReserve.Reverse();
            AnsiConsole.MarkupLine("[green]Magazine has been reserved successfully![/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]No available book or magazine found with that ISBN.[/]");
        }

        AnsiConsole.Status().Start("Waiting...", ctx => Thread.Sleep(3000));
    }
    catch (FormatException)
    {
        AnsiConsole.MarkupLine("[red]Invalid input! Please enter a valid ISBN number.[/]");
        AnsiConsole.Status().Start("Waiting...", ctx => Thread.Sleep(2000));
    }
}


    
    private static void ManageBook()
    {
        string submenu = "";
        while(submenu != "0")
        {
            submenu = Submenu();
           
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

    private static string Submenu()
    {
        AnsiConsole.Clear();

    AnsiConsole.Write(
        new FigletText("Submenu")
            .Centered()
            .Color(Color.Blue));

    var submenuSelection = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("Please select a [blue]submenu option with arrows[/]")
            .PageSize(5)
            .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
            .AddChoices(new[]
            {
                "1. Add",
                "2. Update",
                "3. Delete",
                "0. Menu"
            }));

        return submenuSelection.ToLower()[0].ToString();
    }
private static void Delete()
{
    AnsiConsole.Clear();

    if (books.Count == 0 && magazines.Count == 0)
    {
        AnsiConsole.MarkupLine("[red]Error! Library is empty.[/]");
        AnsiConsole.Status().Start("Waiting...", ctx => Thread.Sleep(2000));
        return;
    }

    var table = new Table();
    table.AddColumn("Type");
    table.AddColumn("Title");
    table.AddColumn("Author");
    table.AddColumn("Year");
    table.AddColumn("ISBN/Issue");

    foreach (var book in books)
    {
        table.AddRow("Book", book.Title!, book.Author!, book.PublicationYear.ToString(), book.ISBN.ToString());
    }

    foreach (var magazine in magazines)
    {
        table.AddRow("Magazine", magazine.Title!, magazine.Author!, magazine.PublicationYear.ToString(), magazine.IssueNumber.ToString());
    }

    AnsiConsole.Write(table);

    int isbn = AnsiConsole.Ask<int>("[yellow]Enter ISBN to delete book/magazine:[/]");

    var bookToDelete = books.FirstOrDefault(b => b.ISBN == isbn);
    var magazineToDelete = magazines.FirstOrDefault(m => m.IssueNumber == isbn);

    if (bookToDelete != null)
    {
        books.Remove(bookToDelete);
        AnsiConsole.MarkupLine("[green]Book has been deleted![/]");
        AnsiConsole.Status().Start("Waiting...", ctx => Thread.Sleep(3000));
    }
    else if (magazineToDelete != null)
    {
        magazines.Remove(magazineToDelete);
        AnsiConsole.MarkupLine("[green]Magazine has been deleted![/]");
        AnsiConsole.Status().Start("Waiting...", ctx => Thread.Sleep(3000));
    }
    else
    {
        AnsiConsole.MarkupLine("[red]Item not found![/]");
        AnsiConsole.Status().Start("Waiting...", ctx => Thread.Sleep(2000));
    }
}
private static void Update()
{
    if (books.Count == 0 && magazines.Count == 0)
    {
        AnsiConsole.MarkupLine("[red]No books or magazines available to update.[/]");
        AnsiConsole.Status()
            .Start("Waiting...", ctx => Thread.Sleep(2000));
        return;
    }

    var type = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("Enter the [green]type[/] (book or magazine) to update:")
            .AddChoices(new[] { "book", "magazine" }));

    if (type == "book")
    {
        if (books.Count == 0)
        {
            AnsiConsole.MarkupLine("[red]No books available to update.[/]");
            AnsiConsole.Status()
                .Start("Waiting...", ctx => Thread.Sleep(2000));
            return;
        }

        var title = AnsiConsole.Ask<string>("[green]Enter the book name to update:[/]");
        Book? bookToUpdate = books.Find(book => book.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

        if (bookToUpdate == null)
        {
            AnsiConsole.MarkupLine("[red]Book not found. Try again.[/]");
            AnsiConsole.Status()
                .Start("Waiting...", ctx => Thread.Sleep(2000));
            return;
        }

        var newTitle = AnsiConsole.Ask<string>("[green]Enter the new book title:[/]");
        var newAuthor = AnsiConsole.Ask<string>("[green]Enter the new book author:[/]");
        var newYear = AnsiConsole.Ask<int>("[green]Enter the new publication year:[/]");

        bookToUpdate.Title = newTitle;
        bookToUpdate.Author = newAuthor;
        bookToUpdate.PublicationYear = newYear;

        AnsiConsole.MarkupLine("[green]The book has been updated successfully![/]");
        AnsiConsole.Status()
            .Start("Waiting...", ctx => Thread.Sleep(3000));
    }
    else if (type == "magazine")
    {
        if (magazines.Count == 0)
        {
            AnsiConsole.MarkupLine("[red]No magazines available to update.[/]");
            AnsiConsole.Status()
                .Start("Waiting...", ctx => Thread.Sleep(2000));
            return;
        }

        var title = AnsiConsole.Ask<string>("[green]Enter the magazine title to update:[/]");
        Magazine? magazineToUpdate = magazines.Find(mag => mag.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

        if (magazineToUpdate == null)
        {
            AnsiConsole.MarkupLine("[red]Magazine not found. Try again.[/]");
            AnsiConsole.Status()
                .Start("Waiting...", ctx => Thread.Sleep(2000));
            return;
        }

        var newTitle = AnsiConsole.Ask<string>("[green]Enter the new magazine title:[/]");
        var newAuthor = AnsiConsole.Ask<string>("[green]Enter the new magazine author:[/]");
        var newYear = AnsiConsole.Ask<int>("[green]Enter the new publication year:[/]");

        magazineToUpdate.Title = newTitle;
        magazineToUpdate.Author = newAuthor;
        magazineToUpdate.PublicationYear = newYear;

        AnsiConsole.MarkupLine("[green]The magazine has been updated successfully![/]");
        AnsiConsole.Status()
            .Start("Waiting...", ctx => Thread.Sleep(3000));
    }
}

private static void Add()
{
    AnsiConsole.Clear();

    AnsiConsole.Write(
        new FigletText("Add Book/Magazine")
            .Centered()
            .Color(Color.Blue));

    AnsiConsole.MarkupLine("[bold yellow]Please enter the book/magazine details:[/]");

    string title = AnsiConsole.Ask<string>("[bold yellow]Title:[/]");
    while (title.Length < 2)
    {
        AnsiConsole.MarkupLine("[red]Invalid title. Please retry (minimum 2 characters):[/]");
        title = AnsiConsole.Ask<string>("[bold yellow]Title:[/]");
    }

    string author = AnsiConsole.Ask<string>("[bold yellow]Author:[/]");
    while (author.Length < 3)
    {
        AnsiConsole.MarkupLine("[red]Invalid author name. Please retry (minimum 3 characters):[/]");
        author = AnsiConsole.Ask<string>("[bold yellow]Author:[/]");
    }

    int year = 0;
    while (true)
    {
        year = AnsiConsole.Ask<int>("[bold yellow]Publication Year:[/]");
        if (year >= 0 && year <= DateTime.Now.Year)
        {
            break;
        }
        AnsiConsole.MarkupLine("[red]Invalid year. Please retry.[/]");
    }

    string type = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("[bold yellow]Enter the type (book or magazine):[/]")
            .AddChoices(new[] { "book", "magazine" }));

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
        AnsiConsole.MarkupLine("[green]The book has been successfully added![/]");
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
        AnsiConsole.MarkupLine("[green]The magazine has been successfully added![/]");
    }
}    static string Menu()
    {
    AnsiConsole.Clear();

        AnsiConsole.Write(
            new FigletText("Library Menu")
                .Centered()
                .Color(Color.Green));

        var selection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Please select a [green]menu option with arrows[/]")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
                .AddChoices(new[]
                {
                    "1. Manage",
                    "2. Registration",
                    "3. Library Reservations",
                    "4. Books",
                    "5. Magazines",
                    "6. Search",
                    "7. Users",
                    "0. Close"
                }));

        return selection[0].ToString();
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
        var reservationStatus = isReversed ? "[red]Reserved[/]" : "[green]Available[/]";
        return $"[bold yellow]Book Title:[/] {Title}, [bold yellow]Author:[/] {Author}, [bold yellow]Year:[/] {PublicationYear}, [bold yellow]ISBN:[/] {ISBN}, [bold yellow]Status:[/] {reservationStatus}";
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
        var reservationStatus = isReversed ? "[red]Reserved[/]" : "[green]Available[/]";
        return $"[bold yellow]Magazine Title:[/] {Title}, [bold yellow]Author:[/] {Author}, [bold yellow]Year:[/] {PublicationYear}, [bold yellow]Issue Number:[/] {IssueNumber}, [bold yellow]Status:[/] {reservationStatus}";
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