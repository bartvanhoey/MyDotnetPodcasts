using MyDotnetPodcasts.Helpers;

namespace MyDotnetPodcasts;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		TheTheme.SetTheme();

        MainPage = Config.Desktop ? new DesktopShell() : new MobileShell();


    }
}
