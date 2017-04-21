namespace NullObjectExample
{
	using System;

	using Common;

	public class Program
	{
		public static void Main(string[] args)
		{
			// simply to one up Andrew's do while loop
			while (true) 
			{
				{
					SharedConsoleIo.WriteInitialQuestion();
					int difficulty = SharedConsoleIo.GetDifficultyEntry();

					var workStrategy = WorkStrategyBuilder.DetermineStrategy(difficulty);

					// Run the strategy - no null check required!
					SharedConsoleIo.WriteStrategyThatShouldBeTried(workStrategy);
					SharedConsoleIo.WritePerformStrategyMessage();
					Console.ReadKey();

					workStrategy.StartStrategy();

					Console.ReadKey();
				}
			}
		}
	}
}
