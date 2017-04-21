namespace Common.Strategies
{
	public abstract class WorkStrategy
	{
		public abstract string StrategyText { get; }

		public abstract void StartStrategy();
	}
}