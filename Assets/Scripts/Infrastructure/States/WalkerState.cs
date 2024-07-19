using Infrastructure.Services.SceneManagement;
using Zenject;

namespace Infrastructure.States
{
	public class WalkerState : IState
	{
		private const string WalkerScene = "Clicker";

		private ISceneSwitcher _sceneSwitcher;

		[Inject]
		public void Constructor(ISceneSwitcher sceneSwitcher)
		{
			_sceneSwitcher = sceneSwitcher;
		}

		public void Enter() => 
			_sceneSwitcher.SwitchSceneTo(WalkerScene);

		public void Exit()
		{
		}
	}
}