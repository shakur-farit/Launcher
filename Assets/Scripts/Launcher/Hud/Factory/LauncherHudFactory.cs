using Cysharp.Threading.Tasks;
using Services.AssetsManagement;
using Services.BaseFactory;
using Services.ObjectsCreator;

namespace Launcher.Hud.Factory
{
	public class LauncherHudFactory : FactoryBase, ILauncherHudFactory
	{
		protected LauncherHudFactory(IAssetsProvider assetsProvider, IObjectCreatorService objectsCreator) :
			base(assetsProvider, objectsCreator)
		{
		}

		public async UniTask CreateHud()
		{
			string address = AssetsReferencesAddresses.LauncherAssetsReference;
			LauncherAssetsReference reference = await InitReference<LauncherAssetsReference>(address);
			await CreateObject(reference.HudAddress);
		}
	}
}