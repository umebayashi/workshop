using System;

namespace FizzBuzz
{
	class Program
	{
		static void Main(string[] args)
		{
			for (int i = 1; i <= 100; i++)
			{
				bool fizzbuzz = false;
				if (i % 3 == 0)
				{
					Console.Write("Fizz");
					fizzbuzz = true;
				}
				if (i % 5 == 0)
				{
					Console.Write("Buzz");
					fizzbuzz = true;
				}
				if (!fizzbuzz)
				{
					Console.Write(i);
				}
				Console.WriteLine();
			}
		}
	}
}
