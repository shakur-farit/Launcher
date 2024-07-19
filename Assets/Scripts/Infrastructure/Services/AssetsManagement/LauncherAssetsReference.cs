using UnityEngine;

namespace Infrastructure.Services.AssetsManagement
{
	[CreateAssetMenu(fileName = "LauncherAssetsReference", menuName = "Scriptable Object/Assets References/Launcher Assets Reference")]
	public class LauncherAssetsReference : ScriptableObject
	{
		public string HudAddress;
	}
}