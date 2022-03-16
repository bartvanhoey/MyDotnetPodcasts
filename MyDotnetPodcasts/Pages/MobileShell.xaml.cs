using MyDotnetPodcasts.ViewModels;

namespace MyDotnetPodcasts;

public partial class MobileShell
{
	public MobileShell()
	{
		InitializeComponent();

		BindingContext = new ShellViewModel();

	}
}