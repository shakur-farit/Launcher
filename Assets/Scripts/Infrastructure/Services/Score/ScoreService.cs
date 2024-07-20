using Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace Infrastructure.Services.Score
{
	public class ScoreService : IScoreService
	{
		private readonly IPersistentProgressService _persistentProgressService;

		public int CurrentScores { get; private set; }

		public ScoreService(IPersistentProgressService persistentProgressService) => 
			_persistentProgressService = persistentProgressService;

		public void AddScore(int amount) => 
			CurrentScores += amount;

		public void LoadCurrentScoreData()
		{
			CurrentScores = _persistentProgressService.Progress.ClickerData.CurrentScore;
			Debug.Log(CurrentScores);
		}
	}
}