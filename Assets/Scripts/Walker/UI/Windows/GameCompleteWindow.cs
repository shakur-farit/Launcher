using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoad;
using Infrastructure.States;
using Infrastructure.States.StatesMachine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Walker.UI.Windows
{
	public class GameCompleteWindow : MonoBehaviour
	{
		[SerializeField] private Button _quitButton;
		[SerializeField] private TextMeshProUGUI _currentTimeText;
		[SerializeField] private TextMeshProUGUI _bestTimeText;

		private ILauncherStatesSwitcher _launcherStatesSwitcher;
		private IPersistentProgressService _persistentProgressService;
		private ISaveService _saveService;

		[Inject]
		public void Constructor(ILauncherStatesSwitcher launcherStatesSwitcher,
			IPersistentProgressService persistentProgressService, ISaveService saveService)
		{
			_launcherStatesSwitcher = launcherStatesSwitcher;
			_persistentProgressService = persistentProgressService;
			_saveService = saveService;
		}

		private void Awake()
		{
			_quitButton.onClick.AddListener(QuitToLauncher);
		}

		private void QuitToLauncher()
		{
			SaveProgress();

			SwitchStateToLaunchState();
		}

		private void SwitchStateToLaunchState() =>
			_launcherStatesSwitcher.SwitchStateTo<LauncherState>();

		private void SaveProgress() =>
			_saveService.SaveProgress(_persistentProgressService.Progress);
	}
}