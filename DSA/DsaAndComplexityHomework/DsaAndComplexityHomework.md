## Data Structures, Algorithms and Complexity Homework

1. **What is the expected running time of the following C# code?**
  - Explain why using Markdown.
  - Assume the array's size is `n`.
	
			  long Compute(int[] arr)
			  {
			      long count = 0;
			      for (int i=0; i<arr.Length; i++)
			      {
			          int start = 0, end = arr.Length-1;
			          while (start < end)
			              if (arr[start] < arr[end])
			                  { start++; count++; }
			              else 
			                  end--;
			      }
			      return count;
			  }

	

	- Runs in O(n^2) where n is the size of the array
	- The number of elementary steps is ~n*n, because for each n we will have another n operations

2. **What is the expected running time of the following C# code?**
  - Explain why using Markdown.
  - Assume the input matrix has size of `n * m`.

			  long CalcCount(int[,] matrix)
			  {
			      long count = 0;
			      for (int row=0; row<matrix.GetLength(0); row++)
			          if (matrix[row, 0] % 2 == 0)
			              for (int col=0; col<matrix.GetLength(1); col++)
			                  if (matrix[row,col] > 0)
			                      count++;
			      return count;
			  }

	- Runs in quadratic time O(n*m)
	- The number of elementary steps is ~n*m in worst-case where first element in every row is even 


3. (*) What is the expected running time of the following C# code?
  - Explain why using Markdown.
  - Assume the input matrix has size of `n * m`.

			  long CalcSum(int[,] matrix, int row)
			  {
			      long sum = 0;
			      for (int col = 0; col < matrix.GetLength(0); col++) 
			          sum += matrix[row, col];
			      if (row + 1 < matrix.GetLength(1)) 
			          sum += CalcSum(matrix, row + 1);
			      return sum;
			  }
			  
			  Console.WriteLine(CalcSum(matrix, 0));

	- Runs in quadratic time O(n*m)
	- The number of elementary steps is ~n*(m - row) in worst-case row = 0; 