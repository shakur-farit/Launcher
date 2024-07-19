using UnityEngine;

namespace Services.ObjectsCreator
{
	public interface IObjectCreatorService
	{
		GameObject Instantiate(GameObject prefab);
		GameObject Instantiate(GameObject prefab, Transform parentTransform);
	}
}