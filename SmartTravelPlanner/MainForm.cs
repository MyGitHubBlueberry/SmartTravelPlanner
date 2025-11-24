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
        DataSourceUpdateMode updateMode = DataSourceUpdateMode.OnValidation;
        ConvertEventHandler formatting = new ConvertEventHandler(TitleCase);

        boxName.DataBindings.Add("Text", viewModel,
            nameof(viewModel.NewName), false, updateMode);

        var boxStartingLocationBinding = new Binding("Text", viewModel,
            nameof(viewModel.CurrentLocation), false, updateMode);
        boxStartingLocation.DataBindings.Add(boxStartingLocationBinding);
        boxStartingLocationBinding.Parse += formatting;

        var boxDestinationBinding = new Binding("Text", viewModel,
            nameof(viewModel.Destination), false, updateMode);
        boxDestination.DataBindings.Add(boxDestinationBinding);
        boxDestinationBinding.Parse += formatting;

        cmbAddCity.DataBindings.Add("DataSource", viewModel,
            nameof(viewModel.AvailableNextCities));
        cmbAddCity.DataBindings.Add("SelectedItem", viewModel,
            nameof(viewModel.CityToAdd), true, DataSourceUpdateMode.OnPropertyChanged);

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

    private void TitleCase(object sender, ConvertEventArgs args)
    {
        if (args.DesiredType != typeof(string) || args.Value == null)
            return;
        string? input = args.Value.ToString();
        if (String.IsNullOrEmpty(input) || String.IsNullOrWhiteSpace(input))
            return;
        args.Value = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input);
    }

    private void BindButtons()
    {
        btnCreateTraveler.Click += (s, e) => CreateTraveler();
        btnLoadMap.Click += (s, e) =>
        {
            if (!viewModel.IsTravelerCreated)
            {
                MessageBox.Show(Error.EMPTY_TRAV_OR_DEST_ERROR, Error.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show(Error.EMPTY_TRAV_OR_DEST_ERROR, Error.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        Error.HandleError(viewModel.CreateTraveler);
    }

    private void LoadMap()
    {
        Error.HandleError(() => viewModel.LoadMap(fdLoadMap.FileName));
    }

    private void PlanRoute()
    {
        Error.HandleError(() => {
            if (!viewModel.PlanRoute())
            { 
                MessageBox.Show(Error.DEST_ERROR, Error.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        });
    }

    private void Save()
    {
        Error.HandleError(() =>
        {
            if (Path.GetExtension(fdSaveTraveler.FileName).ToLowerInvariant() != ".json")
            {
                fdSaveTraveler.FileName = Path.ChangeExtension(fdSaveTraveler.FileName, ".json");
            }
            viewModel.Save(fdSaveTraveler.FileName);
            //MessageBox.Show("Traveler saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        });
    }

    private void LoadTraveler()
    {
        Error.HandleError(() => viewModel.Load(fdLoadTraveler.FileName));
            //MessageBox.Show("Traveler loaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void AddCity()
    {
        Error.HandleError(viewModel.AddCity);

    }

    private void RemoveCity()
    {
        Error.HandleError(() => {
            viewModel.RemoveCity();
            if (string.IsNullOrEmpty(viewModel.CityToRemove))
            {
                cmbCityToRemove.Text = "";
            }
        });
    }

    private void ClearRoute()
    {
        Error.HandleError(() => {
            viewModel.ClearRoute();
            cmbCityToRemove.Text = "";
        });
    }
}
