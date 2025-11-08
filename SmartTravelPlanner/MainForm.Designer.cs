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
            lblDistNumber = new Label();
            lblRoute = new Label();
            lblDistText = new Label();
            lsbRoute = new ListBox();
            fdSaveTraveler = new SaveFileDialog();
            fdLoadTraveler = new OpenFileDialog();
            lblRoute = new Label();
            lblDistText = new Label();
            lsbRoute = new ListBox();
            fdLoadMap = new OpenFileDialog();
            grbTravaler.SuspendLayout();
            grbActions.SuspendLayout();
            grbPlans.SuspendLayout();
            grbResults.SuspendLayout();
            SuspendLayout();
            // 
            // boxName
            // 
            boxName.Location = new Point(128, 26);
            boxName.Name = "boxName";
            boxName.Size = new Size(100, 23);
            boxName.TabIndex = 0;
            boxName.Text = "Alice";
            boxName.TextChanged += boxName_TextChanged;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(16, 26);
            lblName.Name = "lblName";
            lblName.Size = new Size(42, 15);
            lblName.TabIndex = 1;
            lblName.Text = "Name:";
            lblName.Click += lblName_Click;
            // 
            // lblStartingLocation
            // 
            lblStartingLocation.AutoSize = true;
            lblStartingLocation.Location = new Point(16, 60);
            lblStartingLocation.Name = "lblStartingLocation";
            lblStartingLocation.Size = new Size(97, 15);
            lblStartingLocation.TabIndex = 2;
            lblStartingLocation.Text = "Starting location:";
            lblStartingLocation.Click += lblStartingLocation_Click;
            // 
            // boxStartingLocation
            // 
            boxStartingLocation.Location = new Point(128, 58);
            boxStartingLocation.Name = "boxStartingLocation";
            boxStartingLocation.Size = new Size(100, 23);
            boxStartingLocation.TabIndex = 3;
            boxStartingLocation.Text = "Kyiv";
            boxStartingLocation.TextChanged += boxStartingLocation_TextChanged;
            // 
            // btnCreateTraveler
            // 
            btnCreateTraveler.Location = new Point(64, 112);
            btnCreateTraveler.Name = "btnCreateTraveler";
            btnCreateTraveler.Size = new Size(108, 23);
            btnCreateTraveler.TabIndex = 4;
            btnCreateTraveler.Text = "Create Traveler";
            btnCreateTraveler.UseVisualStyleBackColor = true;
            btnCreateTraveler.Click += btnCreateTraveler_Click;
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
            grbTravaler.TabIndex = 5;
            grbTravaler.TabStop = false;
            grbTravaler.Text = "Basic info";
            grbTravaler.Enter += grbTravaler_Enter;
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
            grbActions.TabIndex = 6;
            grbActions.TabStop = false;
            grbActions.Text = "Actions";
            grbActions.Enter += grbActions_Enter;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(11, 59);
            btnLoad.Margin = new Padding(3, 2, 3, 2);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(82, 22);
            btnLoad.TabIndex = 6;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(11, 92);
            btnClear.Margin = new Padding(3, 2, 3, 2);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(82, 22);
            btnClear.TabIndex = 5;
            btnClear.Text = "Clear Route";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
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
            btnExit.Click += btnExit_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(11, 26);
            btnSave.Margin = new Padding(3, 2, 3, 2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(82, 22);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
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
            grbPlans.TabIndex = 7;
            grbPlans.TabStop = false;
            grbPlans.Text = "Map and Route planning";
            // 
            // btnPlan
            // 
            btnPlan.Location = new Point(131, 105);
            btnPlan.Margin = new Padding(3, 2, 3, 2);
            btnPlan.Name = "btnPlan";
            btnPlan.Size = new Size(133, 23);
            btnPlan.TabIndex = 7;
            btnPlan.Text = "Plan Route";
            btnPlan.UseVisualStyleBackColor = true;
            btnPlan.Click += btnPlan_Click;
            // 
            // btnLoadMap
            // 
            btnLoadMap.Location = new Point(131, 26);
            btnLoadMap.Margin = new Padding(3, 2, 3, 2);
            btnLoadMap.Name = "btnLoadMap";
            btnLoadMap.Size = new Size(133, 22);
            btnLoadMap.TabIndex = 6;
            btnLoadMap.Text = "Load Map";
            btnLoadMap.UseVisualStyleBackColor = true;
            btnLoadMap.Click += btnLoadMap_Click;
            // 
            // lblDestination
            // 
            lblDestination.AutoSize = true;
            lblDestination.Location = new Point(20, 68);
            lblDestination.Name = "lblDestination";
            lblDestination.Size = new Size(70, 15);
            lblDestination.TabIndex = 4;
            lblDestination.Text = "Destination:";
            lblDestination.Click += lblDestination_Click;
            // 
            // boxDestination
            // 
            boxDestination.Location = new Point(131, 65);
            boxDestination.Name = "boxDestination";
            boxDestination.Size = new Size(134, 23);
            boxDestination.TabIndex = 5;
            boxDestination.Text = "Kyiv";
            // 
            // grbResults
            // 
            grbResults.Controls.Add(lblDistNumber);
            grbResults.Controls.Add(lblRoute);
            grbResults.Controls.Add(lblDistText);
            grbResults.Controls.Add(lsbRoute);
            grbResults.Location = new Point(20, 177);
            grbResults.Margin = new Padding(3, 2, 3, 2);
            grbResults.Name = "grbResults";
            grbResults.Padding = new Padding(3, 2, 3, 2);
            grbResults.Size = new Size(642, 161);
            grbResults.TabIndex = 8;
            grbResults.TabStop = false;
            grbResults.Text = "Route Details";
            // 
            // lblDistNumber
            // 
            lblDistNumber.AutoSize = true;
            lblDistNumber.Location = new Point(108, 24);
            lblDistNumber.Name = "lblDistNumber";
            lblDistNumber.Size = new Size(13, 15);
            lblDistNumber.TabIndex = 11;
            lblDistNumber.Text = "0";
            lblDistNumber.Click += lblDistNumber_Click;
            // 
            // lblRoute
            // 
            lblRoute.AutoSize = true;
            lblRoute.Location = new Point(16, 46);
            lblRoute.Name = "lblRoute";
            lblRoute.Size = new Size(41, 15);
            lblRoute.TabIndex = 10;
            lblRoute.Text = "Route:";
            // 
            // lblDistText
            // 
            lblDistText.AutoSize = true;
            lblDistText.Location = new Point(16, 24);
            lblDistText.Name = "lblDistText";
            lblDistText.Size = new Size(83, 15);
            lblDistText.TabIndex = 9;
            lblDistText.Text = "Total distance:";
            lblDistText.Click += this.lblDistText_Click;
            // 
            // lsbRoute
            // fdSaveTraveler
            // 
            lsbRoute.FormattingEnabled = true;
            lsbRoute.ItemHeight = 15;
            lsbRoute.Location = new Point(16, 70);
            lsbRoute.Margin = new Padding(3, 2, 3, 2);
            lsbRoute.Name = "lsbRoute";
            lsbRoute.SelectionMode = SelectionMode.MultiSimple;
            lsbRoute.Size = new Size(605, 79);
            lsbRoute.TabIndex = 8;
            lsbRoute.SelectedIndexChanged += lsbRoute_SelectedIndexChanged;
            fdSaveTraveler.Title = "Save Traveler";
            fdSaveTraveler.FileOk += fdSaveTraveler_FileOk;
            // 
            // fdLoadTraveler
            // fdLoadMap
            // 
            fdLoadTraveler.FileName = "openFileDialog1";
            fdLoadTraveler.Title = "Load Traveler";
            fdLoadTraveler.FileOk += fdLoadTraveler_FileOk;
            fdLoadMap.FileName = "map";
            fdLoadMap.Title = "LoadMap";
            fdLoadMap.FileOk += fdLoadMap_FileOk;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(686, 358);
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
    }
}
