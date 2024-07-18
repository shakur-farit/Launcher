using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectsCreator;
using UnityEngine;

namespace UI.Launcher.Factory
{
	public class LauncherUIFactory : Infrastructure.Services.FactoryBase.Factory, ILauncherUIFactory
	{
		private GameObject _uiRoot;

		protected LauncherUIFactory(IAssetsProvider assetsProvider, IObjectCreatorService objectsCreator) :
			base(assetsProvider, objectsCreator)
		{
		}

		public async UniTask CreateUIRoot()
		{
			AssetsReference reference = await InitReference();
			_uiRoot = await CreateObject(reference.UIRootAddress);
		}
	}
}