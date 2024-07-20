using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.BaseFactory;
using Infrastructure.Services.ObjectsCreator;
using UnityEngine;

namespace Walker.Character.Factory
{
	public class WalkerCharacterFactory : FactoryBase, IWalkerCharacterFactory
	{
		private GameObject _character;

		protected WalkerCharacterFactory(IAssetsProvider assetsProvider, IObjectCreatorService objectsCreator) : 
			base(assetsProvider, objectsCreator)
		{
		}

		public async UniTask CreateCharacter()
		{
			string address = AssetsReferencesAddresses.WalkerReferenceAddress;
			WalkerAssetsReference reference = await InitReference<WalkerAssetsReference>(address);
			_character = await CreateObject(reference.CharacterAddress);
		}

		public void Destroy() =>
			Object.Destroy(_character);
	}
}