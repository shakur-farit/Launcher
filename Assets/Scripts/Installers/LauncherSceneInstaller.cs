using Launcher.Hud.Factory;
using Launcher.Infrastructure.States.Factory;
using Launcher.Infrastructure.States.StatesMachine;
using Services.AssetsManagement;
using Services.ObjectsCreator;
using Zenject;

namespace Installers
{
	public class LauncherSceneInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<ILauncherHudFactory>().To<LauncherHudFactory>().AsSingle();
			Container.Bind<ILauncherStatesFactory>().To<LauncherStatesFactory>().AsSingle();
			Container.BindInterfacesAndSelfTo<LauncherStatesMachine>().AsSingle();
			Container.Bind<IObjectCreatorService>().To<ObjectCreatorService>().AsSingle();
			Container.Bind<IAssetsProvider>().To<AssetsProvider>().AsSingle();
		}
	}
}
