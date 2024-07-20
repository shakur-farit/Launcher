using System;
using UnityEngine.Serialization;

namespace Data
{
	[Serializable]
	public class ClickerData
	{
		[FormerlySerializedAs("Score")] public int CurrentScore;
	}
}