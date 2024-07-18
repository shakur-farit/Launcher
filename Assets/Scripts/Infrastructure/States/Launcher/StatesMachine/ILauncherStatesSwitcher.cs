namespace Infrastructure.States.Launcher.StatesMachine
{
	public interface ILauncherStatesSwitcher
	{
		void SwitchState<T>() where T : ILauncherState;
	}
}