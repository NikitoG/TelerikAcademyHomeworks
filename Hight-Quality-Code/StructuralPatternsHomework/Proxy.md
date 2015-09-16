# Proxy

## Обобщение

Този паблон ни позволява да контролираме достъпа до обектите в нашата програма. Използва се като се предоставя контейнер за даден реален обект, като по този начин имаме контролиран достъп до него.

### Описание
- държи референция към реалния предмет
- предоставя интерфейс еднакъв с оригиналния
- контролира достъпа до оригиналния предмет и при необходимост го създава и инициализира
- видове: отдалечени, виртуални, защитни, умни, синхронизиращи

## UML Клас диаграма

![UML class diagram]( https://upload.wikimedia.org/wikipedia/commons/thumb/e/e9/Decorator_UML_class_diagram.svg/757px-Decorator_UML_class_diagram.svg.png)

## Library item

	interface ICar
	{
	  void DriveCar();
	}

## Car

	public class Car : ICar
	{
	    public void DriveCar()
	    {
	        Console.WriteLine("Car has been driven!");
	    }
	}

## Proxy car

	public class ProxyCar : ICar
	{
	    private Driver driver;
	    private ICar realCar;
	
	    public ProxyCar(Driver driver)
	    {
	        this.driver = driver;
	        realCar = new Car();
	    }
	
	    void ICar.DriveCar()
	    {
	        if (driver.Age <= 16)
			{
	            Console.WriteLine("Sorry, the driver is too young to drive.");
			}
	        else
			{
	            realCar.DriveCar();
			}
	     }
	}

## Driver

	public class Driver
	{
	    public int Age { get; set; }
	
	    public Driver(int age)
	    {
	        this.Age = age;
	    }
	}

## Usage

	  class MainApp
	  {
	    static void Main()
	    {
		    ICar car = new ProxyCar(new Driver(16));
		    car.DriveCar();
		
		    car = new ProxyCar(new Driver(25));
		    car.DriveCar();
	    }
	  }

[GitHub](https://github.com/NikitoG/TelerikAcademyHomeworks/tree/master/Hight-Quality-Code/StructuralPatternsHomework)