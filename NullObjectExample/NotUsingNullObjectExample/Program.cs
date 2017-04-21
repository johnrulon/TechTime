namespace NotUsingNullObjectExample
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
				SharedConsoleIo.WriteInitialQuestion();
				int difficulty = SharedConsoleIo.GetDifficultyEntry();

				var workStrategy = WorkStrategyBuilder.DetermineStrategy(difficulty);

				// Run the strategy - have to do a null check
				if (workStrategy != null)
				{
					SharedConsoleIo.WriteStrategyThatShouldBeTried(workStrategy);
					SharedConsoleIo.WritePerformStrategyMessage();
					Console.ReadKey();

					workStrategy.StartStrategy();
				}

				Console.ReadKey();
			}
		}
	}
}
