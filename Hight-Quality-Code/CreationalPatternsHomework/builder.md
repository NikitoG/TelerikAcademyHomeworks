# Builder

## Обобщение
Builder Pattern-ът е създаващ шаблон за дизайн, който се използва в обектно-ориентираното програмиране.

Целта е да се раздели създаването на сложен обект от неговото представяне , за да може с един и същ процес да се създават обекти с различно представяне.

Използва се при необходимост от постъпково създаване на обекти.

## Предимства
- разделя отговорнoстите
- енкапсулация

## UML Клас диаграма

![UML class diagram](http://www.dofactory.com/images/diagrams/net/builder.gif)

## Shop

	class Shop
  	{
	    public void Construct(VehicleBuilder vehicleBuilder)
	    {
	      vehicleBuilder.BuildFrame();
	      vehicleBuilder.BuildEngine();
	      vehicleBuilder.BuildWheels();
	      vehicleBuilder.BuildDoors();
	    }
  	}

## Abstract Vehicle

	  abstract class VehicleBuilder
	  {
	    protected Vehicle vehicle;
	 
	    public Vehicle Vehicle
	    {
	      get { return vehicle; }
	    }
	 
	    public abstract void BuildFrame();
	    public abstract void BuildEngine();
	    public abstract void BuildWheels();
	    public abstract void BuildDoors();
	  }

## Motor

	  class MotorCycleBuilder : VehicleBuilder
	  {
	    public MotorCycleBuilder()
	    {
	      vehicle = new Vehicle("MotorCycle");
	    }
	 
	    public override void BuildFrame()
	    {
	      vehicle["frame"] = "MotorCycle Frame";
	    }
	 
	    public override void BuildEngine()
	    {
	      vehicle["engine"] = "500 cc";
	    }
	 
	    public override void BuildWheels()
	    {
	      vehicle["wheels"] = "2";
	    }
	 
	    public override void BuildDoors()
	    {
	      vehicle["doors"] = "0";
	    }
	  }

## Car
	  class CarBuilder : VehicleBuilder
	  {
	    public CarBuilder()
	    {
	      vehicle = new Vehicle("Car");
	    }
	 
	    public override void BuildFrame()
	    {
	      vehicle["frame"] = "Car Frame";
	    }
	 
	    public override void BuildEngine()
	    {
	      vehicle["engine"] = "2500 cc";
	    }
	 
	    public override void BuildWheels()
	    {
	      vehicle["wheels"] = "4";
	    }
	 
	    public override void BuildDoors()
	    {
	      vehicle["doors"] = "4";
	    }
	  }

## Scooter 

	  class ScooterBuilder : VehicleBuilder
	  {
	    public ScooterBuilder()
	    {
	      vehicle = new Vehicle("Scooter");
	    }
	 
	    public override void BuildFrame()
	    {
	      vehicle["frame"] = "Scooter Frame";
	    }
	 
	    public override void BuildEngine()
	    {
	      vehicle["engine"] = "50 cc";
	    }
	 
	    public override void BuildWheels()
	    {
	      vehicle["wheels"] = "2";
	    }
	 
	    public override void BuildDoors()
	    {
	      vehicle["doors"] = "0";
	    }
	  }

## Vehicle

	  class Vehicle
	  {
	    private string _vehicleType;
	    private Dictionary<string,string> _parts = 
	      new Dictionary<string,string>();
	 
	    // Constructor
	    public Vehicle(string vehicleType)
	    {
	      this._vehicleType = vehicleType;
	    }
	 
	    // Indexer
	    public string this[string key]
	    {
	      get { return _parts[key]; }
	      set { _parts[key] = value; }
	    }
	 
	    public void Show()
	    {
	      Console.WriteLine("\n---------------------------");
	      Console.WriteLine("Vehicle Type: {0}", _vehicleType);
	      Console.WriteLine(" Frame : {0}", _parts["frame"]);
	      Console.WriteLine(" Engine : {0}", _parts["engine"]);
	      Console.WriteLine(" #Wheels: {0}", _parts["wheels"]);
	      Console.WriteLine(" #Doors : {0}", _parts["doors"]);
	    }
	  }

## Usage

 
    public static void Main()
    {
      VehicleBuilder builder;
 
      Shop shop = new Shop();

      builder = new ScooterBuilder();
      shop.Construct(builder);
      builder.Vehicle.Show();
 
      builder = new CarBuilder();
      shop.Construct(builder);
      builder.Vehicle.Show();
 
      builder = new MotorCycleBuilder();
      shop.Construct(builder);
      builder.Vehicle.Show();

      Console.ReadKey();
    }


[GitHub](https://github.com/NikitoG/TelerikAcademyHomeworks/tree/master/Hight-Quality-Code/CreationalPatternsHomework)