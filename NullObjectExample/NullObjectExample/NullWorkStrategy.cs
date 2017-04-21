namespace NullObjectExample
{
	using System;

	using Common.Strategies;

	public class NullWorkStrategy : WorkStrategy
	{
		public override string StrategyText
		{
			get
			{
				return "...";
			}
		}

		public override void StartStrategy()
		{
			// do nothing
			Console.WriteLine("Null strategy.");
		}
	}
}