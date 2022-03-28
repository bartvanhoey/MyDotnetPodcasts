using MyDotnetPodcasts.ViewModels;

namespace MyDotnetPodcasts;

public partial class ShowDetailPage : ContentPage
{
	private ShowDetailViewModel viewModel => BindingContext as ShowDetailViewModel;

	public ShowDetailPage(ShowDetailViewModel showDetailViewModel)
	{
		InitializeComponent();
		BindingContext = showDetailViewModel;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
		player.OnAppearing();
		await viewModel.InitializeAsync();
    }

    protected override void OnDisappearing()
    {
        player.OnDisappearing();
        base.OnDisappearing();
    }
}