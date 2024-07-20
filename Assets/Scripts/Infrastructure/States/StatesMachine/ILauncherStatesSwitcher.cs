namespace Infrastructure.States.StatesMachine
{
	public interface ILauncherStatesSwitcher
	{
		void SwitchStateTo<T>() where T : IState;
	}
}