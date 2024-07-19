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

		[Inject]
		public void Constructor(IScoreService scoreService, ILauncherStatesSwitcher launcherStatesSwitcher)
		{
			_scoreService = scoreService;
			_launcherStatesSwitcher = launcherStatesSwitcher;
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

			UpdateScoreText();
		}

		private void UpdateScoreText() => 
			_scoreText.text = _scoreService.Scores.ToString();

		private void QuitToLauncher() => 
			_launcherStatesSwitcher.SwitchState<LauncherState>();
	}
}