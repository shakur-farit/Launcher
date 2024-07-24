using Infrastructure.Services.Timer;
using UnityEngine;
using Walker.Hud.Factory;
using Walker.UI.Service;
using Walker.UI.Windows;
using Zenject;

namespace Infrastructure.Services.Score
{
	public class CharacterCollideDetector : MonoBehaviour
	{
		private bool _collided;

		private ITimerService _timer;
		private IWindowsService _windowsService;
		private IWalkerHudFactory _hudFactory;

		[Inject]
		public void Constructor(ITimerService timer, IWindowsService windowsService, IWalkerHudFactory hudFactory)
		{
			_timer = timer;
			_windowsService = windowsService;
			_hudFactory = hudFactory;
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.TryGetComponent(out Finish finish) && _collided == false)
			{
				_timer.Stop();
				_windowsService.Open(WindowId.GameComplete);
				_hudFactory.Destroy();
				_collided = true;
			}
		}
	}
}