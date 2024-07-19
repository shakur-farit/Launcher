using System;
using Cysharp.Threading.Tasks;
using Services.AssetsManagement;
using Services.BaseFactory;
using Services.ObjectsCreator;
using UnityEngine;

namespace Launcher.UI.Factory
{
	public class LauncherHudFactory : FactoryBase, ILauncherHudFactory
	{
		private GameObject _uiRoot;

		protected LauncherHudFactory(IAssetsProvider assetsProvider, IObjectCreatorService objectsCreator) :
			base(assetsProvider, objectsCreator)
		{
		}

		public async UniTask CreateHud()
		{
			LauncherAssetsReference reference = await InitReference();
			_uiRoot = await CreateObject(reference.HudAddress);
		}
	}
}