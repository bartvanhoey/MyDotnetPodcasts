using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmHelpers;
using MyDotnetPodcasts.Models;
using MyDotnetPodcasts.Resources.Strings;
using MyDotnetPodcasts.Services;

namespace MyDotnetPodcasts.ViewModels
{
    public partial class DiscoverViewModel : BaseViewModel
    {
        //    [ObservableProperty]
        //    private string _text;
        private IEnumerable<ShowViewModel> _showViewModels;

        //[ObservableProperty]
        private CategoriesViewModel _categoriesViewModel;

        private readonly SubscriptionsService _subscriptionsService;
        private readonly ShowsService _showsService;
        public ObservableRangeCollection<ShowGroup> ShowGroups { get; private set; } = new ObservableRangeCollection<ShowGroup>();

        public DiscoverViewModel(ShowsService showsService, SubscriptionsService subscriptionsService, CategoriesViewModel categoriesViewModel)
        {
            _showsService=showsService;
            _subscriptionsService=subscriptionsService;
            _categoriesViewModel=categoriesViewModel;
        }

        internal async Task InitializeAsync() => await FetchAsync();

        private async Task FetchAsync()
        {
            var shows = await _showsService.GetShowsAsync();

            if (shows == null)
            {
                await Shell.Current.DisplayAlert(AppResource.Error_Title, AppResource.Error_Message, AppResource.Close);
                return;
            }

            await _categoriesViewModel.InitializeAsync();

            _showViewModels = await ConvertToShowViewModels(shows);

            UpdateShowGroups(_showViewModels);
        }

        private void UpdateShowGroups(IEnumerable<ShowViewModel> showViewModels)
        {
            var showGroups = new ObservableRangeCollection<ShowGroup> {
                new ShowGroup(AppResource.Whats_New, showViewModels.Take(3).ToList()),
                new ShowGroup(AppResource.Specially_For_You, showViewModels.Take(3..).ToList())
            };
            ShowGroups.ReplaceRange(showGroups);
        }

        private async Task<List<ShowViewModel>> ConvertToShowViewModels(IEnumerable<Show> shows)
        {
            var showViewModels = new List<ShowViewModel>();
            foreach (var show in shows)
            {
                var showViewModel = new ShowViewModel(show, _subscriptionsService);
                await showViewModel.InitializeAsync();
                showViewModels.Add(showViewModel);
            }
            return showViewModels;
        }

        [ICommand]
        private async Task Search()
        {
            await Task.CompletedTask;
        }


        [ICommand]
        public async Task Subscribe(ShowViewModel vm)
        {
            await _subscriptionsService.UnSubscribeFromShowAsync(vm.Show);
            vm.IsSubscribed = _subscriptionsService.IsSubscribed(vm.Show.Id);
        }

        [ICommand]
        private Task SeeAllCategories()
        {
            return Shell.Current.GoToAsync($"{nameof(CategoriesPage)}");
        }
    }
}
