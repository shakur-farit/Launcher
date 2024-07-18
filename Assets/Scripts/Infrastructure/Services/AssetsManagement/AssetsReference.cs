using UnityEngine;

namespace Infrastructure.Services.AssetsManagement
{
	[CreateAssetMenu(fileName = "LauncherAssetsReference", menuName = "Scriptable Object/Assets Reference")]
	public class AssetsReference : ScriptableObject
	{
		public string UIRootAddress;
	}
}