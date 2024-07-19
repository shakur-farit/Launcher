using Cysharp.Threading.Tasks;
using Services.AssetsManagement;
using Services.BaseFactory;
using Services.ObjectsCreator;

namespace Clicker.Hud.Factory
{
	public class ClickerHudFactory : FactoryBase, IClickerHudFactory
	{
		protected ClickerHudFactory(IAssetsProvider assetsProvider, IObjectCreatorService objectsCreator) : 
			base(assetsProvider, objectsCreator)
		{
		}

		public async UniTask CreateHud()
		{
			string address = AssetsReferencesAddresses.ClickerAssetsReference;
			ClickerAssetsReference reference = await InitReference<ClickerAssetsReference>(address);
			await CreateObject(reference.HudAddress);
		}
	}
}