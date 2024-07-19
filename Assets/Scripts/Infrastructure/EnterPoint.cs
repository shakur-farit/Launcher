using Infrastructure.States;
using Infrastructure.States.Factory;
using Infrastructure.States.StatesMachine;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
	public class EnterPoint : MonoBehaviour
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


		private void Awake()
		{
			DontDestroyOnLoad(this);

			StartLauncher();
		}

		private void StartLauncher()
		{
			RegisterLauncherStates();
			EnterInLoadStaticDataState();
		}

		private void EnterInLoadStaticDataState() => 
			_launcherStatesSwitcher.SwitchState<WarmUp>();

		private void RegisterLauncherStates()
		{
			_launcherStatesRegistrar.RegisterState(_launcherStatesFactory.CreateLauncherState<WarmUp>());
			_launcherStatesRegistrar.RegisterState(_launcherStatesFactory.CreateLauncherState<LauncherState>());
			_launcherStatesRegistrar.RegisterState(_launcherStatesFactory.CreateLauncherState<ClickerState>());
			_launcherStatesRegistrar.RegisterState(_launcherStatesFactory.CreateLauncherState<WalkerState>());
		}
	}
}