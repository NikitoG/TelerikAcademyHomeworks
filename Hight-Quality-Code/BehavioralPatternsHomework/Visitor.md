# Visitor

## Обобщение

Този паблон ни позволява да добавяме функцониалност към различни обекти без да се налага модифицирането на обектите.

Шаблона се конструира чрез няколко задължителни участника:

- Посетител - интерфейсът който дефинира методи за всеки един от обектите
- Конкретен посетител - клас който имплементира интефейса Visitor
- Елемент - интерфейс който позволява на обектите да приемат "Посетител"
- Конкретен елемент - това са различните класове от структурата

## UML Клас диаграма

![UML class diagram]( https://upload.wikimedia.org/wikipedia/commons/thumb/b/b1/Visitor_UML_class_diagram.svg/624px-Visitor_UML_class_diagram.svg.png)

## Visitor

	  interface IVisitor
	  {
	    void Visit(Element element);
	  }

## Income visitor

      class IncomeVisitor : IVisitor
	  {
	    public void Visit(Element element)
	    {
	      Employee employee = element as Employee;
	 
	      employee.Income *= 1.10;
	      Console.WriteLine("{0} {1}'s new income: {2:C}",
	        employee.GetType().Name, employee.Name,
	        employee.Income);
	    }
	  }

## Vacation visitor

      class VacationVisitor : IVisitor
	  {
	    public void Visit(Element element)
	    {
	      Employee employee = element as Employee;
	 
	      Console.WriteLine("{0} {1}'s new vacation days: {2}",
	        employee.GetType().Name, employee.Name,
	        employee.VacationDays);
	    }
	  }

## Element

	  abstract class Element
	  {
	    public abstract void Accept(IVisitor visitor);
	  }

## Employee

	  class Employee : Element
	  {
	    private string name;
	    private double income;
	    private int vacationDays;
	 
	    public Employee(string name, double income,
	      int vacationDays)
	    {
	      this.Name = name;
	      this.Income = income;
	      this.VacationDays = vacationDays;
	    }
	 
	    public string Name
	    {
	      get { return name; }
	      set { name = value; }
	    }
	 
	    public double Income
	    {
	      get { return income; }
	      set { income = value; }
	    }
	 
	    public int VacationDays
	    {
	      get { return vacationDays; }
	      set { vacationDays = value; }
	    }
	 
	    public override void Accept(IVisitor visitor)
	    {
	      visitor.Visit(this);
	    }
	  }

## Employees

	  class Employees
	  {
	    private List<Employee> employees = new List<Employee>();
	 
	    public void Attach(Employee employee)
	    {
	      employees.Add(employee);
	    }
	 
	    public void Detach(Employee employee)
	    {
	      employees.Remove(employee);
	    }
	 
	    public void Accept(IVisitor visitor)
	    {
	      foreach (Employee e in employees)
	      {
	        e.Accept(visitor);
	      }
	      Console.WriteLine();
	    }
	  }

## Clerk

	  class Clerk : Employee
	  {
	    public Clerk()
	      : base("Hank", 25000.0, 14)
	    {
	    }
	  }

## Director

	  class Director : Employee
	  {
	    public Director()
	      : base("Elly", 35000.0, 16)
	    {
	    }
	  }

## President

	  class President : Employee
	  {
	    public President()
	      : base("Dick", 45000.0, 21)
	    {
	    }
	  }

## Usage

	  class MainApp
	  {
	    static void Main()
	    {
	      Employees e = new Employees();
	      e.Attach(new Clerk());
	      e.Attach(new Director());
	      e.Attach(new President());
	 
	      e.Accept(new IncomeVisitor());
	      e.Accept(new VacationVisitor());
	 
	      Console.ReadKey();
	    }
	  }

[GitHub](https://github.com/NikitoG/TelerikAcademyHomeworks/tree/master/Hight-Quality-Code/StructuralPatternsHomework)