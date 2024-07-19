using Clicker.Hud.Factory;
using UnityEngine;

namespace Clicker.Infrastructure.States
{
	public class LoadClickerState : IClickerState
	{
		private readonly IClickerHudFactory _clickerHudFactory;

		public LoadClickerState(IClickerHudFactory clickerHudFactory) => 
			_clickerHudFactory = clickerHudFactory;

		public void Enter()
		{
			Debug.Log("StartGame");

			_clickerHudFactory.CreateHud();
		}

		public void Exit()
		{
		}
	}
}