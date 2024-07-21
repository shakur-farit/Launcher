using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.Services.SceneManagement
{
	public class SceneSwitcher : ISceneSwitcher
	{
		public async UniTask SwitchSceneTo(string sceneName)
		{
			Debug.Log("herer");
			await SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
		}
	}
}