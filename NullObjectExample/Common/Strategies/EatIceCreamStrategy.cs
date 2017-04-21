namespace Common.Strategies
{
	using System;

	public class EatIceCreamStrategy : WorkStrategy
	{
		public override string StrategyText
		{
			get
			{
				return "Eat Ice Cream first, then start coding.";
			}
		}

		public override void StartStrategy()
		{
			Console.WriteLine("Yum...");
		}
	}
}