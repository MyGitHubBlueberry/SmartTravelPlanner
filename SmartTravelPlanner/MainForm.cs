using System.IO;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using Travelling;

namespace SmartTravelPlanner;

public partial class MainForm : Form
{
    private readonly TravelerViewModel viewModel;

    public MainForm()
    {
        InitializeComponent();
        viewModel = new TravelerViewModel();
        BindFileds();
        BindButtons();
    }

    private void BindFileds()
    {
        boxName.DataBindings.Add("Text", viewModel,
            nameof(viewModel.NewName), false, DataSourceUpdateMode.OnPropertyChanged);
        boxStartingLocation.DataBindings.Add("Text", viewModel,
            nameof(viewModel.CurrentLocation), false, DataSourceUpdateMode.OnPropertyChanged);
        boxDestination.DataBindings.Add("Text", viewModel,
            nameof(viewModel.Destination), false, DataSourceUpdateMode.OnPropertyChanged);
        boxAddCity.DataBindings.Add("Text", viewModel,
            nameof(viewModel.CityToAdd), false, DataSourceUpdateMode.OnPropertyChanged);

        lsbRoute.DataBindings.Add("DataSource", viewModel,
            nameof(TravelerViewModel.Route));

        cmbCityToRemove.DataBindings.Add("DataSource", viewModel,
            nameof(TravelerViewModel.Route));
        cmbCityToRemove.DataBindings.Add("SelectedItem", viewModel,
            nameof(TravelerViewModel.CityToRemove), true, DataSourceUpdateMode.OnPropertyChanged);

        lblRoute.DataBindings.Add("Text", viewModel,
            nameof(viewModel.JoiedRoute));
        lblDistNumber.DataBindings.Add("Text", viewModel,
            nameof(viewModel.Distance));
    }

    private void BindButtons()
    {
        btnCreateTraveler.Click += (s, e) => CreateTraveler();
        btnLoadMap.Click += (s, e) =>
        {
            if (!viewModel.IsTravelerCreated)
            {
                MessageBox.Show("Please create a traveler first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            fdLoadMap.ShowDialog();
        };
        fdLoadMap.FileOk += (s, e) => LoadMap();
        btnPlan.Click += (s, e) => PlanRoute();
        btnSave.Click += (s, e) =>
        {
            if (!viewModel.IsTravelerCreated)
            {
                MessageBox.Show("Please create a traveler first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            fdSaveTraveler.ShowDialog();
        };
        fdSaveTraveler.FileOk += (s, e) => Save();
        btnLoad.Click += (s, e) => fdLoadTraveler.ShowDialog();
        fdLoadTraveler.FileOk += (s, e) => LoadTraveler();
        btnAddCity.Click += (s, e) => AddCity();
        btnRemoveCity.Click += (s, e) => RemoveCity();
        btnClear.Click += (s, e) => ClearRoute();
        btnExit.Click += (s, e) => Close();
    }

    private void CreateTraveler()
    {
        try
        {
            viewModel.CreateTraveler();
            MessageBox.Show($"Traveler '{viewModel.NewName}' created and set to '{viewModel.CurrentLocation}'.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (InvalidOperationException)
        {
            MessageBox.Show("Please enter both a name and a starting location.", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadMap()
    {
        try
        {
            viewModel.LoadMap(fdLoadMap.FileName);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred while loading the file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
    }

    private void PlanRoute()
    {
        try
        {
            if (!viewModel.PlanRoute())
            {
                MessageBox.Show("Destination is not reachable or not in the map.", "Destination Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (InvalidOperationException)
        {
            MessageBox.Show("Please ensure that a traveler is created, a map is loaded, and a destination is entered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void Save()
    {
        try
        {
            if (Path.GetExtension(fdSaveTraveler.FileName).ToLowerInvariant() != ".json")
            {
                fdSaveTraveler.FileName = Path.ChangeExtension(fdSaveTraveler.FileName, ".json");
            }
            viewModel.Save(fdSaveTraveler.FileName);
            MessageBox.Show("Traveler saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Could not save file: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadTraveler()
    {
        try
        {
            viewModel.Load(fdLoadTraveler.FileName);
            MessageBox.Show("Traveler loaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Invalid .json file during loading", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void AddCity()
    {
        try
        {
            viewModel.AddCity();
        }
        catch (InvalidOperationException ex)
        {
            MessageBox.Show(ex.Message, "Can't add city", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
    }

    private void RemoveCity()
    {
        try
        {
            viewModel.RemoveCity();
        }
        catch (InvalidOperationException ex)
        {
            MessageBox.Show(ex.Message, "Can't remove city", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
    }

    private void ClearRoute()
    {
        try
        {
            viewModel.ClearRoute();
        }
        catch (InvalidOperationException ex)
        {
            MessageBox.Show(ex.Message, "Can't clear route", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
    }
}
