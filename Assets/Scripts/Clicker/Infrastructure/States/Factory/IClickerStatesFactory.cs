namespace Clicker.Infrastructure.States.Factory
{
	public interface IClickerStatesFactory
	{
		TState CreateLauncherState<TState>() where TState : IClickerState;
	}
}