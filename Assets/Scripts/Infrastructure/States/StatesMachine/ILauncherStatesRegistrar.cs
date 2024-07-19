namespace Infrastructure.States.StatesMachine
{
	public interface ILauncherStatesRegistrar
	{
		void RegisterState<TState>(TState state) where TState : IState;
	}
}