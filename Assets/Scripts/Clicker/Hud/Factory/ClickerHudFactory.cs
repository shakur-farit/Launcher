using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.BaseFactory;
using Infrastructure.Services.ObjectsCreator;
using UnityEngine;

namespace Clicker.Hud.Factory
{
	public class ClickerHudFactory : FactoryBase, IClickerHudFactory
	{
		private GameObject _hud;

		protected ClickerHudFactory(IAssetsProvider assetsProvider, IObjectCreatorService objectsCreator) :
			base(assetsProvider, objectsCreator)
		{
		}

		public async UniTask CreateHud()
		{
			string address = AssetsReferencesAddresses.ClickerAssetsReference;
			ClickerAssetsReference reference = await InitReference<ClickerAssetsReference>(address);
			_hud = await CreateObject(reference.HudAddress);
		}

		public void Destroy() => 
			Object.Destroy(_hud);
	}
}