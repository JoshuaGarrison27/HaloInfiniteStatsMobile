using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HaloInfiniteMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppNavigationPage : NavigationPage
    {
        public AppNavigationPage()
        {
            InitializeComponent();
        }

        public AppNavigationPage(Page root) : base(root)
        {
            InitializeComponent();
        }
    }
}