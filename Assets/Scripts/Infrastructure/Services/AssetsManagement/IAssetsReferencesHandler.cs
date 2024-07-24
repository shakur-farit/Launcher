namespace Infrastructure.Services.AssetsManagement
{
	public interface IAssetsReferencesHandler
	{
		LauncherAssetsReference LauncherAssetsReference { get; set; }
		WalkerAssetsReference WalkerAssetsReference { get; set; }
		ClickerAssetsReference ClickerAssetsReference { get; set; }
	}
}