using Launcher.Infrastructure.States.Factory;
using Launcher.Infrastructure.States.StatesMachine;
using Launcher.UI.Factory;
using Services.AssetsManagement;
using Services.ObjectsCreator;
using Zenject;

namespace Installers
{
	public class LauncherSceneInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<LauncherStatesMachine>().AsSingle();
			Container.Bind<ILauncherStatesFactory>().To<LauncherStatesFactory>().AsSingle();
			Container.Bind<ILauncherHudFactory>().To<LauncherHudFactory>().AsSingle();
			Container.Bind<IAssetsProvider>().To<AssetsProvider>().AsSingle();
			Container.Bind<IObjectCreatorService>().To<ObjectCreatorService>().AsSingle();
		}
	}
}
