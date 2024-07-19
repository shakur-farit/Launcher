using UnityEngine;

namespace Infrastructure.Services.AssetsManagement
{
	[CreateAssetMenu(fileName = "ClickerAssetsReference", menuName = "Scriptable Object/Assets References/Clicker Assets Reference")]
	public class ClickerAssetsReference : ScriptableObject
	{
		public string HudAddress;
	}
}