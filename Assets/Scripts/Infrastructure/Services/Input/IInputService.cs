using UnityEngine;

namespace Infrastructure.Services.Input
{
	public interface IInputService
	{
		Vector2 MovementAxis { get; }
		void OnEnable();
		void OnDisable();
		void RegisterMovementInputAction();
	}
}