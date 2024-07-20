using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoad;
using Infrastructure.Services.Score;
using Infrastructure.States;
using Infrastructure.States.StatesMachine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Clicker.Hud
{
	public class ClickerHud : MonoBehaviour
	{
		private const int ScoreToAdd = 1;

		[SerializeField] private Button _clickButton;
		[SerializeField] private Button _quitButton;
		[SerializeField] private TextMeshProUGUI _scoreText;
		
		private IScoreService _scoreService;
		private ILauncherStatesSwitcher _launcherStatesSwitcher;
		private IPersistentProgressService _persistentProgressService;
		private ISaveService _saveService;

		[Inject]
		public void Constructor(IScoreService scoreService, ILauncherStatesSwitcher launcherStatesSwitcher,
			IPersistentProgressService persistentProgressService, ISaveService saveService)
		{
			_scoreService = scoreService;
			_launcherStatesSwitcher = launcherStatesSwitcher;
			_persistentProgressService = persistentProgressService;
			_saveService = saveService;
		}

		private void Awake()
		{
			_clickButton.onClick.AddListener(AddScore);
			_quitButton.onClick.AddListener(QuitToLauncher);

			UpdateScoreText();
		}

		private void AddScore()
		{
			_scoreService.AddScore(ScoreToAdd);
			_persistentProgressService.Progress.ClickerData.Score = _scoreService.Scores;

			UpdateScoreText();
		}

		private void UpdateScoreText() => 
			_scoreText.text = _scoreService.Scores.ToString();

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