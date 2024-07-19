using UnityEngine;
using Zenject;

namespace Infrastructure.Services.ObjectsCreator
{
	public class ObjectCreatorService : IObjectCreatorService
	{
		private readonly IInstantiator _instantiator;

		public ObjectCreatorService(IInstantiator instantiator) =>
			_instantiator = instantiator;

		public GameObject Instantiate(GameObject prefab) =>
			_instantiator.InstantiatePrefab(prefab);

		public GameObject Instantiate(GameObject prefab, Transform parentTransform) => 
			_instantiator.InstantiatePrefab(prefab, parentTransform);
	}
}