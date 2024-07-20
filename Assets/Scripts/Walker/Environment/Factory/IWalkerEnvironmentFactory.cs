using Cysharp.Threading.Tasks;

namespace Walker.Environment.Factory
{
	public interface IWalkerEnvironmentFactory
	{
		UniTask CreateEnvironment();
		void DestroyEnvironment();
	}
}