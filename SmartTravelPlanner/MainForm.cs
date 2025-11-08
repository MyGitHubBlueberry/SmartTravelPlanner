using System.Security;
using System.Windows.Forms;
using Travelling;
using System.IO;

namespace SmartTravelPlanner;

public partial class MainForm : Form
{
    private Traveler? traveler;
    private CityGraph? map;

    public MainForm()
    {
        InitializeComponent();
    }
    // ==============================================================
    // Empty event handlers for UI components that mustn't do anything
    // ==============================================================
    // Text Boxes changed
    private void boxName_TextChanged(object sender, EventArgs e) { }
    private void boxStartingLocation_TextChanged(object sender, EventArgs e) { }
    // Labels
    private void lblName_Click(object sender, EventArgs e) { }
    private void lblStartingLocation_Click(object sender, EventArgs e) { }
    private void lblDestination_Click(object sender, EventArgs e) { }
    private void lblDistText_Click(object sender, EventArgs e) { }
    private void lblDistNumber_Click(object sender, EventArgs e) { }
    // Group Boxes
    private void grbTravaler_Enter(object sender, EventArgs e) { }
    private void grbActions_Enter(object sender, EventArgs e) { }
    // ==============================================================
    // TODO

    private void btnCreateTraveler_Click(object sender, EventArgs e)
    {
        string travelerName = boxName.Text.Trim();
        string startLocation = boxStartingLocation.Text.Trim();

        if (string.IsNullOrWhiteSpace(travelerName) || string.IsNullOrWhiteSpace(startLocation))
        {
            MessageBox.Show("Please enter both a name and a starting location.", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        this.traveler = new Traveler(travelerName);
        this.traveler.SetLocation(startLocation);

        //todo: remove
        MessageBox.Show($"Traveler '{travelerName}' created and set to '{startLocation}'.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void UpdateUIFromTraveler()
    {
        if (this.traveler is null) return;

        boxName.Text = this.traveler.GetName();
        boxStartingLocation.Text = this.traveler.GetLocation();

        lsbRoute.Items.Clear();
        var routeList = new List<string>();

        if (this.traveler.GetStopCount() > 0)
        {
            for (int i = 0; i < this.traveler.GetStopCount(); i++)
            {
                string city = this.traveler[i];
                lsbRoute.Items.Add(city);
                routeList.Add(city);
            }
        }

        if (this.map != null && routeList.Count > 1)
        {
            int distance = this.map.GetPathDistance(routeList);
            lblDistNumber.Text = $"{distance} km";
        }
        else
        {
            lblDistNumber.Text = "0 km";
        }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        if (this.traveler is null)
        {
            MessageBox.Show("Please create a traveler first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        this.traveler.SetLocation(boxStartingLocation.Text);
        fdSaveTraveler.ShowDialog();
    }

    private void fdSaveTraveler_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
    {
        if (this.traveler is null) return;

        try
        {
            // Remove this comment: Auto json file extension, so if user won't add it
            if (Path.GetExtension(fdSaveTraveler.FileName).ToLowerInvariant() != ".json")
            {
                fdSaveTraveler.FileName = Path.ChangeExtension(fdSaveTraveler.FileName, ".json");
            }
            this.traveler.SaveToFile(fdSaveTraveler.FileName);
            MessageBox.Show("Traveler saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Could not save file: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnLoad_Click(object sender, EventArgs e) => fdLoadTraveler.ShowDialog();

    private void fdLoadTraveler_FileOk(object sender, EventArgs e)
    {
        try
        {
            this.traveler = Traveler.LoadFromFile(fdLoadTraveler.FileName);
            UpdateUIFromTraveler();
            MessageBox.Show("Traveler loaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Invalid .json file during loading", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }

    private void btnClear_Click(object sender, EventArgs e)
    {
        if (this.traveler is not null)
        {
            this.traveler.ClearRoute();
        }

        lsbRoute.Items.Clear();
        lblDistNumber.Text = "0";
    }

    private void btnExit_Click(object sender, EventArgs e)
    {
        this.Close();
    }
    private void btnPlan_Click(object sender, EventArgs e)
    {
        string desiination = boxDestination.Text.Trim();
        if (traveler is null)
        {
            MessageBox.Show("Please create a traveler first.", "Empty Traveler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        if (map is null)
        {
            MessageBox.Show("Please load a map first.", "Empty Map", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        if (string.IsNullOrEmpty(desiination))
        {
            MessageBox.Show("Please enter a destination.", "Empty Destination", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        if (!traveler.PlanRouteTo(desiination, map))
        {
            MessageBox.Show("Destination is not reachable or not in the map.", "Destination Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        //todo maybe do it through events
        lblDistNumber.Text = map.GetPathDistance(map.FindShortestPath(traveler.GetLocation(), boxDestination.Text)).ToString();
        lsbRoute.Items.Clear();
        lsbRoute.Items.AddRange(traveler.GetRoute().Split(" -> "));
    }

    private void lsbRoute_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void fdLoadMap_FileOk(object sender, EventArgs e)
    {
        //todo process file not ok in another event
        CityGraph cityGraph = new CityGraph();
        try
        {
            cityGraph = CityGraph.LoadFromFile(fdLoadMap.FileName);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred while loading the file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        map = cityGraph;
    }

    private void btnLoadMap_Click(object sender, EventArgs e) => fdLoadMap.ShowDialog();

    private void travelerBindingSource_CurrentChanged(object sender, EventArgs e)
    {

    }
}
