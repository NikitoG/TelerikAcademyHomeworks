# Abstract Factory

## Обобщение

Абстрактната фабрика капсулира група от методи Фабрика имащи близко предназначение. Клиентският код създава конкретна имплементация на абстрактната фабрика, след това използва основния интерфейс за да създава конкренти обекти. Клиентът не е задължен да знае коя от тези фабрики е създала конкретния обект, защото той използва само основния интерфейс към създадените обекти.

Този шаблон позволява замяната на конкретни класове, дори по време на изпълнение, без да е нужна промяна на кода, който ги използва. Това обаче е за сметка на на допълнително усложняване на кода, което не е много желателно.


## UML Клас диаграма

![UML class diagram](http://www.bogotobogo.com/DesignPatterns/images/abstfactorymethod/Abstract_Factory_design_pattern.png)

## Continent

	  abstract class ContinentFactory
	  {
	    public abstract Herbivore CreateHerbivore();
	    public abstract Carnivore CreateCarnivore();
	  }

	  class AfricaFactory : ContinentFactory
	  {
	    public override Herbivore CreateHerbivore()
	    {
	      return new Wildebeest();
	    }
	    public override Carnivore CreateCarnivore()
	    {
	      return new Lion();
	    }
	  }

	  class AmericaFactory : ContinentFactory
	  {
	    public override Herbivore CreateHerbivore()
	    {
	      return new Bison();
	    }
	    public override Carnivore CreateCarnivore()
	    {
	      return new Wolf();
	    }
	  }


## Herbivore
	  abstract class Herbivore
	  {
	  }

	  class Wildebeest : Herbivore
	  {
	  }

	  class Bison : Herbivore
	  {
	  }
## Carnivore
	  abstract class Carnivore
	  {
	    public abstract void Eat(Herbivore h);
	  }
	 
	 
	  class Lion : Carnivore
	  {
	    public override void Eat(Herbivore h)
	    {
	      Console.WriteLine(this.GetType().Name +
	        " eats " + h.GetType().Name);
	    }
	  }
	 
	  class Wolf : Carnivore
	  {
	    public override void Eat(Herbivore h)
	    {
	      Console.WriteLine(this.GetType().Name +
	        " eats " + h.GetType().Name);
	    }
	  }
	 
## Animal

	  class AnimalWorld
	  {
	    private Herbivore herbivore;
	    private Carnivore carnivore;
	 
	    public AnimalWorld(ContinentFactory factory)
	    {
	      carnivore = factory.CreateCarnivore();
	      herbivore = factory.CreateHerbivore();
	    }
	 
	    public void RunFoodChain()
	    {
	      carnivore.Eat(_herbivore);
	    }
	  }



## Usage

	  class MainApp
	  {
	    public static void Main()
	    {
	      ContinentFactory africa = new AfricaFactory();
	      AnimalWorld world = new AnimalWorld(africa);
	      world.RunFoodChain();
	 
	      ContinentFactory america = new AmericaFactory();
	      world = new AnimalWorld(america);
	      world.RunFoodChain();
	 
	      Console.ReadKey();
	    }
	  }