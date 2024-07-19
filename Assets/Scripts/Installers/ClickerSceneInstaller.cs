using Clicker.Hud.Factory;
using Clicker.Infrastructure.States.Factory;
using Clicker.Infrastructure.States.StatesMachine;
using Services.AssetsManagement;
using Services.ObjectsCreator;
using Zenject;

namespace Installers
{
	public class ClickerSceneInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<IClickerStatesFactory>().To<ClickerStatesFactory>().AsSingle();
			Container.BindInterfacesAndSelfTo<ClickerStatesMachine>().AsSingle();
			Container.Bind<IObjectCreatorService>().To<ObjectCreatorService>().AsSingle();
			Container.Bind<IAssetsProvider>().To<AssetsProvider>().AsSingle();
			Container.Bind<IClickerHudFactory>().To<ClickerHudFactory>().AsSingle();
		}
	}
}