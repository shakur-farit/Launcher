using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectsCreator;
using Infrastructure.States.Launcher.Factory;
using Infrastructure.States.Launcher.StatesMachine;
using UI.Launcher.Factory;
using Zenject;

namespace Installers.Launcher
{
	public class LauncherSceneInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<LauncherStatesMachine>().AsSingle();
			Container.Bind<ILauncherStatesFactory>().To<LauncherStatesFactory>().AsSingle();
			Container.Bind<ILauncherUIFactory>().To<LauncherUIFactory>().AsSingle();
			Container.Bind<IAssetsProvider>().To<AssetsProvider>().AsSingle();
			Container.Bind<IObjectCreatorService>().To<ObjectCreatorService>().AsSingle();
		}
	}
}
