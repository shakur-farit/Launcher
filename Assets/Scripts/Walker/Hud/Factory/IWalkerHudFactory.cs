using Cysharp.Threading.Tasks;

namespace Walker.Hud.Factory
{
	public interface IWalkerHudFactory
	{
		UniTask CreateHud();
		void Destroy();
	}
}