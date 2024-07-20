namespace Infrastructure.Services.Score
{
	public interface IScoreService
	{
		int CurrentScores { get; }
		void AddScore(int amount);
		void LoadCurrentScoreData();
	}
}