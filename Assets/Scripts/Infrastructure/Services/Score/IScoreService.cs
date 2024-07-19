namespace Infrastructure.Services.Score
{
	public interface IScoreService
	{
		int Scores { get; }
		void AddScore(int amount);
	}
}