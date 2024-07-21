using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Infrastructure.Services.SceneManagement;
using Infrastructure.Services.Score;
using Launcher.Hud.Factory;
using UnityEngine;

namespace Infrastructure.States
{
	public class LauncherState : IState
	{
		private readonly ILauncherHudFactory _launcherHudFactory;
		private readonly ISceneSwitcher _sceneSwitcher;
		private readonly IScoreService _scoreService;

		public LauncherState(ILauncherHudFactory launcherHudFactory, ISceneSwitcher sceneSwitcher, 
			IScoreService scoreService)
		{
			_launcherHudFactory = launcherHudFactory;
			_sceneSwitcher = sceneSwitcher;
			_scoreService = scoreService;
		}

		public async void Enter()
		{
			await SwitchScene();

			await CreateHud();
		}

		public void Exit() => 
			_launcherHudFactory.Destroy();

		private async UniTask SwitchScene() => 
			await _sceneSwitcher.SwitchSceneTo("Launcher");

		private async UniTask CreateHud() => 
			await _launcherHudFactory.CreateHud();
	}
}