# Template-Method

## Обобщение

Този паблон ни позволява да разделим имплементацията на алгоритъма на две нива.Логиката на алгоритъма е реализирана в базовия родителски клас. Поведението на обектите, специфично за конкретните наследници се имплементира в самите тях.


## UML Клас диаграма

![UML class diagram]( https://upload.wikimedia.org/wikipedia/commons/2/2a/Template_Method_UML_class_diagram.svg)

## Data Access

	  abstract class DataAccessObject
	  {
	    protected string connectionString;
	    protected DataSet dataSet;
	 
	    public virtual void Connect()
	    {
	      connectionString =
	        "provider=Microsoft.JET.OLEDB.4.0; " +
	        "data source=..\\..\\..\\db1.mdb";
	    }
	 
	    public abstract void Select();
	    public abstract void Process();
	 
	    public virtual void Disconnect()
	    {
	      connectionString = "";
	    }
	 
	    public void Run()
	    {
	      Connect();
	      Select();
	      Process();
	      Disconnect();
	    }
	  }

## Categories

	  class Categories : DataAccessObject
	  {
	    public override void Select()
	    {
	      string sql = "select CategoryName from Categories";
	      OleDbDataAdapter dataAdapter = new OleDbDataAdapter(
	        sql, connectionString);
	 
	      dataSet = new DataSet();
	      dataAdapter.Fill(dataSet, "Categories");
	    }
	 
	    public override void Process()
	    {
	      Console.WriteLine("Categories ---- ");
	 
	      DataTable dataTable = dataSet.Tables["Categories"];
	      foreach (DataRow row in dataTable.Rows)
	      {
	        Console.WriteLine(row["CategoryName"]);
	      }
	      Console.WriteLine();
	    }
	  }

## Product

	  class Products : DataAccessObject
	  {
	    public override void Select()
	    {
	      string sql = "select ProductName from Products";
	      OleDbDataAdapter dataAdapter = new OleDbDataAdapter(
	        sql, connectionString);
	 
	      dataSet = new DataSet();
	      dataAdapter.Fill(dataSet, "Products");
	    }
	 
	    public override void Process()
	    {
	      Console.WriteLine("Products ---- ");
	      DataTable dataTable = dataSet.Tables["Products"];
	      foreach (DataRow row in dataTable.Rows)
	      {
	        Console.WriteLine(row["ProductName"]);
	      }
	      Console.WriteLine();
	    }
	  }

## Usage

	  class MainApp
	  {
	    static void Main()
	    {
	      DataAccessObject daoCategories = new Categories();
	      daoCategories.Run();
	 
	      DataAccessObject daoProducts = new Products();
	      daoProducts.Run();
	 
	      Console.ReadKey();
	    }
	  }

[GitHub](https://github.com/NikitoG/TelerikAcademyHomeworks/tree/master/Hight-Quality-Code/StructuralPatternsHomework)