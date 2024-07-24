using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.States.StatesMachine;

namespace Infrastructure.States
{
	public class WarmUp : IState
	{
		private readonly IAssetsProvider _assetsProvider;
		private readonly ILauncherStatesSwitcher _launcherStatesSwitcher;
		private readonly IAssetsReferencesHandler _handler;

		public WarmUp(IAssetsProvider assetsProvider, ILauncherStatesSwitcher launcherStatesSwitcher, IAssetsReferencesHandler handler)
		{
			_assetsProvider = assetsProvider;
			_launcherStatesSwitcher = launcherStatesSwitcher;
			_handler = handler;
		}

		public async void Enter()
		{
			CleanUpDictionaries();
			InitializeAddressables();
			await WarmUpLauncherAssets();
			_launcherStatesSwitcher.SwitchStateTo<LoadProgressState>();
		}

		public void Exit()
		{
		}

		private void CleanUpDictionaries() => 
			_assetsProvider.CleanUp();

		private void InitializeAddressables() => 
			_assetsProvider.Initialize();

		private async UniTask WarmUpLauncherAssets() =>
			_handler.LauncherAssetsReference = await _assetsProvider.Load<LauncherAssetsReference>(
				AssetsReferencesAddresses.LauncherAssetsReference);
	}

}