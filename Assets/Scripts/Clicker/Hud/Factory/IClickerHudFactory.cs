using Cysharp.Threading.Tasks;

namespace Clicker.Hud.Factory
{
	public interface IClickerHudFactory
	{
		UniTask CreateHud();
		void Destroy();
	}
}