using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Infrastructure.Services.Score
{
	public class TimerService : ITimerService
	{
		private const int OneSecond = 1000;

		private bool _isRunning;

		public event Action Started;
		public event Action Completed;
		public event Action<int> TimeUpdated;

		public int TimeElapsed { get; private set; }

		public async UniTask Start()
		{
			Started?.Invoke();

			TimeElapsed = 0;
			_isRunning = true;

			while (_isRunning)
			{
				await UniTask.Delay(OneSecond);
				TimeElapsed++;
				TimeUpdated?.Invoke(TimeElapsed);
				Debug.Log(TimeElapsed);
			}

			Completed?.Invoke();
		}

		public void Stop() =>
			_isRunning = false;

		public string GetFormattedTime()
		{
			int minutes = TimeElapsed / 60;
			int seconds = TimeElapsed % 60;
			return $"{minutes:D2}:{seconds:D2}";
		}
	}
}