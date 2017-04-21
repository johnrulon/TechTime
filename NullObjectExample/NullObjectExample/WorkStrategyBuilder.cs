namespace NullObjectExample
{
	using Common.Strategies;

	public static class WorkStrategyBuilder
	{
		public static WorkStrategy DetermineStrategy(int difficulty)
		{
			switch (difficulty)
			{
				case 0:
					return new AllAloneStrategy();
				case 1:
					return new TddStrategy();
				case 2:
					return new PairProgramStrategy();
				case 3:
					return new EatIceCreamStrategy();
				default:
					return new NullWorkStrategy();
			}
		}
	}
}