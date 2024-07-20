using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Infrastructure.Services.Score
{
	public class InputService : IInputService
	{
		private readonly CharacterInput _input;

		private InputAction _moveAction;

		private Vector2 _moveInput;

		public Vector2 MovementAxis => GetMovementInputAxis();

		public InputService(CharacterInput input) =>
			_input = input;

		public void OnEnable() =>
			_input.Enable();

		public void OnDisable() =>
			_input.Disable();

		public void RegisterMovementInputAction()
		{
			_moveAction = _input.Movement.Move;

			_moveAction.performed += context => _moveInput = context.ReadValue<Vector2>();
			_moveAction.canceled += context => _moveInput = Vector2.zero;
		}

		private Vector2 GetMovementInputAxis() =>
			new(_moveInput.x, _moveInput.y);
	}
}