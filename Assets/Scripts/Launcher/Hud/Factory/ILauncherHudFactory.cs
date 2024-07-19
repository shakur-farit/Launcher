using Cysharp.Threading.Tasks;

namespace Launcher.UI.Factory
{
	public interface ILauncherHudFactory
	{
		UniTask CreateHud();
	}
}