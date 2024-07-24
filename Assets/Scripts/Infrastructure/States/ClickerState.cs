using System.Threading.Tasks;
using Clicker.Hud.Factory;
using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.SceneManagement;
using Infrastructure.Services.Score;

namespace Infrastructure.States
{
	public class ClickerState : IState
	{
		private const string ClickerScene = "Clicker";

		private readonly IClickerHudFactory _clickerHudFactory;
		private readonly ISceneSwitcher _sceneSwitcher;
		private readonly IScoreService _scoreService;
		private readonly IAssetsProvider _assetsProvider;
		private readonly IAssetsReferencesHandler _handler;

		public ClickerState(IClickerHudFactory clickerHudFactory, ISceneSwitcher sceneSwitcher,
			IScoreService scoreService, IAssetsProvider assetsProvider, IAssetsReferencesHandler handler)
		{
			_clickerHudFactory = clickerHudFactory;
			_sceneSwitcher = sceneSwitcher;
			_scoreService = scoreService;
			_assetsProvider = assetsProvider;
			_handler = handler;
		}

		public async void Enter()
		{
			//await WarmUpClickerAssets();

			LoadScoreData();

			await SwitchScene();

			await CreateClickerHud();
		}

		private async UniTask WarmUpClickerAssets() =>
			_handler.ClickerAssetsReference = await _assetsProvider.Load<ClickerAssetsReference>(
				AssetsReferencesAddresses.ClickerAssetsReference);

		public async void Exit()
		{
			DestroyClickerHud();

			ClickerAssetsReference reference = await _assetsProvider.Load<ClickerAssetsReference>(AssetsReferencesAddresses.ClickerAssetsReference);

			_assetsProvider.RemoveAsset(reference.HudAddress);
			_assetsProvider.RemoveAsset(AssetsReferencesAddresses.ClickerAssetsReference);
		}

		private void LoadScoreData() => 
			_scoreService.LoadCurrentScoreData();

		private async UniTask SwitchScene() => 
			await _sceneSwitcher.SwitchSceneTo(ClickerScene);

		private async UniTask CreateClickerHud() => 
			await _clickerHudFactory.CreateHud();

		private void DestroyClickerHud() => 
			_clickerHudFactory.Destroy();
	}
}