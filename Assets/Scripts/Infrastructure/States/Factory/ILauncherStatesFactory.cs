namespace Infrastructure.States.Factory
{
	public interface ILauncherStatesFactory
	{
		TState CreateLauncherState<TState>() where TState : IState;
	}
}