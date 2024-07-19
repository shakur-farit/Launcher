using UnityEngine;

namespace Services.AssetsManagement
{
	[CreateAssetMenu(fileName = "LauncherAssetsReference", menuName = "Scriptable Object/Assets Reference")]
	public class LauncherAssetsReference : ScriptableObject
	{
		public string HudAddress;
	}
}