using Cysharp.Threading.Tasks;
using Services.AssetsManagement;
using Services.ObjectsCreator;
using UnityEngine;

namespace Services.BaseFactory
{
	public class FactoryBase
	{
		protected readonly IAssetsProvider AssetsProvider;
		protected readonly IObjectCreatorService ObjectsCreator;

		protected FactoryBase(IAssetsProvider assetsProvider, IObjectCreatorService objectsCreator)
		{
			AssetsProvider = assetsProvider;
			ObjectsCreator = objectsCreator;
		}

		protected async UniTask<GameObject> CreateObject(string objectAddress)
		{
			GameObject prefab = await AssetsProvider.Load<GameObject>(objectAddress);

			return ObjectsCreator.Instantiate(prefab);
		}

		protected async UniTask<LauncherAssetsReference> InitReference() =>
			await AssetsProvider.Load<LauncherAssetsReference>(AssetsReferencesAddresses.LauncherAssetsReference);
	}
}