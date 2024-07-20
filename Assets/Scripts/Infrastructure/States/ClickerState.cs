using Clicker.Hud.Factory;
using Cysharp.Threading.Tasks;
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

		public ClickerState(IClickerHudFactory clickerHudFactory, ISceneSwitcher sceneSwitcher, IScoreService scoreService)
		{
			_clickerHudFactory = clickerHudFactory;
			_sceneSwitcher = sceneSwitcher;
			_scoreService = scoreService;
		}

		public async void Enter()
		{
			LoadScoreData();

			await SwitchScene();

			await CreateClickerHud();
		}

		public void Exit() =>
			DestroyClickerHud();

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