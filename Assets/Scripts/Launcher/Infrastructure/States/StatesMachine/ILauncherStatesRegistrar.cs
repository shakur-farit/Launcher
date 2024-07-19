namespace Launcher.Infrastructure.States.StatesMachine
{
	public interface ILauncherStatesRegistrar
	{
		void RegisterState<TState>(TState state) where TState : ILauncherState;
	}
}