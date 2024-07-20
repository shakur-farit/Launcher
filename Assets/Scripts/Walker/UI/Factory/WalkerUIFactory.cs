using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.BaseFactory;
using Infrastructure.Services.ObjectsCreator;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Walker.UI.Factory
{
	public class WalkerUIFactory : FactoryBase, IWalkerUIFactory
	{
		private GameObject _uiRoot;
		private GameObject _gameCompleteWindow;

		protected WalkerUIFactory(IAssetsProvider assetsProvider, IObjectCreatorService objectsCreator) : 
			base(assetsProvider, objectsCreator)
		{
		}

		public async UniTask CreateUIRoot()
		{
			string address = AssetsReferencesAddresses.WalkerReferenceAddress;
			WalkerAssetsReference reference = await InitReference<WalkerAssetsReference>(address);
			_uiRoot = await CreateObject(reference.UIRoot);
		}

		public async UniTask CreateGameCompleteWindow()
		{
			string address = AssetsReferencesAddresses.WalkerReferenceAddress;
			WalkerAssetsReference reference = await InitReference<WalkerAssetsReference>(address);
			_gameCompleteWindow = await CreateObject(reference.GameCompleteWindow, _uiRoot.transform);
		}

		public void DestroyUIRoot() => 
			Object.Destroy(_uiRoot);
	}
}