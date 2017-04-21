namespace Common.Strategies
{
	using System;

	public class TddStrategy : WorkStrategy
	{
		public override string StrategyText
		{
			get
			{
				return "Test driven design/development.";
			}
		}

		public override void StartStrategy()
		{
			Console.WriteLine("Good for you! TDD is the only way to go well.");
		}
	}
}