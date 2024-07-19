using System;
using System.Collections.Generic;

namespace Clicker.Infrastructure.States.StatesMachine
{
	public class ClickerStatesMachine : IClickerStatesSwitcher, IClickerStatesRegistrar
	{
		private readonly Dictionary<Type, IClickerState> _statesDictionary = new();
		private IClickerState _activeState;

		public void SwitchState<TState>() where TState : IClickerState
		{
			_activeState?.Exit();
			IClickerState state = _statesDictionary[typeof(TState)];
			_activeState = state;
			state.Enter();
		}

		public void RegisterState<TState>(TState state) where TState : IClickerState =>
			_statesDictionary.Add(typeof(TState), state);
	}
}