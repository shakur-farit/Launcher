using Cysharp.Threading.Tasks;

namespace UI.Launcher.Factory
{
	public interface ILauncherUIFactory
	{
		UniTask CreateUIRoot();
	}
}