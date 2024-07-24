using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SceneManagement;
using Infrastructure.Services.Score;
using Infrastructure.Services.Timer;
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
		private readonly IPersistentProgressService _persistemtProgressService;
		private readonly IAssetsReferencesHandler _handler;
		private readonly IAssetsProvider _assetsProvider;

		public WalkerState(IWalkerUIFactory uiFactory, ISceneSwitcher sceneSwitcher, IWalkerHudFactory hudFactory,
			IWalkerEnvironmentFactory environmentFactory, IWalkerCharacterFactory characterFactory, 
			ITimerService timerService, IPersistentProgressService persistemtProgressService,
			IAssetsReferencesHandler handler, IAssetsProvider assetsProvider)
		{
			_uiFactory = uiFactory;
			_sceneSwitcher = sceneSwitcher;
			_hudFactory = hudFactory;
			_environmentFactory = environmentFactory;
			_characterFactory = characterFactory;
			_timerService = timerService;
			_persistemtProgressService = persistemtProgressService;
			_handler = handler;
			_assetsProvider = assetsProvider;
		}

		public async void Enter()
		{
			Debug.Log(_persistemtProgressService.Progress.WalkerData.BestTime);


			await SwitchScene();
			await WarmUpWalkerAssets();
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

		private async UniTask WarmUpWalkerAssets() =>
			_handler.WalkerAssetsReference= await _assetsProvider.Load<WalkerAssetsReference>(
				AssetsReferencesAddresses.WalkerReferenceAddress);

		private void DestroyObjects()
		{
			_uiFactory.DestroyUIRoot();
			_hudFactory.Destroy();
			_characterFactory.Destroy();
			_environmentFactory.DestroyEnvironment();
		}
	}
}