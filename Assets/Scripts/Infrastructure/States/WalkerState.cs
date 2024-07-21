using Cysharp.Threading.Tasks;
using Infrastructure.Services.SceneManagement;
using Infrastructure.Services.Score;
using UnityEngine;
using Walker.Character.Factory;
using Walker.Environment.Factory;
using Walker.Hud.Factory;
using Walker.UI.Factory;

namespace Infrastructure.States
{
	public class WalkerState : IState
	{
		private const string WalkerScene = "Walker";

		private readonly ISceneSwitcher _sceneSwitcher;
		private readonly IWalkerUIFactory _uiFactory;
		private readonly IWalkerHudFactory _hudFactory;
		private readonly IWalkerEnvironmentFactory _environmentFactory;
		private readonly IWalkerCharacterFactory _characterFactory;
		private readonly ITimerService _timerService;

		public WalkerState(IWalkerUIFactory uiFactory, ISceneSwitcher sceneSwitcher, IWalkerHudFactory hudFactory,
			IWalkerEnvironmentFactory environmentFactory, IWalkerCharacterFactory characterFactory, 
			ITimerService timerService)
		{
			_uiFactory = uiFactory;
			_sceneSwitcher = sceneSwitcher;
			_hudFactory = hudFactory;
			_environmentFactory = environmentFactory;
			_characterFactory = characterFactory;
			_timerService = timerService;
		}

		public async void Enter()
		{
			await SwitchScene();
			await CreateUIRoot();
			await CreateHud();
			await CreateEnvironment();
			await CreateCharacter();
			await _timerService.Start();
		}

		public void Exit() => 
			DestroyObjects();

		private async UniTask SwitchScene() => 
			await _sceneSwitcher.SwitchSceneTo(WalkerScene);

		private async UniTask CreateUIRoot() => 
			await _uiFactory.CreateUIRoot();

		private async UniTask CreateHud() => 
			await _hudFactory.CreateHud();

		private async UniTask CreateEnvironment() => 
			await _environmentFactory.CreateEnvironment();

		private async UniTask CreateCharacter() => 
			await _characterFactory.CreateCharacter();

		private void DestroyObjects()
		{
			_uiFactory.DestroyUIRoot();
			_hudFactory.Destroy();
			_characterFactory.Destroy();
			_environmentFactory.DestroyEnvironment();
		}
	}
}