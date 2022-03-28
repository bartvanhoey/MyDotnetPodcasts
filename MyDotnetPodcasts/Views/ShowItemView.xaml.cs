using MyDotnetPodcasts.ViewModels;
using System.Windows.Input;

namespace MyDotnetPodcasts.Views;

public partial class ShowItemView
{
    public static readonly BindableProperty SubscriptionCommandProperty =
        BindableProperty.Create(nameof(SubscriptionCommand), typeof(ICommand), typeof(ShowItemView), default(string));

    public static readonly BindableProperty SubscriptionCommandParameterProperty =
        BindableProperty.Create(nameof(SubscriptionCommandParameter), typeof(ShowViewModel), typeof(ShowItemView), default(ShowViewModel));

    public ShowViewModel SubscriptionCommandParameter
    {
        get => (ShowViewModel)GetValue(SubscriptionCommandParameterProperty);
        set => SetValue(SubscriptionCommandParameterProperty, value);
    }
    public ICommand SubscriptionCommand
    {
        get => (ICommand)GetValue(SubscriptionCommandProperty);
        set => SetValue(SubscriptionCommandProperty, value);
    }



    public ShowItemView() => InitializeComponent();
}