public interface ILauncherStatesSwitcher
{
	void SwitchState<T>() where T : IState;
}