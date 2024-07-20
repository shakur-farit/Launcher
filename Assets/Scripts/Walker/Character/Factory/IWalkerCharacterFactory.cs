using Cysharp.Threading.Tasks;

namespace Walker.Character.Factory
{
	public interface IWalkerCharacterFactory
	{
		UniTask CreateCharacter();
		void Destroy();
	}
}