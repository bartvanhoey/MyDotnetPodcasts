using MyDotnetPodcasts.Models;

namespace MyDotnetPodcasts.Services;

public class SubscriptionsService
{
    private List<Show> _subscribedShows;

    public SubscriptionsService()
    {
        _subscribedShows = new List<Show>();
    }

    public IEnumerable<Show> GetSubscribedShows()
    {
        return this._subscribedShows;
    }

    public async Task SubscribeToShowAsync(Show show)
    {
        if (show == null)
            return;

        if (IsSubscribed(show.Id))
        {
            await UnSubscribeFromShowAsync(show);
            return;
        }

        this._subscribedShows.Add(show);
    }

    public async Task UnSubscribeFromShowAsync(Show podcast)
    {
        var userWantUnsubscribe = await App.Current.MainPage.DisplayAlert(
                    $"Do you want to unsubscribe from {podcast.Title} ?",
                    string.Empty,
                    "Yes, unsubcribe",
                    "Cancel");

        if (userWantUnsubscribe)
        {
            var showToRemove = this._subscribedShows.FirstOrDefault(p => p.Id == podcast.Id);
            if (showToRemove != null)
            {
                this._subscribedShows.Remove(showToRemove);
            }
        }
    }

    internal bool IsSubscribed(Guid id) => _subscribedShows.Any(p => p.Id == id);
}
