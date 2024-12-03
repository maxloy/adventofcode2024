using System;
using System.IO;
using System.Text.RegularExpressions;

namespace AdventOfCode2024
{
	internal class Day3
	{
		public void Run()
		{
			Console.WriteLine("--Day three--");
			string input = File.ReadAllText("Input/Day3Input.txt");

			string mult_pattern = "mul\\(([0-9]+),([0-9]+)\\)";
			Regex mult_regex = new(mult_pattern);

			MatchCollection matches = mult_regex.Matches(input);
			int total = 0;
			foreach (Match match in matches)
			{
				total += ParseMult(match, 1, 2);
			}

			Console.WriteLine($"Part one: {total}");

			string do_pattern = "do\\(\\)";
			Regex do_regex = new(do_pattern);
			string dont_pattern = "don\\'t\\(\\)";
			Regex dont_regex = new(dont_pattern);
			string combined_pattern = $"({mult_pattern}|{do_pattern}|{dont_pattern})";
			Regex combined_regex = new(combined_pattern);
			bool enabled = true;
			total = 0;
			foreach (Match match in combined_regex.Matches(input))
			{
				if (enabled && dont_regex.IsMatch(match.Value))
				{
					enabled = false;
					continue;
				}
				if (!enabled && do_regex.IsMatch(match.Value))
				{
					enabled = true;
					continue;
				}
				if (enabled && mult_regex.IsMatch(match.Value))
				{
					int mult = ParseMult(match, 2, 3);
					total += mult;
				}
			}

			Console.WriteLine($"Part two: {total}");
		}

		private int ParseMult(Match match, int a_index, int b_index)
		{
			int numA = int.Parse(match.Groups[a_index].Value);
			int numB = int.Parse(match.Groups[b_index].Value);
			int mult = numA * numB;
			return mult;
		}
	}
}
