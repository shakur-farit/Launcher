using Cysharp.Threading.Tasks;
using Infrastructure.Services.SceneManagement;
using Launcher.Hud.Factory;
using UnityEngine;

namespace Infrastructure.States
{
	public class LauncherState : IState
	{
		private readonly ILauncherHudFactory _launcherHudFactory;
		private readonly ISceneSwitcher _sceneSwitcher;

		public LauncherState(ILauncherHudFactory launcherHudFactory, ISceneSwitcher sceneSwitcher)
		{
			_launcherHudFactory = launcherHudFactory;
			_sceneSwitcher = sceneSwitcher;
		}

		public async void Enter()
		{
			Debug.Log(GetType());

			_sceneSwitcher.SwitchSceneTo("Launcher");

			await CreateHud();
		}

		public void Exit() => 
			_launcherHudFactory.Destroy();

		private async UniTask CreateHud() => 
			await _launcherHudFactory.CreateHud();
	}
}