using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Infrastructure.Services.SceneManagement
{
	public class SceneSwitcher : ISceneSwitcher
	{
		public async UniTask SwitchSceneTo(string sceneName) => 
			await SceneManager.LoadSceneAsync(sceneName);
	}
}