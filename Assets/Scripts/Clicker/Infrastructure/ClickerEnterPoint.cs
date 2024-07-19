using Clicker.Infrastructure.States;
using Clicker.Infrastructure.States.Factory;
using Clicker.Infrastructure.States.StatesMachine;
using UnityEngine;
using Zenject;

namespace Clicker.Infrastructure
{
	public class ClickerEnterPoint : MonoBehaviour
	{
		private IClickerStatesSwitcher _clickerStatesSwitcher;
		private IClickerStatesRegistrar _clickerStatesRegistrar;
		private IClickerStatesFactory _clickerStatesFactory;

		[Inject]
		public void Constructor(IClickerStatesRegistrar registrar, IClickerStatesSwitcher switcher,
			IClickerStatesFactory factory)
		{
			_clickerStatesSwitcher = switcher;
			_clickerStatesRegistrar = registrar;
			_clickerStatesFactory = factory;
		}


		private void Awake() =>
			StartLauncher();

		private void StartLauncher()
		{
			RegisterLauncherStates();
			EnterInLoadStaticDataState();
		}

		private void EnterInLoadStaticDataState() =>
			_clickerStatesSwitcher.SwitchState<LoadClickerState>();

		private void RegisterLauncherStates() =>
			_clickerStatesRegistrar.RegisterState(_clickerStatesFactory.CreateLauncherState<LoadClickerState>());
	}
}