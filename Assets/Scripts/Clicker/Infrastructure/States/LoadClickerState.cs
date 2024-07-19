using UnityEngine;

namespace Clicker.Infrastructure.States
{
	public class LoadClickerState : IClickerState
	{
		public void Enter()
		{
			Debug.Log("StartGame");
		}

		public void Exit()
		{
		}
	}
}