using System;

namespace Data
{
	[Serializable]
	public class Progress
	{
		public ClickerData ClickerData = new();
		public WalkerData WalkerData = new();
	}
}