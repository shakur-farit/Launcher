namespace Clicker.Hud.Factory
{
	public interface IScoreService
	{
		int Scores { get; }
		void AddScore(int amount);
	}
}