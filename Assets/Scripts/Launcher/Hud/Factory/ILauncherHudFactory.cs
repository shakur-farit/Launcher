using Cysharp.Threading.Tasks;

namespace Launcher.Hud.Factory
{
	public interface ILauncherHudFactory
	{
		UniTask CreateHud();
	}
}