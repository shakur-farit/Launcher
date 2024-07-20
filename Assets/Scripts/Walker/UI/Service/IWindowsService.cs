using Cysharp.Threading.Tasks;
using Walker.UI.Windows;

namespace Walker.UI.Service
{
	public interface IWindowsService
	{
		UniTask Open(WindowId windowId);
	}
}