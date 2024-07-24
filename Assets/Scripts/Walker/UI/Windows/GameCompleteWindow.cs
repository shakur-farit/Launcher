using System;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoad;
using Infrastructure.Services.Score;
using Infrastructure.Services.Timer;
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

		private int _bestTime;

		private ILauncherStatesSwitcher _launcherStatesSwitcher;
		private IPersistentProgressService _persistentProgressService;
		private ISaveService _saveService;
		private ITimerService _timer;
		private ITimerFormater _formater;

		[Inject]
		public void Constructor(ILauncherStatesSwitcher launcherStatesSwitcher,
			IPersistentProgressService persistentProgressService, ISaveService saveService, 
			ITimerService timer, ITimerFormater formater)
		{
			_launcherStatesSwitcher = launcherStatesSwitcher;
			_persistentProgressService = persistentProgressService;
			_saveService = saveService;
			_timer = timer;
			_formater = formater;
		}

		private void Awake()
		{
			_quitButton.onClick.AddListener(QuitToLauncher);

			UpdateTimersText();
		}

		private void Start() => 
			SaveProgress();

		private void QuitToLauncher() => 
			SwitchStateToLaunchState();

		private void SwitchStateToLaunchState() =>
			_launcherStatesSwitcher.SwitchStateTo<LauncherState>();

		private void UpdateTimersText()
		{
			_currentTimeText.text = _formater.GetFormattedTime(_timer.TimeElapsed);

			UpdateBestTime();

			_bestTimeText.text = _formater.GetFormattedTime(_bestTime);
		}

		private void UpdateBestTime()
		{
			_bestTime = _persistentProgressService.Progress.WalkerData.BestTime;
			int currentTime = _timer.TimeElapsed;

			if (_bestTime == 0 || currentTime < _bestTime)
				_persistentProgressService.Progress.WalkerData.BestTime = currentTime;
		}

		private void SaveProgress() =>
			_saveService.SaveProgress(_persistentProgressService.Progress);
	}
}