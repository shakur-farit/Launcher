
using Zenject;

namespace Clicker.Infrastructure.States.Factory
{
	public class ClickerStatesFactory : IClickerStatesFactory
	{
		private IInstantiator _instantiator;

		public ClickerStatesFactory(IInstantiator instantiator) =>
			_instantiator = instantiator;

		public TState CreateLauncherState<TState>() where TState : IClickerState =>
			_instantiator.Instantiate<TState>();
	}
}