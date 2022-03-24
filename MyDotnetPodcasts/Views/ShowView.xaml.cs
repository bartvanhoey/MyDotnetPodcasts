using MyDotnetPodcasts.ViewModels;
using System.Windows.Input;

namespace MyDotnetPodcasts.Views;

public partial class ShowView 
{
	public static readonly BindableProperty SubscriptionCommandProperty =
		BindableProperty.Create(nameof(SubscriptionCommand), typeof(ICommand), typeof(ShowView), default(string));

	public static readonly BindableProperty SubscriptionCommandParameterProperty =
		BindableProperty.Create(nameof(SubscriptionCommandParameter), typeof(ShowViewModel), typeof(ShowView), default(ShowViewModel));


	public ICommand SubscriptionCommand
    {
        get { return (ICommand)GetValue(SubscriptionCommandProperty); }
        set { SetValue(SubscriptionCommandProperty, value); }
    }

    public ShowViewModel SubscriptionCommandParameter {
		get { return (ShowViewModel)GetValue(SubscriptionCommandParameterProperty); }
		set { SetValue(SubscriptionCommandParameterProperty, value); }
	}


	public ShowView()
	{
		InitializeComponent();
	}
}