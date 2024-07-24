using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.BaseFactory;
using Infrastructure.Services.ObjectsCreator;
using UnityEngine;

namespace Walker.Environment.Factory
{
	public class WalkerEnvironmentFactory : FactoryBase, IWalkerEnvironmentFactory
	{
		private GameObject _environment;

		protected WalkerEnvironmentFactory(IAssetsProvider assetsProvider, IObjectCreatorService objectsCreator,
			IAssetsReferencesHandler handler) : 
			base(assetsProvider, objectsCreator, handler)
		{
		}

		public async UniTask CreateEnvironment()
		{
			//string address = AssetsReferencesAddresses.WalkerReferenceAddress;
			//WalkerAssetsReference reference = await InitReference<WalkerAssetsReference>(address);

			WalkerAssetsReference reference = Handler.WalkerAssetsReference;

			if (reference == null)
				return;

			_environment = await CreateObject(reference.EnvironmentAddress);
		}

		public void DestroyEnvironment() =>
			Object.Destroy(_environment);
	}
}