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
		private readonly IAssetsReferencesHandler _handler;

		protected LauncherHudFactory(IAssetsProvider assetsProvider, IObjectCreatorService objectsCreator, IAssetsReferencesHandler handler) :
			base(assetsProvider, objectsCreator)
		{
			_handler = handler;
		}

		public async UniTask CreateHud()
		{
			//string address = AssetsReferencesAddresses.LauncherAssetsReference;
			//LauncherAssetsReference reference = await InitReference<LauncherAssetsReference>(address);

			LauncherAssetsReference reference = _handler.LauncherAssetsReference;

			if (reference == null)
			{
				Debug.Log("Assets is null");
				return;
			}

			_hud = await CreateObject(reference.HudAddress);
		}

		public void Destroy() => 
			Object.Destroy(_hud);
	}
}