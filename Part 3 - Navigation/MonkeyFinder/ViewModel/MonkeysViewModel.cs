using MonkeyFinder.Services;

namespace MonkeyFinder.ViewModel;

public partial class MonkeysViewModel : BaseViewModel
{
    public ObservableCollection<Monkey> Monkeys { get; } = new();
    MonkeyService monkeyService;
    IConnectivity connectivity;
    IGeolocation geolocation;

    public MonkeysViewModel(
        MonkeyService monkeyService,
        IConnectivity connectivity,
        IGeolocation geolocation
    )
    {
        Title = "Monkey Finder";
        this.monkeyService = monkeyService;
        this.connectivity = connectivity;
        this.geolocation = geolocation;
    }

    [RelayCommand]
    async Task GetMonkeysAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            if(connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert(
                    "No connectivity!",
                    $"Please check internet and try again.", "OK"
                );

                return;
            }
            var monkeys = await monkeyService.GetMonkeys();

            if(Monkeys.Count != 0)
                Monkeys.Clear();
                
            foreach(var monkey in monkeys)
                Monkeys.Add(monkey);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get monkeys: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }

    }

    [RelayCommand]
    public async Task GoToDetails(Monkey monkey)
    {
        if (monkey is null)
        {
            return;
        }
        await Shell.Current.GoToAsync(
            nameof(DetailsPage),
            true,
            new Dictionary<string, object>
            {
                {"Monkey", monkey }
            }
        );
    }

    [RelayCommand]
    public async Task GetClosestMonkeyAsync()
    {
        if (IsBusy || Monkeys.Count == 0)
        {
            return;
        }

        try
        {
            IsBusy = true;
            var location = await this.geolocation.GetLastKnownLocationAsync();
            if (location is null)
            {
                location = await this.geolocation.GetLocationAsync(
                    new GeolocationRequest
                    {
                        DesiredAccuracy = GeolocationAccuracy.Medium,
                        Timeout = TimeSpan.FromSeconds(30)
                    }
                );
            }

            var closestMonkey = Monkeys.OrderBy(monkey =>
                location.CalculateDistance(
                    monkey.Latitude,
                    monkey.Longitude,
                    DistanceUnits.Miles
                )
            ).FirstOrDefault();

            await Shell.Current.DisplayAlert(
                "",
                closestMonkey.Name + " " + closestMonkey.Location,
                "OK"
            );
        }
        catch(Exception ex)
        {
            Debug.WriteLine($"Unable to query location: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
