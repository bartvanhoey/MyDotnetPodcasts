using CommunityToolkit.Mvvm.ComponentModel;
using MyDotnetPodcasts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDotnetPodcasts.ViewModels
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public partial class ShowDetailViewModel
    {
        private readonly ShowsService _showsService;
        private readonly PlayerService _playerService;
        private readonly SubscriptionsService _subscriptionsService;
        private readonly ListenLaterService _listenLaterService;

        [ObservableProperty]
        private ShowViewModel _showViewModel;
        private Guid _showId;


        internal async Task InitializeAsync()
        {
            if (_showViewModel != null)
                return;

            _showId = new Guid(Id);
            await FetchAsync();
        }

        private async Task FetchAsync()
        {
            var show = _showsService.GetShowByIdAsync(_showId);
            await Task.CompletedTask;
        }

        public string Id { get; set; }

        public ShowDetailViewModel(ShowsService showsService, PlayerService playerService, SubscriptionsService subscriptionsService, ListenLaterService listenLaterService)
        {
            _showsService=showsService;
            _playerService=playerService;
            _subscriptionsService=subscriptionsService;
            _listenLaterService=listenLaterService;
        }

    }
}
