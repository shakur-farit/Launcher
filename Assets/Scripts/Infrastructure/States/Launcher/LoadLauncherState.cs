using UI.Launcher.Factory;
using UnityEngine;

namespace Infrastructure.States.Launcher
{
	public class LoadLauncherState : ILauncherState
	{
		private readonly ILauncherUIFactory _launcherUIFactory;

		public LoadLauncherState(ILauncherUIFactory launcherUIFactory) => 
			_launcherUIFactory = launcherUIFactory;

		public void Enter()
		{
			Debug.Log(GetType());

			_launcherUIFactory.CreateUIRoot();
		}

		public void Exit()
		{
		}
	}
}