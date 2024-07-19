using System;
using System.Collections.Generic;
using Clicker.Infrastructure.States.Factory;
using Launcher.Infrastructure.States.Factory;
using Launcher.Infrastructure.States.StatesMachine;
using Launcher.Infrastructure.States;
using UnityEngine;
using Zenject;

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

	public class ClickerEnterPoint : MonoBehaviour
	{
		private IClickerStatesSwitcher _clickerStatesSwitcher;
		private IClickerStatesRegistrar _clickerStatesRegistrar;
		private IClickerStatesFactory _clickerStatesFactory;

		[Inject]
		public void Constructor(IClickerStatesRegistrar registrar, IClickerStatesSwitcher switcher,
			IClickerStatesFactory factory)
		{
			_clickerStatesSwitcher = switcher;
			_clickerStatesRegistrar = registrar;
			_clickerStatesFactory = factory;
		}


		private void Awake() =>
			StartLauncher();

		private void StartLauncher()
		{
			RegisterLauncherStates();
			EnterInLoadStaticDataState();
		}

		private void EnterInLoadStaticDataState() =>
			_clickerStatesSwitcher.SwitchState<LoadClickerState>();

		private void RegisterLauncherStates() =>
			_clickerStatesRegistrar.RegisterState(_clickerStatesFactory.CreateLauncherState<LoadClickerState>());
	}
}