using MyDotnetPodcasts.ViewModels;

namespace MyDotnetPodcasts;

public partial class DesktopShell 
{
	public DesktopShell()
	{
		InitializeComponent();

		BindingContext = new ShellViewModel();
	}
}