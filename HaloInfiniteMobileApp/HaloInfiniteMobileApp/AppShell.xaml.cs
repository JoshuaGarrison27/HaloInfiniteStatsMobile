using HaloInfiniteMobileApp.Views;
using System;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;

namespace HaloInfiniteMobileApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(OnboardingView), typeof(OnboardingView));
    }
}
