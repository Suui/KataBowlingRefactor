namespace KataBowlingTwo
{
	public class Score
	{
		public static int For(string line)
		{
			var score = 0;
			var previousScore = 0;
			for (var i = 0; i < line.Length; i++)
			{
				if (line[i].Equals('X'))
				{
					var nextRoll = line[i + 1].Equals('-') ? 0
								   : line[i + 1].Equals('X') ? 10
									 : int.Parse(line[i + 1].ToString());

					var secondNextRoll = line[i + 2].Equals('-') ? 0
										 : line[i + 2].Equals('X') ? 10
										   : line[i + 2].Equals('/') && line[i + 1].Equals('-') ? 10
											 : line[i + 2].Equals('/') && !line[i + 1].Equals('-') ? 10 - int.Parse(line[i + 1].ToString())
											   : int.Parse(line[i + 2].ToString());

					score += 10 + nextRoll + secondNextRoll;
					if (i + 2 == line.Length - 1) break;
					previousScore = score;
					continue;
				}

				if (line[i].Equals('/'))
				{
					var nextRoll = line[i + 1].Equals('-') ? 0
								   : line[i + 1].Equals('X') ? 10
									 : int.Parse(line[i + 1].ToString());

					score = previousScore + 10 + nextRoll;
					if (i + 1 == line.Length - 1) break;
					previousScore = score;
					continue;
				}

				previousScore = score;
				if (line[i].Equals('-')) continue;
				score += int.Parse(line[i].ToString());
			}

			return score;
		}
	}
}