using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2024
{
	internal class Day2
	{
		public void Run()
		{
			Console.WriteLine("--Day two--");
			string input = File.ReadAllText("Input/Day2Input.txt");
			string[] reports = input.Split('\n');

			int safe_count = 0;
			int damped_safe_count = 0;
			foreach (string report in reports)
			{
				List<int> levels = report.Split(' ').Select(int.Parse).ToList();

				if (IsSafe(levels))
				{
					safe_count++;
					damped_safe_count++;
				}
				else
				{
					for (int i = 0; i < levels.Count; i++)
					{
						List<int> damped_list = levels.ToList();
						damped_list.RemoveAt(i);
						if (IsSafe(damped_list))
						{
							damped_safe_count++;
							break;
						}
					}
				}
			}

			Console.WriteLine($"Part 1: {safe_count}");
			Console.WriteLine($"Part 2: {damped_safe_count}");

		}

		private bool IsSafe(List<int> levels)
		{
			bool increasing = levels[1] > levels[0];
			for (int i = 0; i < levels.Count - 1; i++)
			{
				int current = levels[i];
				int next = levels[i + 1];

				if (increasing && next < current)
				{
					return false;
				}
				else if (!increasing && next > current)
				{
					return false;
				}

				int diff = Math.Abs(next - current);
				if (diff is < 1 or > 3)
				{
					return false;
				}
			}

			return true;
		}
	}
}
