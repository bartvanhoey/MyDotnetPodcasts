using MyDotnetPodcasts.ViewModels;

namespace MyDotnetPodcasts;

public partial class DiscoverPage : ContentPage
{
    private DiscoverViewModel _vm => BindingContext as DiscoverViewModel;

    public DiscoverPage(DiscoverViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        // TODO
        // player.OnAppearing();
        await _vm.InitializeAsync();
    }
}