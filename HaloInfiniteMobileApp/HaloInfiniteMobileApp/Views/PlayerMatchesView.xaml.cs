﻿using HaloInfiniteMobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HaloInfiniteMobileApp.Views;
[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class PlayerMatchesView : ContentPage
{
    public PlayerMatchesView()
    {
        InitializeComponent();
        BindingContext = DependencyService.Get<PlayerMatchesViewModel>();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is PlayerMatchesViewModel)
            await ((BindingContext as PlayerMatchesViewModel)?.Initialize(null)).ConfigureAwait(false);
    }
}
