using System;
using System.Collections.Generic;

namespace Infrastructure.States.Launcher.StatesMachine
{
	public class LauncherStatesMachine : ILauncherStatesSwitcher, ILauncherStatesRegistrar
	{
		private readonly Dictionary<Type, ILauncherState> _statesDictionary = new();
		private ILauncherState _activeState;

		public void SwitchState<TState>() where TState : ILauncherState
		{
			_activeState?.Exit();
			ILauncherState state = _statesDictionary[typeof(TState)];
			_activeState = state;
			state.Enter();
		}

		public void RegisterState<TState>(TState state) where TState : ILauncherState =>
			_statesDictionary.Add(typeof(TState), state);
	}
}