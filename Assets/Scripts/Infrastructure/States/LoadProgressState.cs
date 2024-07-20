using Data;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoad;
using Infrastructure.States.StatesMachine;

namespace Infrastructure.States
{
	public class LoadProgressState : IState
	{
		private readonly ILauncherStatesSwitcher _gameStatesSwitcher;
		private readonly IPersistentProgressService _persistentProgressService;
		private readonly ILoadService _loadService;

		public LoadProgressState(ILauncherStatesSwitcher gameStatesSwitcher, IPersistentProgressService persistentProgressService,
			ILoadService loadService)
		{
			_gameStatesSwitcher = gameStatesSwitcher;
			_persistentProgressService = persistentProgressService;
			_loadService = loadService;
		}

		public void Enter()
		{
			InitProgress();

			EnterToLoadSceneState();
		}

		public void Exit()
		{
		}

		private void InitProgress() =>
			_persistentProgressService.Progress = LoadProgress() != null ? LoadProgress() : InitializeNewProgress();

		private Progress LoadProgress() =>
			_loadService.LoadProgress();

		private Progress InitializeNewProgress() => new();

		private void EnterToLoadSceneState() =>
			_gameStatesSwitcher.SwitchStateTo<LauncherState>();
	}
}