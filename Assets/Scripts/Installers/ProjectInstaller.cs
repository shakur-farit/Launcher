using Clicker.Hud.Factory;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectsCreator;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoad;
using Infrastructure.Services.SceneManagement;
using Infrastructure.Services.Score;
using Infrastructure.States.Factory;
using Infrastructure.States.StatesMachine;
using Launcher.Hud.Factory;
using Walker.Character.Factory;
using Walker.Environment.Factory;
using Walker.Hud.Factory;
using Walker.UI.Factory;
using Walker.UI.Service;
using Zenject;

namespace Installers
{
	public class ProjectInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			RegisterFactories();
			RegisterStatesMachines();
			RegisterServices();
		}

		private void RegisterFactories()
		{
			Container.Bind<IClickerHudFactory>().To<ClickerHudFactory>().AsSingle();
			Container.Bind<ILauncherHudFactory>().To<LauncherHudFactory>().AsSingle();
			Container.Bind<IWalkerHudFactory>().To<WalkerHudFactory>().AsSingle();
			Container.Bind<IWalkerCharacterFactory>().To<WalkerCharacterFactory>().AsSingle();
			Container.Bind<IWalkerEnvironmentFactory>().To<WalkerEnvironmentFactory>().AsSingle();
			Container.Bind<IWalkerUIFactory>().To<WalkerUIFactory>().AsSingle();
			Container.Bind<ILauncherStatesFactory>().To<LauncherStatesFactory>().AsSingle();
		}

		private void RegisterStatesMachines() => 
			Container.BindInterfacesAndSelfTo<LauncherStatesMachine>().AsSingle();

		private void RegisterServices()
		{
			Container.Bind<IObjectCreatorService>().To<ObjectCreatorService>().AsSingle();
			Container.Bind<IAssetsProvider>().To<AssetsProvider>().AsSingle();
			Container.Bind<IScoreService>().To<ScoreService>().AsSingle();
			Container.Bind<ISceneSwitcher>().To<SceneSwitcher>().AsSingle();
			Container.Bind<IPersistentProgressService>().To<PersistentProgressService>().AsSingle();
			Container.Bind<IWindowsService>().To<WindowsService>().AsSingle();
			Container.Bind<IInputService>().To<InputService>().AsSingle();
			Container.Bind<CharacterInput>().AsSingle();
			Container.BindInterfacesAndSelfTo<SaveLoadService>().AsSingle();
		}
	}
}