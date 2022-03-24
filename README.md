# MyDotnetPodcasts

```csharp
    #if !MACCATALYST
                if (Connectivity.NetworkAccess == NetworkAccess.None)
                    json = Barrel.Current.Get<string>(path);
    #endif
                if (!Barrel.Current.IsExpired(path))
                    json = Barrel.Current.Get<string>(path);
```




```csharp
    var showGroups = new ObservableRangeCollection<ShowGroup>
    {
        new ShowGroup(AppResource.Whats_New, showViewModels.Take(3).ToList()),
        new ShowGroup(AppResource.Specially_For_You, showViewModels.Take(3..).ToList())
    };
```