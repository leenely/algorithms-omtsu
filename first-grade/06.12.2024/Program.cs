using System;
namespace Task
{
		class Task 
		{
		public int x;
		public int y;

		public Task() 
		{
			this.x = 0;
			this.y = 0;	
		}
		public Task(int x) 
		{
			this.x = x;
			this.y = 0;
		}

		public Task(int x, int y) 
		{
			this.x = x;
			this.y = y;
		}

		public void Summ()
		{
			Console.WriteLine(x + y);
		}

		public void Divide()
		{
			if (y == 0)
			{
				Console.WriteLine("Деление на ноль невозможно");
			}
			else
			{
				Console.WriteLine(x/y);
			}
			
		}

		public void Subtraction()
		{
			Console.WriteLine(y - x);
		}
	}

	class Program 
	{
		static void Main(string[] args) 
		{
			Console.WriteLine("---");
			Task task = new Task();
			Console.WriteLine($"{task.x} {task.y}");
			task.Summ();
			task.Divide();
			task.Subtraction();

			Console.WriteLine("---");
			Task task2 = new Task(7);
			Console.WriteLine($"{task2.x} {task2.y}");
			task2.Summ();
			task2.Divide();
			task2.Subtraction();

			Console.WriteLine("---");
			Task task3 = new Task(10, 5);
			Console.WriteLine($"{task3.x} {task3.y}");
			task3.Summ();
			task3.Divide();
			task3.Subtraction();
		}
	}
}