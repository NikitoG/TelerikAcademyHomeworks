# Decorator

## Обобщение

Декораторът добавя нова функционалност към даден обект динамично без да променя класа към който принадлежи. За да се избегне драстичното увеличение на класове при решението на подобна задача чрез наследяване може да се използва този шаблон, който изходния обект се обвиа от друг обект.

- Декораторът и декорирания обект трябва да имплементират един и същ интерфейс
- Декораторът вътрешно държи променлива от типа на декорирания обект и пренасочва всички заявки към него.

## UML Клас диаграма

![UML class diagram]( https://upload.wikimedia.org/wikipedia/commons/thumb/e/e9/Decorator_UML_class_diagram.svg/757px-Decorator_UML_class_diagram.svg.png)

## Library item

	  abstract class LibraryItem
	  {
	    public int NumCopies { get; set; }
	 
	    public abstract void Display();
	  }

## Book

	  class Book : LibraryItem
	  {
	    private string author;
	    private string title;
	 
	    public Book(string author, string title, int numCopies)
	    {
	      this.author = author;
	      this.title = title;
	      this.NumCopies = numCopies;
	    }
	 
	    public override void Display()
	    {
	      Console.WriteLine("\nBook ------ ");
	      Console.WriteLine(" Author: {0}", author);
	      Console.WriteLine(" Title: {0}", title);
	      Console.WriteLine(" # Copies: {0}", NumCopies);
	    }
	  }

## Video

	  class Video : LibraryItem
	  {
	    private string director;
	    private string title;
	    private int playTime;
	 
	    public Video(string director, string title,
	      int numCopies, int playTime)
	    {
	      this.director = director;
	      this.title = title;
	      this.NumCopies = numCopies;
	      this.playTime = playTime;
	    }
	 
	    public override void Display()
	    {
	      Console.WriteLine("\nVideo ----- ");
	      Console.WriteLine(" Director: {0}", director);
	      Console.WriteLine(" Title: {0}", title);
	      Console.WriteLine(" # Copies: {0}", NumCopies);
	      Console.WriteLine(" Playtime: {0}\n", playTime);
	    }
	  }

## Decorator (abstract class)

	  abstract class Decorator : LibraryItem
	  {
	    protected LibraryItem libraryItem;
	 
	    public Decorator(LibraryItem libraryItem)
	    {
	      this.libraryItem = libraryItem;
	    }
	 
	    public override void Display()
	    {
	      libraryItem.Display();
	    }
	  }

## Borrowable

	  class Borrowable : Decorator
	  {
	    protected List<string> borrowers = new List<string>();
	 
	    public Borrowable(LibraryItem libraryItem)
	      : base(libraryItem)
	    {
	    }
	 
	    public void BorrowItem(string name)
	    {
	      borrowers.Add(name);
	      libraryItem.NumCopies--;
	    }
	 
	    public void ReturnItem(string name)
	    {
	      borrowers.Remove(name);
	      libraryItem.NumCopies++;
	    }
	 
	    public override void Display()
	    {
	      base.Display();
	 
	      foreach (string borrower in borrowers)
	      {
	        Console.WriteLine(" borrower: " + borrower);
	      }
	    }
	  }

## Usage

	  class MainApp
	  {
	    static void Main()
	    {
	      Book book = new Book("Worley", "Inside ASP.NET", 10);
	      book.Display();
	 
	      Video video = new Video("Spielberg", "Jaws", 23, 92);
	      video.Display();
	 
	      Console.WriteLine("\nMaking video borrowable:");
	 
	      Borrowable borrowvideo = new Borrowable(video);
	      borrowvideo.BorrowItem("Customer #1");
	      borrowvideo.BorrowItem("Customer #2");
	 
	      borrowvideo.Display();
	 
	      Console.ReadKey();
	    }
	  }

[GitHub](https://github.com/NikitoG/TelerikAcademyHomeworks/tree/master/Hight-Quality-Code/StructuralPatternsHomework)