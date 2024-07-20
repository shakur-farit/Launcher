using UnityEngine;
using Zenject;

namespace Infrastructure.Services.Score
{
	public class CharacterMover : MonoBehaviour
	{
		private const float MovementSpeed = 5f;

		private IInputService _input;

		[Inject]
		public void Constructor(IInputService input) =>
			_input = input;

		private void OnEnable() =>
			_input.OnEnable();

		private void OnDestroy() =>
			_input.OnDisable();

		private void Awake() =>
			_input.RegisterMovementInputAction();

		private void FixedUpdate() =>
			Move();

		private void Move()
		{
			Vector2 movementAxis = _input.MovementAxis;

			if (movementAxis.sqrMagnitude > Mathf.Epsilon)
			{
				Vector3 movementVector = transform.TransformDirection(movementAxis);
				movementVector.Normalize();
				transform.position += new Vector3(movementVector.x, 0f, movementVector.y) * MovementSpeed * Time.deltaTime;
			}
		}
	}
}