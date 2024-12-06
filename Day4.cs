using System;
using System.IO;

namespace AdventOfCode2024
{
	internal class Day4
	{
		public void Run()
		{
			Console.WriteLine("--Day four--");
			string input = File.ReadAllText("Input/Day4Input.txt");

			string xmas = "XMAS";

			string[] lines = input.Split('\n');

			{
				(int x, int y)[] directions = [(0, 1), (1, 1), (1, 0), (-1, 1), (-1, 0), (-1, -1), (0, -1), (1, -1)];

				int total = 0;
				for (int y = 0; y < lines.Length; y++)
				{
					for (int x = 0; x < lines[y].Length; x++)
					{
						for (int direction_index = 0; direction_index < directions.Length; direction_index++)
						{
							bool full_word = true;
							for (int word_index = 0; word_index < xmas.Length; word_index++)
							{
								int pos_x = x + directions[direction_index].x * word_index;
								int pos_y = y + directions[direction_index].y * word_index;

								if (!InBounds(lines, pos_x, pos_y))
								{
									full_word = false;
									break;
								}

								char c = lines[pos_y][pos_x];
								if (c != xmas[word_index])
								{
									full_word = false;
									break;
								}
							}

							if (full_word)
							{
								total++;
							}
						}
					}
				}
				Console.WriteLine($"Part one: {total}");
			}

			{
				(int x, int y)[] directions = [(1, 1), (1, -1), (-1, -1), (-1, 1)];
				string MAS = "MAS";

				int total = 0;
				for (int y = 0; y < lines.Length; y++)
				{
					for (int x = 0; x < lines[y].Length; x++)
					{
						if (lines[y][x] == 'A')
						{
							int match_count = 0; //we want two matches, specifically
							for (int direction_index = 0; direction_index < directions.Length; direction_index++)
							{
								bool fullword = true;
								for (int word_index = 0; word_index < MAS.Length; word_index++)
								{
									(int x, int y) direction = directions[direction_index];
									int pos_x = x + direction.x * (word_index - 1);
									int pos_y = y + direction.y * (word_index - 1);

									if (!InBounds(lines, pos_x, pos_y))
									{
										fullword = false;
										break;
									}

									char c = lines[pos_y][pos_x];
									if (c != MAS[word_index])
									{
										fullword = false;
										break;
									}
								}

								if (fullword)
								{
									match_count++;
								}
							}
							if (match_count == 2)
							{
								total++;
							}
						}
					}
				}

				Console.WriteLine($"Part two: {total}");
			}
		}

		private bool InBounds(string[] lines, int x, int y)
		{
			return y >= 0 && y < lines.Length && x >= 0 && x < lines[y].Length;
		}
	}
}
