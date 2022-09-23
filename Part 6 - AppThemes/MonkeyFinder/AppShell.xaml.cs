using MonkeyFinder.View;

namespace MonkeyFinder;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
		Routing.RegisterRoute(nameof(AbsoluteLayoutPage), typeof(AbsoluteLayoutPage));
        Routing.RegisterRoute(nameof(GridLayoutPage), typeof(GridLayoutPage));
        Routing.RegisterRoute(nameof(HorrizonalStackLayoutPage), typeof(HorrizonalStackLayoutPage));
        Routing.RegisterRoute(nameof(PresentData), typeof(PresentData));
        Routing.RegisterRoute(nameof(Controls), typeof(Controls));
    }
}