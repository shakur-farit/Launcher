using Cysharp.Threading.Tasks;
using Launcher.UI.Factory;
using UnityEngine;

namespace Launcher.Infrastructure.States
{
	public class LoadLauncherState : ILauncherState
	{
		private readonly ILauncherHudFactory _launcherHudFactory;

		public LoadLauncherState(ILauncherHudFactory launcherHudFactory) => 
			_launcherHudFactory = launcherHudFactory;

		public async void Enter()
		{
			Debug.Log(GetType());

			await CreateHud();
		}

		public void Exit()
		{
		}

		private async UniTask CreateHud() => 
			await _launcherHudFactory.CreateHud();
	}
}