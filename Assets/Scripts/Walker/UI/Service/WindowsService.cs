using Cysharp.Threading.Tasks;
using UnityEngine;
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
			Debug.Log("Here2");

			switch (windowId)
			{
				case WindowId.GameComplete:
					await _uiFactory.CreateGameCompleteWindow();
					break;
			}
		}
	}
}