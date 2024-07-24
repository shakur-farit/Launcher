using Infrastructure.Services.AssetsManagement;
using UnityEngine;
using UnityEngine.UI;

namespace Launcher.Hud
{
	public class ClickerButtonsHolder : MonoBehaviour
	{
		[SerializeField] private Button _load;
		[SerializeField] private Button _unload;
		[SerializeField] private Button _play;

		private IAssetsReferencesHandler _handle;

		public void Constructor(IAssetsReferencesHandler handle) => 
			_handle = handle;

		private void Awake()
		{
			_load.onClick.AddListener(LoadAssets);
			_play.onClick.AddListener(StartGame);
			_unload.onClick.AddListener(UnloadAssets);

			if (_handle.ClickerAssetsReference == null)
			{
				_load.gameObject.SetActive(true);
				_play.gameObject.SetActive(false);
			}
			else
			{
				_load.gameObject.SetActive(false);
				_play.gameObject.SetActive(true);
			}
		}

		private void LoadAssets()
		{
		}

		private void UnloadAssets()
		{
		}

		private void StartGame()
		{
		}
	}
}