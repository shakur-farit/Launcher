namespace Infrastructure.Services.Score
{
	public interface ITimerFormater
	{
		string GetFormattedTime(int currentTime);
	}
}