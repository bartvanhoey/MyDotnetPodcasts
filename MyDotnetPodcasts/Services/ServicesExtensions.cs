namespace MyDotnetPodcasts.Services
{
    public static class ServicesExtensions
    {

        public static MauiAppBuilder ConfigureServices(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<SubscriptionsService>();
            builder.Services.AddHttpClient<ShowsService>(client =>
            {
                client.BaseAddress = new Uri(Config.APIUrl);
            });
            builder.Services.AddSingleton<ListenLaterService>();
            builder.Services.TryAddSingleton<PlayerService>();

            return builder;

        }

    }
}
