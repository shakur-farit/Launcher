namespace Infrastructure.Services.Timer
{
	public interface ITimerFormater
	{
		string GetFormattedTime(int currentTime);
	}
}