using Clicker.Infrastructure.States.Factory;

namespace Clicker.Infrastructure.States.StatesMachine
{
	public interface IClickerStatesRegistrar
	{
		void RegisterState<TState>(TState state) where TState : IClickerState;
	}
}