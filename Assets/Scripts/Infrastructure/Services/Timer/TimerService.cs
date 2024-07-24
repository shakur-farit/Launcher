using System;
using Cysharp.Threading.Tasks;

namespace Infrastructure.Services.Timer
{
	public class TimerService : ITimerService, ITimerFormater
	{
		private const int OneSecond = 1000;

		private bool _isRunning;

		public event Action Started;
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
			}

			//Completed?.Invoke();
		}

		public void Stop() =>
			_isRunning = false;

		public string GetFormattedTime(int currentTime)
		{
			int minutes = currentTime / 60;
			int seconds = currentTime % 60;
			return $"{minutes:D2}:{seconds:D2}";
		}
	}
}