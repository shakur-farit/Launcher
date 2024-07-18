using UnityEngine;

namespace Infrastructure.Services.ObjectsCreator
{
	public interface IObjectCreatorService
	{
		GameObject Instantiate(GameObject prefab);
	}
}