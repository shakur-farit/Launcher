namespace Infrastructure.Services.AssetsManagement
{
	public class AssetsReferencesHandler : IAssetsReferencesHandler
	{
		public LauncherAssetsReference LauncherAssetsReference { get; set; }
		public WalkerAssetsReference WalkerAssetsReference { get; set; }
		public ClickerAssetsReference ClickerAssetsReference { get; set; }
	}
}