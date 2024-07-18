namespace Infrastructure.States.Launcher.StatesMachine
{
	public interface ILauncherStatesRegistrar
	{
		void RegisterState<TState>(TState state) where TState : ILauncherState;
	}
}