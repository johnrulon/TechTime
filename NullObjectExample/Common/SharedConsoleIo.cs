namespace Common
{
	using System;

	public static class SharedConsoleIo
	{
		public static void WriteInitialQuestion()
		{
			Console.Write("\r\nWhat is the difficulty of the given task? (0-3 scale with 3 being the hardest");
		}

		public static void WriteStrategyThatShouldBeTried(Strategies.WorkStrategy strategy)
		{
			Console.WriteLine("Try the following Strategy: '{0}'", strategy.StrategyText);
		}

		public static int GetDifficultyEntry()
		{
			string difficultyValue = Console.ReadLine();
			return int.Parse(difficultyValue);
		}

		public static void WritePerformStrategyMessage()
		{
			Console.WriteLine("\r\nPress a button to perform the strategy: ");
		}
	}
}
