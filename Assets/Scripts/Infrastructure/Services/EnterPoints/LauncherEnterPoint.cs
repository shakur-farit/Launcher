using Infrastructure.States.Launcher;
using Infrastructure.States.Launcher.Factory;
using Infrastructure.States.Launcher.StatesMachine;
using UnityEngine;
using Zenject;

namespace Infrastructure.Services.EnterPoints
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