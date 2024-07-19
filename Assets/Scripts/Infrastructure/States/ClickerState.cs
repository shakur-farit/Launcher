using Clicker.Hud.Factory;
using Infrastructure.Services.SceneManagement;

namespace Infrastructure.States
{
	public class ClickerState : IState
	{
		private const string ClickerScene = "Clicker";

		private readonly IClickerHudFactory _clickerHudFactory;
		private readonly ISceneSwitcher _sceneSwitcher;

		public ClickerState(IClickerHudFactory clickerHudFactory, ISceneSwitcher sceneSwitcher)
		{
			_clickerHudFactory = clickerHudFactory;
			_sceneSwitcher = sceneSwitcher;
		}

		public void Enter()
		{
			_sceneSwitcher.SwitchSceneTo(ClickerScene);

			_clickerHudFactory.CreateHud();
		}

		public void Exit() =>
			_clickerHudFactory.Destroy();
	}
}