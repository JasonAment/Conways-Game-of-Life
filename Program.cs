using System;
using System.Collections.Generic;

namespace ConwaysGameOfLife
{
	//data structure to hold my Coordinants of each living or dead.
	public struct CoOrds
	{
		public int x;
		public int y;

		public CoOrds(int p1, int p2)
		{
			x = p1;
			y = p2;
		}
	}

	public class Zombies
	{
		public void RevealSurvivors(int width, int height, ref bool[,] grid)
		{
			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < height; j++)
				{
					Console.Write(grid[i, j] + "   ");
				}
				Console.WriteLine("");
				Console.WriteLine("");
			}
		}
		public int CountTheLiving(int width, int height, ref bool[,] individual, int i, int j)
		{
			//Console.WriteLine("Checking: " + i + "," + j);
			int count = 0; //Set the initial count to 0
			int top = i - 1; //gets the top edge
			int left = j - 1; //gets the left edge
			int right = j + 1; //gets the  right edge
			int bottom = i + 1; // gets the bottom edge
			if (top >= 0) //Is the top out of bounds?
			{
				//Top->left
				if (left >= 0 && individual[top, left]) count++;
				//Top
				if (individual[top, j]) count++;
				//Top->right
				if (right <= width && individual[top, right]) count++;
			}
			//Left
			if (left >= 0 && individual[i, left]) count++;
			//Right
			if (right <= width && individual[i, right]) count++;
			if (bottom <= height)
			{
				//Bottom->left
				if (left >= 0 && individual[bottom, left]) count++;
				//Bottom
				if (individual[bottom, j]) count++;
				//Bottom->right
				if (right <= width && individual[bottom, right]) count++;
			}
			return count;
		}
		//Cases:
		//1.Any live cell with fewer than two live neighbors dies, as if caused by under-population.
		//2.Any live cell with two or three live neighbors lives on to the next generation.
		//3.Any live cell with more than three live neighbors dies, as if by overcrowding.
		//4.Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.

		public void ZombiesAttack(int width, int height, ref bool[,] grid)
		{
			List<CoOrds> alive = new List<CoOrds>();
			List<CoOrds> dead = new List<CoOrds>();
			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("Starting Population after the Zombie Apocolypse: ");
			Console.WriteLine("");
			Console.WriteLine("");
			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < height; j++)
				{
					int nonZombies = CountTheLiving(width - 1, height - 1, ref grid, i, j);
					Console.Write(grid[i, j] + "   ");
					//First 3 cases
					if (grid[i, j]) //Cases 1-3 all have the same condition of "living", so wrapping all with an if statement.
					{
						if (!(nonZombies == 2 || nonZombies == 3))
						{
							//meets all of the conditions for 1,2,3
							dead.Add(new CoOrds(i, j));
						}
					}
					//Case 4: nonLiving and only 3
					if (nonZombies == 3 && !grid[i, j])
					{
						if (!grid[i, j])
						{
							alive.Add(new CoOrds(i, j));
						}
					}
				}
				Console.WriteLine("");
				Console.WriteLine("");
			}
			foreach (var e in alive)
			{
				grid[e.x, e.y] = true;
				//print out what is changing each time
				Console.WriteLine("Alive:" + e.x + "," + e.y);
			}
			foreach (var e in dead)
			{
				grid[e.x, e.y] = false;
				Console.WriteLine("Dead:" + e.x + "," + e.y);
			}
			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("Survivors:");
			Console.WriteLine("");
			Console.WriteLine("");
			RevealSurvivors(width, height, ref grid);
			Console.WriteLine("");
			Console.WriteLine("/********************************/");
		}
		class Program
		{
			static void Main(string[] args)
			{
				var foo = new bool[5, 5];
				foo[0, 0] = true;
				foo[0, 1] = false;
				foo[0, 2] = false;
				foo[0, 3] = false;
				foo[0, 4] = false;
				foo[1, 0] = false;
				foo[1, 1] = true;
				foo[1, 2] = false;
				foo[1, 3] = true;
				foo[1, 4] = false;
				foo[2, 0] = false;
				foo[2, 1] = true;
				foo[2, 2] = true;
				foo[2, 3] = false;
				foo[2, 4] = false;
				foo[3, 0] = false;
				foo[3, 1] = true;
				foo[3, 2] = false;
				foo[3, 3] = true;
				foo[3, 4] = false;
				foo[4, 0] = false;
				foo[4, 1] = false;
				foo[4, 2] = false;
				foo[4, 3] = false;
				foo[4, 4] = true;

				Zombies game = new Zombies();
				game.ZombiesAttack(5, 5, ref foo);

				game.ZombiesAttack(5, 5, ref foo);

				game.ZombiesAttack(5, 5, ref foo);

				game.ZombiesAttack(5, 5, ref foo);

				game.ZombiesAttack(5, 5, ref foo);

				game.ZombiesAttack(5, 5, ref foo);

				game.ZombiesAttack(5, 5, ref foo);

				game.ZombiesAttack(5, 5, ref foo);

			}
		}

	}
}
