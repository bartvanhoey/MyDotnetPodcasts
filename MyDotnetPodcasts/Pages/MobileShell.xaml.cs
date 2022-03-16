using MyDotnetPodcasts.ViewModels;

namespace MyDotnetPodcasts;

public partial class MobileShell
{
	public MobileShell()
	{
		// test

		InitializeComponent();

		BindingContext = new ShellViewModel();

	}
}