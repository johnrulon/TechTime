namespace Common.Strategies
{
	using System;

	public class AllAloneStrategy : WorkStrategy
	{
		public override string StrategyText
		{
			get
			{
				return "All alone.";
			}
		}

		public override void StartStrategy()
		{
			Console.WriteLine("Good luck as you begin coding all by your lonesome!");
		}
	}
}