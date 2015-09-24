# Strategy

## Обобщение

Чрез шаблона се дефинират взаимно заменяеми алгоритми, които решават един и същ проблем, но по различни начини, позволяваки да променяме поведението на обекта, който ги използва, без да променяме поведението на обекта, като и самия него. 

Шаблона се конструира чрез няколко задължителни участника:

- Стратегия - Декларира общ интерфейс за поддържаните алгоритми.
- КОнкретна стратегия - Имплементира интерфейса Strategy реализирайки конкретен алгоритъм.
- Контекст - държи референция към клас от тип Strategy


## UML Клас диаграма

![UML class diagram]( http://dofactory.com/images/diagrams/net/strategy.gif)

## Sort - Strategy

	  abstract class SortStrategy
	  {
	    public abstract void Sort(List<string> list);
	  }

## Quick Sort

	  class QuickSort : SortStrategy
	  {
	    public override void Sort(List<string> list)
	    {
	      list.Sort();
	      Console.WriteLine("QuickSorted list ");
	    }
	  }

## Shell sort

	  class ShellSort : SortStrategy
	  {
	    public override void Sort(List<string> list)
	    {
	      //list.ShellSort(); not-implemented
	      Console.WriteLine("ShellSorted list ");
	    }
	  }

## Merge sort

	  class MergeSort : SortStrategy
	  {
	    public override void Sort(List<string> list)
	    {
	      //list.MergeSort(); not-implemented
	      Console.WriteLine("MergeSorted list ");
	    }
	  }

## Sorted List

	  class SortedList
	  {
	    private List<string> list = new List<string>();
	    private SortStrategy sortstrategy;
	 
	    public void SetSortStrategy(SortStrategy sortstrategy)
	    {
	      this.sortstrategy = sortstrategy;
	    }
	 
	    public void Add(string name)
	    {
	      list.Add(name);
	    }
	 
	    public void Sort()
	    {
	      sortstrategy.Sort(list);
	 
	      foreach (string name in list)
	      {
	        Console.WriteLine(" " + name);
	      }
	      Console.WriteLine();
	    }
	  }

## Usage

    static void Main()
    {
      SortedList studentRecords = new SortedList();
 
      studentRecords.Add("Pesho");
      studentRecords.Add("Gosho");
      studentRecords.Add("John");
      studentRecords.Add("Nik");
      studentRecords.Add("Ana");
 
      studentRecords.SetSortStrategy(new QuickSort());
      studentRecords.Sort();
 
      studentRecords.SetSortStrategy(new ShellSort());
      studentRecords.Sort();
 
      studentRecords.SetSortStrategy(new MergeSort());
      studentRecords.Sort();
 
      Console.ReadKey();
    }

[GitHub](https://github.com/NikitoG/TelerikAcademyHomeworks/tree/master/Hight-Quality-Code/StructuralPatternsHomework)