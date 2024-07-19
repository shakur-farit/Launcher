using Cysharp.Threading.Tasks;

namespace Infrastructure.Services.SceneManagement
{
	public interface ISceneSwitcher
	{
		UniTask SwitchSceneTo(string sceneName);
	}
}