using UnityEngine;

namespace Infrastructure.Services.AssetsManagement
{
	[CreateAssetMenu(fileName = "WalkerAssetsReference", menuName = "Scriptable Object/Assets References/Walker Assets Reference")]
	public class WalkerAssetsReference : ScriptableObject
	{
		public string Character;
		public string Floor;
		public string Finish;
		public string HudAddress;
	}
}