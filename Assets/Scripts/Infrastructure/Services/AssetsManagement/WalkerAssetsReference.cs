using UnityEngine;

namespace Infrastructure.Services.AssetsManagement
{
	[CreateAssetMenu(fileName = "WalkerAssetsReference", menuName = "Scriptable Object/Assets References/Walker Assets Reference")]
	public class WalkerAssetsReference : ScriptableObject
	{
		public string CharacterAddress;
		public string EnvironmentAddress;
		public string HudAddress;
		public string UIRoot;
		public string GameCompleteWindow;
	}
}