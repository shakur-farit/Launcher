using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectsCreator;
using UnityEngine;

namespace Infrastructure.Services.FactoryBase
{
	public class Factory
	{
		protected readonly IAssetsProvider AssetsProvider;
		protected readonly IObjectCreatorService ObjectsCreator;

		protected Factory(IAssetsProvider assetsProvider, IObjectCreatorService objectsCreator)
		{
			AssetsProvider = assetsProvider;
			ObjectsCreator = objectsCreator;
		}

		protected async UniTask<GameObject> CreateObject(string objectAddress)
		{
			GameObject prefab = await AssetsProvider.Load<GameObject>(objectAddress);

			return ObjectsCreator.Instantiate(prefab);
		}

		protected async UniTask<AssetsReference> InitReference() =>
			await AssetsProvider.Load<AssetsReference>(AssetsReferencesAddresses.LauncherAssetsReference);
	}
}