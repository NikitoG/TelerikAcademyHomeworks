# Singleton

## Обобщение

 Това е клас който ни позволява един класа да има една единствена инстанция в цялата програма.

Този шаблон се използва обикновено в моделирането на обекти, които трябва да бъдат глобално достъпни за обектите на приложението (например обекта съдържащ структурите с настройките на програмата) или обекти, които се нуждаят от максимално късна инициализация за пестенето на ресурси от паметта.

 Има критики откъм използването на Сек, като някои го смятат за анти-модел. Съди се, че е преизползван  и въвежда  ненужни ограничения в ситуации, където например  класа не е наистина необходим и въвежда глобално условни в апликацията.


## UML Клас диаграма

![UML class diagram](http://drusantia.com/wp-content/uploads/2015/03/Singleton.jpg)

## Load Balancer

	class LoadBalancer
	  {
	    private static LoadBalancer instance;
	    private List<string> servers = new List<string>();
	    private Random random = new Random();
	 
	    private static object syncLock = new object();
	 
	    protected LoadBalancer()
	    {
	      servers.Add("ServerI");
	      servers.Add("ServerII");
	      servers.Add("ServerIII");
	      servers.Add("ServerIV");
	      servers.Add("ServerV");
	    }
	 
	    public static LoadBalancer GetLoadBalancer()
	    {
	      if (instance == null)
	      {
	        lock (syncLock)
	        {
	          if (instance == null)
	          {
	            instance = new LoadBalancer();
	          }
	        }
	      }
	 
	      return instance;
	    }
	 
	    public string Server
	    {
	      get
	      {
	        int r = random.Next(servers.Count);
	        return servers[r].ToString();
	      }
	    }
	  }

## Usage

	  class MainApp
	  {
	    static void Main()
	    {
	      LoadBalancer b1 = LoadBalancer.GetLoadBalancer();
	      LoadBalancer b2 = LoadBalancer.GetLoadBalancer();
	      LoadBalancer b3 = LoadBalancer.GetLoadBalancer();
	      LoadBalancer b4 = LoadBalancer.GetLoadBalancer();
	 
	      if (b1 == b2 && b2 == b3 && b3 == b4)
	      {
	        Console.WriteLine("Same instance\n");
	      }
	 
	      
	      LoadBalancer balancer = LoadBalancer.GetLoadBalancer();
	      for (int i = 0; i < 15; i++)
	      {
	        string server = balancer.Server;
	        Console.WriteLine("Dispatch Request to: " + server);
	      }
	 
	      
	      Console.ReadKey();
	    }
	  }



[GitHub](https://github.com/NikitoG/TelerikAcademyHomeworks/tree/master/Hight-Quality-Code/CreationalPatternsHomework)