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
		private WalkerAssetsReference _reference;

		protected WalkerUIFactory(IAssetsProvider assetsProvider, IObjectCreatorService objectsCreator,
			IAssetsReferencesHandler handler) : 
			base(assetsProvider, objectsCreator, handler)
		{
			InitReference();
		}

		public async UniTask CreateUIRoot()
		{
			//string address = AssetsReferencesAddresses.WalkerReferenceAddress;
			//WalkerAssetsReference reference = await InitReference<WalkerAssetsReference>(address);

			if (_reference == null)
				return;

			_uiRoot = await CreateObject(_reference.UIRoot);
		}

		public async UniTask CreateGameCompleteWindow()
		{
			//string address = AssetsReferencesAddresses.WalkerReferenceAddress;
			//WalkerAssetsReference reference = await InitReference<WalkerAssetsReference>(address);

			if (_reference == null)
				return;

			_gameCompleteWindow = await CreateObject(_reference.GameCompleteWindow, _uiRoot.transform);
		}

		public void DestroyUIRoot() => 
			Object.Destroy(_uiRoot);

		private void InitReference() => 
			_reference = Handler.WalkerAssetsReference;
	}
}