 using System.Xml.Linq;

namespace SmartTravelPlanner
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            boxName = new TextBox();
            lblName = new Label();
            lblStartingLocation = new Label();
            boxStartingLocation = new TextBox();
            btnCreateTraveler = new Button();
            grbTravaler = new GroupBox();
            grbActions = new GroupBox();
            btnLoad = new Button();
            btnClear = new Button();
            btnExit = new Button();
            btnSave = new Button();
            grbPlans = new GroupBox();
            btnPlan = new Button();
            btnLoadMap = new Button();
            lblDestination = new Label();
            boxDestination = new TextBox();
            grbResults = new GroupBox();
            boxAddCity = new TextBox();
            cmbCityToRemove = new ComboBox();
            btnRemoveCity = new Button();
            btnAddCity = new Button();
            lblDistNumber = new Label();
            lblRoute = new Label();
            lblDistText = new Label();
            lsbRoute = new ListBox();
            fdSaveTraveler = new SaveFileDialog();
            fdLoadTraveler = new OpenFileDialog();
            fdLoadMap = new OpenFileDialog();
            travelerViewModelBindingSource = new BindingSource(components);
            grbTravaler.SuspendLayout();
            grbActions.SuspendLayout();
            grbPlans.SuspendLayout();
            grbResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)travelerViewModelBindingSource).BeginInit();
            SuspendLayout();
            // 
            // boxName
            // 
            boxName.Location = new Point(128, 26);
            boxName.Name = "boxName";
            boxName.Size = new Size(100, 23);
            boxName.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(16, 26);
            lblName.Name = "lblName";
            lblName.Size = new Size(42, 15);
            lblName.TabIndex = 0;
            lblName.Text = "Name:";
            // 
            // lblStartingLocation
            // 
            lblStartingLocation.AutoSize = true;
            lblStartingLocation.Location = new Point(16, 60);
            lblStartingLocation.Name = "lblStartingLocation";
            lblStartingLocation.Size = new Size(97, 15);
            lblStartingLocation.TabIndex = 3;
            lblStartingLocation.Text = "Starting location:";
            // 
            // boxStartingLocation
            // 
            boxStartingLocation.Location = new Point(128, 58);
            boxStartingLocation.Name = "boxStartingLocation";
            boxStartingLocation.Size = new Size(100, 23);
            boxStartingLocation.TabIndex = 2;
            // 
            // btnCreateTraveler
            // 
            btnCreateTraveler.Location = new Point(64, 112);
            btnCreateTraveler.Name = "btnCreateTraveler";
            btnCreateTraveler.Size = new Size(108, 23);
            btnCreateTraveler.TabIndex = 3;
            btnCreateTraveler.Text = "Create Traveler";
            btnCreateTraveler.UseVisualStyleBackColor = true;
            // 
            // grbTravaler
            // 
            grbTravaler.Controls.Add(lblName);
            grbTravaler.Controls.Add(boxName);
            grbTravaler.Controls.Add(btnCreateTraveler);
            grbTravaler.Controls.Add(lblStartingLocation);
            grbTravaler.Controls.Add(boxStartingLocation);
            grbTravaler.Location = new Point(20, 17);
            grbTravaler.Margin = new Padding(3, 2, 3, 2);
            grbTravaler.Name = "grbTravaler";
            grbTravaler.Padding = new Padding(3, 2, 3, 2);
            grbTravaler.Size = new Size(249, 155);
            grbTravaler.TabIndex = 1;
            grbTravaler.TabStop = false;
            grbTravaler.Text = "Basic info";
            // 
            // grbActions
            // 
            grbActions.Controls.Add(btnLoad);
            grbActions.Controls.Add(btnClear);
            grbActions.Controls.Add(btnExit);
            grbActions.Controls.Add(btnSave);
            grbActions.Location = new Point(560, 17);
            grbActions.Margin = new Padding(3, 2, 3, 2);
            grbActions.Name = "grbActions";
            grbActions.Padding = new Padding(3, 2, 3, 2);
            grbActions.Size = new Size(102, 155);
            grbActions.TabIndex = 3;
            grbActions.TabStop = false;
            grbActions.Text = "Actions";
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(11, 59);
            btnLoad.Margin = new Padding(3, 2, 3, 2);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(82, 22);
            btnLoad.TabIndex = 2;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(11, 92);
            btnClear.Margin = new Padding(3, 2, 3, 2);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(82, 22);
            btnClear.TabIndex = 3;
            btnClear.Text = "Clear Route";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(11, 127);
            btnExit.Margin = new Padding(3, 2, 3, 2);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(82, 22);
            btnExit.TabIndex = 4;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(11, 26);
            btnSave.Margin = new Padding(3, 2, 3, 2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(82, 22);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // grbPlans
            // 
            grbPlans.Controls.Add(btnPlan);
            grbPlans.Controls.Add(btnLoadMap);
            grbPlans.Controls.Add(lblDestination);
            grbPlans.Controls.Add(boxDestination);
            grbPlans.Location = new Point(275, 17);
            grbPlans.Margin = new Padding(3, 2, 3, 2);
            grbPlans.Name = "grbPlans";
            grbPlans.Padding = new Padding(3, 2, 3, 2);
            grbPlans.Size = new Size(280, 156);
            grbPlans.TabIndex = 2;
            grbPlans.TabStop = false;
            grbPlans.Text = "Map and Route planning";
            // 
            // btnPlan
            // 
            btnPlan.Location = new Point(131, 105);
            btnPlan.Margin = new Padding(3, 2, 3, 2);
            btnPlan.Name = "btnPlan";
            btnPlan.Size = new Size(133, 23);
            btnPlan.TabIndex = 3;
            btnPlan.Text = "Plan Route";
            btnPlan.UseVisualStyleBackColor = true;
            // 
            // btnLoadMap
            // 
            btnLoadMap.Location = new Point(131, 26);
            btnLoadMap.Margin = new Padding(3, 2, 3, 2);
            btnLoadMap.Name = "btnLoadMap";
            btnLoadMap.Size = new Size(133, 22);
            btnLoadMap.TabIndex = 1;
            btnLoadMap.Text = "Load Map";
            btnLoadMap.UseVisualStyleBackColor = true;
            // 
            // lblDestination
            // 
            lblDestination.AutoSize = true;
            lblDestination.Location = new Point(20, 68);
            lblDestination.Name = "lblDestination";
            lblDestination.Size = new Size(70, 15);
            lblDestination.TabIndex = 6;
            lblDestination.Text = "Destination:";
            // 
            // boxDestination
            // 
            boxDestination.Location = new Point(131, 65);
            boxDestination.Name = "boxDestination";
            boxDestination.Size = new Size(134, 23);
            boxDestination.TabIndex = 2;
            // 
            // grbResults
            // 
            grbResults.Controls.Add(boxAddCity);
            grbResults.Controls.Add(cmbCityToRemove);
            grbResults.Controls.Add(btnRemoveCity);
            grbResults.Controls.Add(btnAddCity);
            grbResults.Controls.Add(lblDistNumber);
            grbResults.Controls.Add(lblRoute);
            grbResults.Controls.Add(lblDistText);
            grbResults.Controls.Add(lsbRoute);
            grbResults.Location = new Point(20, 177);
            grbResults.Margin = new Padding(3, 2, 3, 2);
            grbResults.Name = "grbResults";
            grbResults.Padding = new Padding(3, 2, 3, 2);
            grbResults.Size = new Size(642, 198);
            grbResults.TabIndex = 4;
            grbResults.TabStop = false;
            grbResults.Text = "Route Details";
            // 
            // boxAddCity
            // 
            boxAddCity.Location = new Point(97, 162);
            boxAddCity.Name = "boxAddCity";
            boxAddCity.Size = new Size(210, 23);
            boxAddCity.TabIndex = 1;
            // 
            // cmbCityToRemove
            // 
            cmbCityToRemove.FormattingEnabled = true;
            cmbCityToRemove.Location = new Point(414, 161);
            cmbCityToRemove.Name = "cmbCityToRemove";
            cmbCityToRemove.Size = new Size(207, 23);
            cmbCityToRemove.TabIndex = 3;
            // 
            // btnRemoveCity
            // 
            btnRemoveCity.Location = new Point(324, 161);
            btnRemoveCity.Name = "btnRemoveCity";
            btnRemoveCity.Size = new Size(75, 23);
            btnRemoveCity.TabIndex = 4;
            btnRemoveCity.Text = "Remove City";
            btnRemoveCity.UseVisualStyleBackColor = true;
            // 
            // btnAddCity
            // 
            btnAddCity.Location = new Point(16, 161);
            btnAddCity.Name = "btnAddCity";
            btnAddCity.Size = new Size(75, 23);
            btnAddCity.TabIndex = 2;
            btnAddCity.Text = "Add City";
            btnAddCity.UseVisualStyleBackColor = true;
            // 
            // lblDistNumber
            // 
            lblDistNumber.AutoSize = true;
            lblDistNumber.Location = new Point(108, 24);
            lblDistNumber.Name = "lblDistNumber";
            lblDistNumber.Size = new Size(13, 15);
            lblDistNumber.TabIndex = 14;
            lblDistNumber.Text = "0";
            // 
            // lblRoute
            // 
            lblRoute.AutoSize = true;
            lblRoute.Location = new Point(16, 46);
            lblRoute.Name = "lblRoute";
            lblRoute.Size = new Size(41, 15);
            lblRoute.TabIndex = 15;
            lblRoute.Text = "Route:";
            // 
            // lblDistText
            // 
            lblDistText.AutoSize = true;
            lblDistText.Location = new Point(16, 24);
            lblDistText.Name = "lblDistText";
            lblDistText.Size = new Size(82, 15);
            lblDistText.TabIndex = 16;
            lblDistText.Text = "Total distance:";
            // 
            // lsbRoute
            // 
            lsbRoute.FormattingEnabled = true;
            lsbRoute.ItemHeight = 15;
            lsbRoute.Location = new Point(16, 70);
            lsbRoute.Margin = new Padding(3, 2, 3, 2);
            lsbRoute.Name = "lsbRoute";
            lsbRoute.SelectionMode = SelectionMode.MultiSimple;
            lsbRoute.Size = new Size(605, 79);
            lsbRoute.TabIndex = 17;
            // 
            // fdSaveTraveler
            // 
            fdSaveTraveler.Title = "Save Traveler";
            // 
            // fdLoadTraveler
            // 
            fdLoadTraveler.FileName = "openFileDialog1";
            fdLoadTraveler.Title = "Load Traveler";
            // 
            // fdLoadMap
            // 
            fdLoadMap.FileName = "map";
            fdLoadMap.Title = "LoadMap";
            // 
            // travelerViewModelBindingSource
            // 
            travelerViewModelBindingSource.DataSource = typeof(TravelerViewModel);
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(679, 386);
            Controls.Add(grbResults);
            Controls.Add(grbPlans);
            Controls.Add(grbActions);
            Controls.Add(grbTravaler);
            Name = "MainForm";
            Text = "Create Traveler";
            grbTravaler.ResumeLayout(false);
            grbTravaler.PerformLayout();
            grbActions.ResumeLayout(false);
            grbPlans.ResumeLayout(false);
            grbPlans.PerformLayout();
            grbResults.ResumeLayout(false);
            grbResults.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)travelerViewModelBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox boxName;
        private Label lblName;
        private Label lblStartingLocation;
        private TextBox boxStartingLocation;
        private Button btnCreateTraveler;
        private GroupBox grbTravaler;
        private GroupBox grbActions;
        private Button btnClear;
        private Button btnExit;
        private Button btnSave;
        private Button btnLoad;
        private GroupBox grbPlans;
        private Label lblDestination;
        private TextBox boxDestination;
        private GroupBox grbResults;
        private Button btnPlan;
        private Button btnLoadMap;
        private ListBox lsbRoute;
        private Label lblRoute;
        private Label lblDistText;
        private Label lblDistNumber;
        private SaveFileDialog fdSaveTraveler;
        private OpenFileDialog fdLoadTraveler;
        private OpenFileDialog fdLoadMap;
        private ComboBox cmbCityToRemove;
        private Button btnRemoveCity;
        private Button btnAddCity;
        private TextBox boxAddCity;
        private BindingSource travelerViewModelBindingSource;
    }
}
