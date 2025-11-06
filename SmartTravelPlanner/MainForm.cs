using Travelling;

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
        string travelerName = boxName.Text;
        string startLocation = boxStartingLocation.Text;

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

    private void btnSave_Click(object sender, EventArgs e)
    {

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
    private void btnLoad_Click(object sender, EventArgs e) { }

    private void btnPlan_Click(object sender, EventArgs e)
    {
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
        if (string.IsNullOrEmpty(boxDestination.Text))
        {
            MessageBox.Show("Please enter a destination.", "Empty Destination", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        if (!traveler.PlanRouteTo(boxDestination.Text, map))
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
}
