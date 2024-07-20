using Cysharp.Threading.Tasks;
using Walker.UI.Factory;
using Walker.UI.Windows;

namespace Walker.UI.Service
{
	public class WindowsService : IWindowsService
	{
		private readonly IWalkerUIFactory _uiFactory;

		public WindowsService(IWalkerUIFactory uiFactory) => 
			_uiFactory = uiFactory;

		public async UniTask Open(WindowId windowId)
		{
			switch (windowId)
			{
				case WindowId.GameComplete:
					await _uiFactory.CreateGameCompleteWindow();
					break;
			}
		}
	}
}