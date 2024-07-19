using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Launcher.UI.Factory
{
	public class Hud : MonoBehaviour
	{
		[SerializeField] private Button _launcherQuitButton;
		[SerializeField] private Button _startClickerButton;
		[SerializeField] private Button _startWalkerButton;

		private void Awake()
		{
			_startClickerButton.onClick.AddListener(StartClicker);
			_startWalkerButton.onClick.AddListener(StartWalker);
			_launcherQuitButton.onClick.AddListener(QuitLauncher);
		}

		private void StartClicker() => 
			SceneManager.LoadSceneAsync("Clicker");

		private void StartWalker() => 
			SceneManager.LoadSceneAsync("Walker");

		private void QuitLauncher()
		{
			Application.Quit();
		}
	}
}