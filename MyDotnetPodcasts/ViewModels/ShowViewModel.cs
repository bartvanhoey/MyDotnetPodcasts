using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmHelpers;
using MyDotnetPodcasts.Models;
using MyDotnetPodcasts.Services;
using System.Windows.Input;

namespace MyDotnetPodcasts.ViewModels
{
    [ObservableObject]
    public partial class ShowViewModel
    {
        public Show Show { get; set; }
        private readonly SubscriptionsService _subscriptionsService;

        public ShowViewModel(Show show, SubscriptionsService subscriptionsService)
        {
            Show=show;
            _subscriptionsService=subscriptionsService;
        }

        [ObservableProperty]
        private bool _isSubscribed;

        public IEnumerable<Episode> Episodes { get => Show?.Episodes; }

        public Uri Image { get => Show?.Image; }

        public string Author { get => Show?.Author; }

        public string Title { get => Show?.Title; }

        public string Description { get => Show?.Description; }

        public ICommand SubscribeCommand { get; internal set; }

        internal Task InitializeAsync()
        {
            _isSubscribed = _subscriptionsService.IsSubscribed(Show.Id);
            return Task.CompletedTask;
        }

        [ICommand]
        private Task NavigateToDetail() => Shell.Current.GoToAsync($"{nameof(ShowDetailPage)}?Id={Show.Id}");

    }
}
