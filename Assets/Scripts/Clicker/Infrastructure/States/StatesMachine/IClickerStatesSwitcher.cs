using Clicker.Infrastructure.States.Factory;

namespace Clicker.Infrastructure.States.StatesMachine
{
	public interface IClickerStatesSwitcher
	{
		void SwitchState<TState>() where TState : IClickerState;
	}
}