using Launcher.Infrastructure.States;
using Launcher.Infrastructure.States.Factory;
using Launcher.Infrastructure.States.StatesMachine;
using UnityEngine;
using Zenject;

namespace Launcher.Infrastructure
{
	public class LauncherEnterPoint : MonoBehaviour
	{
		private ILauncherStatesSwitcher _launcherStatesSwitcher;
		private ILauncherStatesRegistrar _launcherStatesRegistrar;
		private ILauncherStatesFactory _launcherStatesFactory;

		[Inject]
		public void Constructor(ILauncherStatesRegistrar registrar, ILauncherStatesSwitcher switcher,
			ILauncherStatesFactory factory)
		{
			_launcherStatesSwitcher = switcher;
			_launcherStatesRegistrar = registrar;
			_launcherStatesFactory = factory;
		}


		private void Awake() => 
			StartLauncher();

		private void StartLauncher()
		{
			RegisterLauncherStates();
			EnterInLoadStaticDataState();
		}

		private void EnterInLoadStaticDataState() => 
			_launcherStatesSwitcher.SwitchState<LoadLauncherState>();

		private void RegisterLauncherStates() => 
			_launcherStatesRegistrar.RegisterState(_launcherStatesFactory.CreateLauncherState<LoadLauncherState>());
	}
}