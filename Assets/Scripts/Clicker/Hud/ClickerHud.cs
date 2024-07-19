using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Clicker.Hud.Factory
{
	public class ClickerHud : MonoBehaviour
	{
		private const int ScoreToAdd = 1;

		[SerializeField] private Button _clickButton;
		[SerializeField] private TextMeshProUGUI _scoreText;
		
		private IScoreService _scoreService;

		public void Constructor(IScoreService scoreService) => 
			_scoreService = scoreService;

		private void Awake() => 
			_clickButton.onClick.AddListener(AddScore);

		private void AddScore()
		{
			_scoreService.AddScore(ScoreToAdd);
		}
	}
}