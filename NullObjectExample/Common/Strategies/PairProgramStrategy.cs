namespace Common.Strategies
{
	using System;

	public class PairProgramStrategy : WorkStrategy
	{
		public override string StrategyText
		{
			get
			{
				return "Pair program.";
			}
		}

		public override void StartStrategy()
		{
			Console.WriteLine("Everything is cool when you're part of team.");
		}
	}
}