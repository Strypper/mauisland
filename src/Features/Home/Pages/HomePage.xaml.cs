using Newtonsoft.Json;
using System.Text;

namespace MAUIsland;
public partial class HomePage 
{
    public HomePage(HomePageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;

    }
}