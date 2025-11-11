using System.ComponentModel;
using System.Runtime.CompilerServices;
using Travelling;

namespace SmartTravelPlanner;

public class TravelerViewModel : INotifyPropertyChanged
{
    private Traveler? traveler;
    private CityGraph? graph;
    private string destination;
    private string location;
    private string newName;
    private string cityToRemove;
    private string cityToAdd;
    private List<string> _availableNextCities = new List<string>();

    private void UpdateAvailableNextCities()
    {
        if (graph == null || traveler == null)
        {
            AvailableNextCities = new List<string>();
            return;
        }

        string? lastCity = Route.LastOrDefault();
        if (!string.IsNullOrEmpty(lastCity))
        {
            // Added new method GetNeighbors to CityGraph
            AvailableNextCities = graph.GetNeighbors(lastCity);
        }
        else
        {
            // if no cities in route, get neighbors of current location
            AvailableNextCities = graph.GetNeighbors(traveler.GetLocation());
        }
    }

    public TravelerViewModel() { }

    public bool IsTravelerCreated
    {
        get { return traveler is not null; }
    }

    public string NewName
    {
        get { return newName; }
        set
        {
            if (newName == value)
                return;
            newName = value;
            OnPropertyChanged();
        }
    }

    public string CurrentLocation 
    {
        get { return location; }
        set 
        {
            location = value;
            traveler?.SetLocation(value);
            OnPropertyChanged();
        }
    }

    public string Destination
    {
        get { return destination; }
        set {
            destination = value;
            OnPropertyChanged();
        }
    }

    public string CityToRemove 
    { 
        get { return cityToRemove; } 
        set {
            if (cityToRemove == value)
                return;
            cityToRemove = value;
            OnPropertyChanged();
        }
    }

    //todo maybe do not allow duplicate cities
    public string CityToAdd
    { 
        get { return cityToAdd; } 
        set {
            cityToAdd = value;
            OnPropertyChanged();
        }
    }

    public List<string> Route
    {
        get
        {
            var routeStr = traveler?.GetRoute();
            if (string.IsNullOrEmpty(routeStr))
            {
                return new List<string>();
            }
            return routeStr.Split(" -> ").ToList();
        }
    }

    public string JoiedRoute
    {
        get { return traveler?.GetRoute() ?? ""; }
    }

    public string Distance
    {
        get { return (graph?.GetPathDistance(Route) ?? 0).ToString() + " km"; }
    }


    public void CreateTraveler() {
        if (string.IsNullOrEmpty(location) || string.IsNullOrEmpty(newName))
            throw new InvalidOperationException();
        traveler = new Traveler(NewName);
        traveler.SetLocation(CurrentLocation);
        OnPropertyChanged(nameof(Route));
        OnPropertyChanged(nameof(Distance));
        // update available next cities, if traveler was recreated with loaded map
        if (graph is not null)
        {
            UpdateAvailableNextCities();
        }
    }

    public void Save(string filePath) { 
        if (traveler is null)
            throw new InvalidOperationException();
        traveler.SaveToFile(filePath);
    }

    public void Load(string filePath) {
        traveler = Traveler.LoadFromFile(filePath);
        NewName = traveler.GetName();
        CurrentLocation = traveler.GetLocation();
        OnPropertyChanged(nameof(Route));
        OnPropertyChanged(nameof(Distance));
        UpdateAvailableNextCities();
    }

    public void LoadMap(string filePath) {
        graph = CityGraph.LoadFromFile(filePath);
        UpdateAvailableNextCities();
    }

    public bool PlanRoute() {
        //todo better exceptions
        if (traveler is null) 
            throw new InvalidOperationException();
        if (graph is null) 
            throw new InvalidOperationException();
        if (string.IsNullOrEmpty(destination))
            throw new InvalidOperationException();
        if (traveler.PlanRouteTo(destination, graph)) {
            OnPropertyChanged(nameof(Route));
            OnPropertyChanged(nameof(Distance));
            CityToRemove = Route.FirstOrDefault() ?? "";
            OnPropertyChanged(nameof(CityToRemove));
            UpdateAvailableNextCities();
            return true;
        }
        return false;
    }

    public void AddCity() {
        if (traveler is null) 
            throw new InvalidOperationException("Traveler is not created. Create a traveler first.");
        if (string.IsNullOrEmpty(cityToAdd)) {
            throw new InvalidOperationException("Can't add an empty city.");
        }
        traveler.AddCity(cityToAdd);
        CityToRemove = cityToAdd;
        CityToAdd = "";
        OnPropertyChanged(nameof(Route));
        UpdateAvailableNextCities();
    }

    public void RemoveCity() {
        if (traveler is null) 
            throw new InvalidOperationException("Traveler is not created. Create a traveler first.");
        if (string.IsNullOrEmpty(cityToRemove)) {
            throw new InvalidOperationException("Can't remove an empty city.");
        }
        traveler.RemoveCity(cityToRemove);
        OnPropertyChanged(nameof(Route));
        CityToRemove = Route.FirstOrDefault() ?? "";
        OnPropertyChanged(nameof(CityToRemove));
        UpdateAvailableNextCities();
    }

    public void ClearRoute() {
        if (traveler is null) 
            throw new InvalidOperationException("Traveler is not created. Create a traveler first.");
        traveler.ClearRoute();
        OnPropertyChanged(nameof(Route));
        OnPropertyChanged(nameof(Distance));
        CityToRemove = "";
        OnPropertyChanged(nameof(CityToRemove));
        UpdateAvailableNextCities();
    }

    public List<string> AvailableNextCities
    {
        get { return _availableNextCities; }
        set
        {
            _availableNextCities = value;
            OnPropertyChanged();
        }
    }

    // Boilerplate code for INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
