using Cysharp.Threading.Tasks;

namespace Walker.UI.Factory
{
	public interface IWalkerUIFactory
	{
		UniTask CreateUIRoot();
		UniTask CreateGameCompleteWindow();
		void DestroyUIRoot();
	}
}