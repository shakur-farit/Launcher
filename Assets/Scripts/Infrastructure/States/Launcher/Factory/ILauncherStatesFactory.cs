namespace Infrastructure.States.Launcher.Factory
{
	public interface ILauncherStatesFactory
	{
		TState CreateLauncherState<TState>() where TState : ILauncherState;
	}
}