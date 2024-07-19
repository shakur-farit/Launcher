using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.States.StatesMachine;

namespace Infrastructure.States
{
	public class WarmUp : IState
	{
		private readonly IAssetsProvider _assetsProvider;
		private readonly ILauncherStatesSwitcher _launcherStatesSwitcher;

		public WarmUp(IAssetsProvider assetsProvider, ILauncherStatesSwitcher launcherStatesSwitcher)
		{
			_assetsProvider = assetsProvider;
			_launcherStatesSwitcher = launcherStatesSwitcher;
		}

		public async void Enter()
		{
			CleanUpDictionaries();
			InitializeAddressables();
			await WarmUpAssets();
			_launcherStatesSwitcher.SwitchState<LauncherState>();
		}

		public void Exit()
		{
		}

		private void CleanUpDictionaries() => 
			_assetsProvider.CleanUp();

		private void InitializeAddressables() => 
			_assetsProvider.Initialize();

		private async UniTask WarmUpAssets()
		{
			await _assetsProvider.Load<LauncherAssetsReference>(AssetsReferencesAddresses.LauncherAssetsReference);
			await _assetsProvider.Load<ClickerAssetsReference>(AssetsReferencesAddresses.ClickerAssetsReference);
		}
	}
}