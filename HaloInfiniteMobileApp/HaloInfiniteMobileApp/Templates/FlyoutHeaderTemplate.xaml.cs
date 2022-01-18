using HaloInfiniteMobileApp.Constants;
using HaloInfiniteMobileApp.Interfaces;
using HaloInfiniteMobileApp.Models;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HaloInfiniteMobileApp.Templates;
[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class FlyoutHeaderTemplate : Grid
{
    private PlayerAppearance _playerAppearance;
    private string _heroText;

    public FlyoutHeaderTemplate()
    {
        InitializeComponent();
        BindingContext = this;
        var haloInfiniteService = DependencyService.Get<IHaloInfiniteService>();
        var settingsService = DependencyService.Get<ISettingsService>();

        var gamertag = settingsService.GetItem(SettingsConstants.Gamertag);
        if (!string.IsNullOrWhiteSpace(gamertag))
        {
            HeroText = gamertag;
            var playerAppearanceRequest = new PlayerAppearanceRequest() { Gamertag = gamertag };
            PlayerAppearance = Task.Run(async () => await haloInfiniteService.GetPlayerAppearance(playerAppearanceRequest).ConfigureAwait(false)).Result;
        } else
        {
            HeroText = "Unknown";
            PlayerAppearance = new PlayerAppearance();
        }
    }

    public string HeroText
    {
        get => _heroText;
        set
        {
            _heroText = value;
            OnPropertyChanged();
        }
    }

    public PlayerAppearance PlayerAppearance
    {
        get => _playerAppearance;
        set
        {
            _playerAppearance = value;
            OnPropertyChanged();
        }
    }
}
