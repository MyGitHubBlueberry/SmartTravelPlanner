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
            string formattedValue = FormatAsTitleCase(value);
            if (location == formattedValue)
                return;
            location = formattedValue;
            traveler?.SetLocation(formattedValue);
            OnPropertyChanged();
        }
    }

    public string Destination
    {
        get { return destination; }
        set {
            string formattedValue = FormatAsTitleCase(value);
            if (destination == formattedValue)
                return;
            destination = formattedValue;
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
            string formattedValue = FormatAsTitleCase(value);
            if (cityToAdd == formattedValue)
                return;
            cityToAdd = formattedValue;
            OnPropertyChanged();
        }
    }

    public List<string> Route
    {
        get { return (traveler?.GetRoute() ?? "").Split(" -> ").ToList(); }
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
    }

    public void LoadMap(string filePath) {
        graph = CityGraph.LoadFromFile(filePath);
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
            return true;
        }
        return false;
    }

    public void AddCity() {
        if (traveler is null) 
            throw new InvalidOperationException("Traveler is not created. Create a traveler first.");
        if (string.IsNullOrEmpty(cityToAdd)) {
            throw new InvalidOperationException("Can't add an empty city.");
            return;
        }
        traveler.AddCity(cityToAdd);
        CityToAdd = "";
        OnPropertyChanged(nameof(Route));
    }

    public void RemoveCity() {
        if (traveler is null) 
            throw new InvalidOperationException("Traveler is not created. Create a traveler first.");
        if (string.IsNullOrEmpty(cityToRemove)) {
            throw new InvalidOperationException("Can't remove an empty city.");
        }
        traveler.RemoveCity(cityToRemove);
        OnPropertyChanged(nameof(Route));
    }

    public void ClearRoute() {
        if (traveler is null) 
            throw new InvalidOperationException("Traveler is not created. Create a traveler first.");
        traveler.ClearRoute();
        OnPropertyChanged(nameof(Route));
        OnPropertyChanged(nameof(Distance));
        OnPropertyChanged(nameof(Distance));
    }

    // Boilerplate code for INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private string FormatAsTitleCase(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
    }
}
