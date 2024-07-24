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
		private readonly IAssetsReferencesHandler _handler;

		protected ClickerHudFactory(IAssetsProvider assetsProvider, IObjectCreatorService objectsCreator, IAssetsReferencesHandler handler) :
			base(assetsProvider, objectsCreator)
		{
			_handler = handler;
		}

		public async UniTask CreateHud()
		{
			//string address = AssetsReferencesAddresses.ClickerAssetsReference;
			//ClickerAssetsReference reference = await InitReference<ClickerAssetsReference>(address);

			ClickerAssetsReference reference = _handler.ClickerAssetsReference;

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