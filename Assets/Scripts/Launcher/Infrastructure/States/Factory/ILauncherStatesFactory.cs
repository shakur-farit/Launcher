namespace Launcher.Infrastructure.States.Factory
{
	public interface ILauncherStatesFactory
	{
		TState CreateLauncherState<TState>() where TState : ILauncherState;
	}
}