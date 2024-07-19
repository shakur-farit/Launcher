using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.BaseFactory;
using Infrastructure.Services.ObjectsCreator;
using UnityEngine;

namespace Launcher.Hud.Factory
{
	public class LauncherHudFactory : FactoryBase, ILauncherHudFactory
	{
		private GameObject _hud;

		protected LauncherHudFactory(IAssetsProvider assetsProvider, IObjectCreatorService objectsCreator) :
			base(assetsProvider, objectsCreator)
		{
		}

		public async UniTask CreateHud()
		{
			string address = AssetsReferencesAddresses.LauncherAssetsReference;
			LauncherAssetsReference reference = await InitReference<LauncherAssetsReference>(address);
			_hud = await CreateObject(reference.HudAddress);
		}

		public void Destroy() => 
			Object.Destroy(_hud);
	}
}