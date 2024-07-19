namespace Launcher.Infrastructure.States
{
	public interface ILauncherState
	{
		void Enter();
		void Exit();
	}
}