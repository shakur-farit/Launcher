namespace Infrastructure.States.StatesMachine
{
	public interface ILauncherStatesSwitcher
	{
		void SwitchState<T>() where T : IState;
	}
}