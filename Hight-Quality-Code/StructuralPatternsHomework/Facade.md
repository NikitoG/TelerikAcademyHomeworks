# Facade

## Обобщение

Целта на този шаблон е да предостави на клиента опростен публичен интерфейс за взаимодействие със сложна подсистема. 

- създаването на фасада дава достъп само до необходимата функционалност и скрива сложността на системата.
- поставянето на фасада премахва директната зависимост между клиент и система
- при необходимост от няколко метода за да получим резултат


## UML Клас диаграма

![UML class diagram]( http://kevanstannard.github.io/coldfusion-design-patterns/assets/images/B7392941556C20996375595C78D5319A.png)

## Bank

	  class Bank
	  {
	    public bool HasSufficientSavings(Customer c, int amount)
	    {
	      Console.WriteLine("Check bank for " + c.Name);
	      return true;
	    }
	  }

## Credit

	  class Credit
	  {
	    public bool HasGoodCredit(Customer c)
	    {
	      Console.WriteLine("Check credit for " + c.Name);
	      return true;
	    }
	  }

## Loan

	  class Loan
	  {
	    public bool HasNoBadLoans(Customer c)
	    {
	      Console.WriteLine("Check loans for " + c.Name);
	      return true;
	    }
	  }

## Customer
	
	  class Customer
	  {
	    private string name;
	 
	    public Customer(string name)
	    {
	      this.name = name;
	    }
	 
	    public string Name
	    {
	      get { return name; }
	    }
	  }

## Mortgage(Facade)
	
	class Mortgage
	{
		private Bank bank = new Bank();
		private Loan loan = new Loan();
		private Credit credit = new Credit();
		
		public bool IsEligible(Customer cust, int amount)
		{
		  Console.WriteLine("{0} applies for {1:C} loan\n",
		    cust.Name, amount);
		
		  bool eligible = true;
		
		  if (!bank.HasSufficientSavings(cust, amount))
		  {
		    eligible = false;
		  }
		  else if (!loan.HasNoBadLoans(cust))
		  {
		    eligible = false;
		  }
		  else if (!credit.HasGoodCredit(cust))
		  {
		    eligible = false;
		  }
		
		  return eligible;
		}
	}

## Usage

	  class MainApp
	  {
	    static void Main()
	    {
	      Mortgage mortgage = new Mortgage();
	 
	      Customer customer = new Customer("John Doe");
	      bool eligible = mortgage.IsEligible(customer, 200000);
	 
	      Console.WriteLine("\n" + customer.Name +
	          " has been " + (eligible ? "Approved" : "Rejected"));
	 
	      Console.ReadKey();
	    }
	  }

[GitHub](https://github.com/NikitoG/TelerikAcademyHomeworks/tree/master/Hight-Quality-Code/StructuralPatternsHomework)