using Clicker.Hud;
using Clicker.Hud.Factory;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectsCreator;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoad;
using Infrastructure.Services.SceneManagement;
using Infrastructure.Services.Score;
using Infrastructure.States;
using Infrastructure.States.Factory;
using Infrastructure.States.StatesMachine;
using Launcher.Hud.Factory;
using Zenject;

namespace Installers
{
	public class ProjectInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<ILauncherHudFactory>().To<LauncherHudFactory>().AsSingle();
			Container.Bind<ILauncherStatesFactory>().To<LauncherStatesFactory>().AsSingle();
			Container.Bind<IClickerHudFactory>().To<ClickerHudFactory>().AsSingle();
			Container.BindInterfacesAndSelfTo<LauncherStatesMachine>().AsSingle();
			Container.Bind<IObjectCreatorService>().To<ObjectCreatorService>().AsSingle();
			Container.Bind<IAssetsProvider>().To<AssetsProvider>().AsSingle();
			Container.Bind<IScoreService>().To<ScoreService>().AsSingle();
			Container.Bind<ISceneSwitcher>().To<SceneSwitcher>().AsSingle();
			Container.Bind<IPersistentProgressService>().To<PersistentProgressService>().AsSingle();
			Container.BindInterfacesAndSelfTo<SaveLoadService>().AsSingle();
		}
	}
}