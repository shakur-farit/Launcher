using Infrastructure.States;
using Infrastructure.States.StatesMachine;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Launcher.Hud
{
	public class LauncherHud : MonoBehaviour
	{
		[SerializeField] private Button _launcherQuitButton;
		[SerializeField] private Button _startClickerButton;
		[SerializeField] private Button _startWalkerButton;

		private ILauncherStatesSwitcher _switcher;

		[Inject]
		public void Constructor(ILauncherStatesSwitcher switcher) => 
			_switcher = switcher;

		private void Awake()
		{
			_startClickerButton.onClick.AddListener(StartClicker);
			_startWalkerButton.onClick.AddListener(StartWalker);
			_launcherQuitButton.onClick.AddListener(QuitLauncher);
		}

		private void StartClicker() =>
			_switcher.SwitchStateTo<ClickerState>();

		private void StartWalker() => 
			_switcher.SwitchStateTo<WalkerState>();


		private void QuitLauncher()
		{
#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
		}
	}
}