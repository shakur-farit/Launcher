using Zenject;

namespace Infrastructure.States.Factory
{
	public class LauncherStatesFactory : ILauncherStatesFactory
	{
		private IInstantiator _instantiator;

		public LauncherStatesFactory(IInstantiator instantiator) =>
			_instantiator = instantiator;

		public TState CreateLauncherState<TState>() where TState : IState =>
			_instantiator.Instantiate<TState>();
	}
}