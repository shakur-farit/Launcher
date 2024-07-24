using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.BaseFactory;
using Infrastructure.Services.ObjectsCreator;
using UnityEngine;

namespace Walker.Hud.Factory
{
	public class WalkerHudFactory : FactoryBase, IWalkerHudFactory
	{
		private GameObject _hud;

		protected WalkerHudFactory(IAssetsProvider assetsProvider, IObjectCreatorService objectsCreator,
			IAssetsReferencesHandler handler) : 
			base(assetsProvider, objectsCreator, handler)
		{
		}

		public async UniTask CreateHud()
		{
			//string address = AssetsReferencesAddresses.WalkerReferenceAddress;
			//WalkerAssetsReference reference = await InitReference<WalkerAssetsReference>(address);

			WalkerAssetsReference reference = Handler.WalkerAssetsReference;

			if (reference == null)
				return;

			_hud = await CreateObject(reference.HudAddress);
		}

		public void Destroy() =>
			Object.Destroy(_hud);
	}
}