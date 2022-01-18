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

        //RegisterRoutesDynamically();
    }

    private void RegisterRoutesDynamically()
    {
        var assembly = typeof(AppShell).Assembly;
        var nameSpace = "HaloInfiniteMobileApp.Views";
        var types = assembly.GetTypes()
              .Where(t => string.Equals(t.Namespace, nameSpace, StringComparison.Ordinal) && t.MemberType == MemberTypes.TypeInfo)
              .ToArray();
        foreach(var type in types)
        {
            if (type.Equals(typeof(OnboardingView)))
                continue;

            Routing.RegisterRoute(type.Name, type);
        }
    }
}
