using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2024
{
	internal class Day1
	{

		public void Run()
		{
			Console.WriteLine("--Day one--");

			string input = File.ReadAllText("Input/Day1Input.txt");

			string[] lines = input.Split('\n');
			List<int> left_list = [];
			List<int> right_list = [];
			foreach (string line in lines)
			{
				string[] pair = line.Split(" ");
				int numA = int.Parse(pair[0]);
				int numB = int.Parse(pair[^1]);
				left_list.Add(numA);
				right_list.Add(numB);
			}

			left_list = left_list.OrderBy(x => x).ToList();
			right_list = right_list.OrderBy(x => x).ToList();

			int total = 0;
			for (int i = 0; i < left_list.Count; i++)
			{
				int diff = Math.Abs(left_list[i] - right_list[i]);
				total += diff;
			}
			Console.WriteLine($"Part one: {total}");

			int similarity_score = 0;
			foreach (int i in left_list)
			{
				int occurrences = right_list.Count(x => x == i);
				int local_score = i * occurrences;
				similarity_score += local_score;
			}
			Console.WriteLine($"Part two: {similarity_score}");
		}
	}
}
