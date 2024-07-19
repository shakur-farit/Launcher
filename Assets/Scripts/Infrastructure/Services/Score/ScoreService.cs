namespace Infrastructure.Services.Score
{
	public class ScoreService : IScoreService
	{
		public int Scores { get; private set; }
		public void AddScore(int amount) => 
			Scores += amount;
	}
}