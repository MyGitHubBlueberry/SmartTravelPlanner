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
    private List<string> availableNextCities = new List<string>();

    private void UpdateAvailableNextCities()
    {
        if (graph is null || traveler is null)
        {
            AvailableNextCities.Clear();
            return;
        }

        string? lastCity = Route.LastOrDefault();
        if (!string.IsNullOrEmpty(lastCity))
        {
            AvailableNextCities = graph.GetNeighbors(lastCity);
        }
        else
        {
            AvailableNextCities = graph.GetNeighbors(traveler.GetLocation());
        }
        cityToAdd = availableNextCities.FirstOrDefault() ?? "";
        OnPropertyChanged(nameof(CityToAdd));
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


    public string CityToAdd
    { 
        get { return cityToAdd; } 
        set {
            if (cityToAdd == value)
                return;
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
            throw new InvalidOperationException(Error.EMPTY_TRAV_OR_DEST_ERROR);
        traveler = new Traveler(NewName);
        traveler.SetLocation(CurrentLocation);
        OnPropertyChanged(nameof(Route));
        OnPropertyChanged(nameof(Distance));
        if (graph is not null)
        {
            UpdateAvailableNextCities();
        }
    }

    public void Save(string filePath) { 
        if (traveler is null)
            throw new InvalidOperationException(Error.EMPTY_TRAV_OR_DEST_ERROR);
        traveler.SaveToFile(filePath);
    }

    public void Load(string filePath) {
        try
        {
            traveler = Traveler.LoadFromFile(filePath);
        }
        catch (Exception)
        {
            throw new InvalidOperationException(Error.JSON_PARSE_ERROR);
        }
        NewName = traveler.GetName();
        CurrentLocation = traveler.GetLocation();
        OnPropertyChanged(nameof(Route));
        OnPropertyChanged(nameof(Distance));
        UpdateAvailableNextCities();
    }

    public void LoadMap(string filePath) {
        try
        {
            graph = CityGraph.LoadFromFile(filePath);
        } 
        catch(Exception)
        {
            throw new InvalidOperationException(Error.MAP_ERROR);
        }
        UpdateAvailableNextCities();
    }

    public bool PlanRoute() {
        if (traveler is null) 
            throw new InvalidOperationException(Error.EMPTY_TRAV_OR_DEST_ERROR);
        if (graph is null) 
            throw new InvalidOperationException(Error.MAP_ERROR);
        if (string.IsNullOrEmpty(destination))
            throw new InvalidOperationException(Error.DEST_ERROR);
        if (traveler.PlanRouteTo(destination, graph)) {
            OnPropertyChanged(nameof(Route));
            OnPropertyChanged(nameof(Distance));
            CityToRemove = Route.LastOrDefault() ?? "";
            OnPropertyChanged(nameof(CityToRemove));
            UpdateAvailableNextCities();
            return true;
        }
        return false;
    }

    public void AddCity() {
        if (traveler is null) 
            throw new InvalidOperationException(Error.EMPTY_TRAV_OR_DEST_ERROR);
        if (string.IsNullOrEmpty(cityToAdd))
            return;
        traveler.AddCity(cityToAdd);
        CityToRemove = cityToAdd;
        CityToAdd = "";
        OnPropertyChanged(nameof(Route));
        UpdateAvailableNextCities();
    }

    public void RemoveCity() {
        if (traveler is null) 
            throw new InvalidOperationException(Error.EMPTY_TRAV_OR_DEST_ERROR);
        if (string.IsNullOrEmpty(cityToRemove))
            return;
        if (graph is null) 
            throw new InvalidOperationException(Error.MAP_ERROR);

        var tuple = traveler.GetRouteNeighbors(cityToRemove);
        if (!tuple.HasValue) return;
        
        (string? from, string? to) = tuple.Value;
        traveler.RemoveCity(cityToRemove);
        if (from is not null && to is not null)
        {
            if (!graph.GetNeighbors(from).Contains(to))
            {
                traveler.DeleteRouteFrom(to);
            }
        }

        OnPropertyChanged(nameof(Route));
        CityToRemove = Route.LastOrDefault() ?? "";
        OnPropertyChanged(nameof(CityToRemove));
        UpdateAvailableNextCities();
    }

    public void ClearRoute() {
        if (traveler is null) 
            throw new InvalidOperationException(Error.EMPTY_TRAV_OR_DEST_ERROR);
        traveler.ClearRoute();
        OnPropertyChanged(nameof(Route));
        OnPropertyChanged(nameof(Distance));
        CityToRemove = "";
        OnPropertyChanged(nameof(CityToRemove));
        UpdateAvailableNextCities();
    }

    public List<string> AvailableNextCities
    {
        get { return availableNextCities; }
        set
        {
            availableNextCities = value;
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
