using System;
using Cysharp.Threading.Tasks;

namespace Infrastructure.Services.Score
{
	public interface ITimerService
	{
		event Action Started;
		event Action Completed;
		event Action<int> TimeUpdated;
		int TimeElapsed { get; }
		UniTask Start();
		void Stop();
		string GetFormattedTime();
	}
}