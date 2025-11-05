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
            btnClear = new Button();
            btnExit = new Button();
            btnSave = new Button();
            btnLoad = new Button();
            grbPlans = new GroupBox();
            grbResults = new GroupBox();
            lblDestination = new Label();
            boxDestination = new TextBox();
            btnLoadMap = new Button();
            btnPlan = new Button();
            lsbRoute = new ListBox();
            lblDistText = new Label();
            lblRoute = new Label();
            lblDistNumber = new Label();
            grbTravaler.SuspendLayout();
            grbActions.SuspendLayout();
            grbPlans.SuspendLayout();
            grbResults.SuspendLayout();
            SuspendLayout();
            // 
            // boxName
            // 
            boxName.Location = new Point(146, 35);
            boxName.Margin = new Padding(3, 4, 3, 4);
            boxName.Name = "boxName";
            boxName.Size = new Size(114, 27);
            boxName.TabIndex = 0;
            boxName.Text = "Alice";
            boxName.TextChanged += textBox1_TextChanged;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(18, 35);
            lblName.Name = "lblName";
            lblName.Size = new Size(52, 20);
            lblName.TabIndex = 1;
            lblName.Text = "Name:";
            lblName.Click += label1_Click;
            // 
            // lblStartingLocation
            // 
            lblStartingLocation.AutoSize = true;
            lblStartingLocation.Location = new Point(18, 80);
            lblStartingLocation.Name = "lblStartingLocation";
            lblStartingLocation.Size = new Size(122, 20);
            lblStartingLocation.TabIndex = 2;
            lblStartingLocation.Text = "Starting location:";
            lblStartingLocation.Click += label1_Click_1;
            // 
            // boxStartingLocation
            // 
            boxStartingLocation.Location = new Point(146, 77);
            boxStartingLocation.Margin = new Padding(3, 4, 3, 4);
            boxStartingLocation.Name = "boxStartingLocation";
            boxStartingLocation.Size = new Size(114, 27);
            boxStartingLocation.TabIndex = 3;
            boxStartingLocation.Text = "Kyiv";
            boxStartingLocation.TextChanged += this.boxStartingLocation_TextChanged;
            // 
            // btnCreateTraveler
            // 
            btnCreateTraveler.Location = new Point(73, 150);
            btnCreateTraveler.Margin = new Padding(3, 4, 3, 4);
            btnCreateTraveler.Name = "btnCreateTraveler";
            btnCreateTraveler.Size = new Size(123, 31);
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
            grbTravaler.Location = new Point(23, 23);
            grbTravaler.Name = "grbTravaler";
            grbTravaler.Size = new Size(285, 207);
            grbTravaler.TabIndex = 5;
            grbTravaler.TabStop = false;
            grbTravaler.Text = "Basic info";
            grbTravaler.Enter += this.groupBox1_Enter;
            // 
            // grbActions
            // 
            grbActions.Controls.Add(btnLoad);
            grbActions.Controls.Add(btnClear);
            grbActions.Controls.Add(btnExit);
            grbActions.Controls.Add(btnSave);
            grbActions.Location = new Point(640, 23);
            grbActions.Name = "grbActions";
            grbActions.Size = new Size(117, 207);
            grbActions.TabIndex = 6;
            grbActions.TabStop = false;
            grbActions.Text = "Actions";
            grbActions.Enter += this.groupBox2_Enter;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(13, 123);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 5;
            btnClear.Text = "Clear Route";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += this.btnClear_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(13, 169);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(94, 29);
            btnExit.TabIndex = 4;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += this.btnExit_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(13, 35);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(13, 79);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(94, 29);
            btnLoad.TabIndex = 6;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += this.button1_Click;
            // 
            // grbPlans
            // 
            grbPlans.Controls.Add(btnPlan);
            grbPlans.Controls.Add(btnLoadMap);
            grbPlans.Controls.Add(lblDestination);
            grbPlans.Controls.Add(boxDestination);
            grbPlans.Location = new Point(314, 33);
            grbPlans.Name = "grbPlans";
            grbPlans.Size = new Size(320, 197);
            grbPlans.TabIndex = 7;
            grbPlans.TabStop = false;
            grbPlans.Text = "Map and Route planning";
            // 
            // grbResults
            // 
            grbResults.Controls.Add(lblDistNumber);
            grbResults.Controls.Add(lblRoute);
            grbResults.Controls.Add(lblDistText);
            grbResults.Controls.Add(lsbRoute);
            grbResults.Location = new Point(23, 236);
            grbResults.Name = "grbResults";
            grbResults.Size = new Size(734, 215);
            grbResults.TabIndex = 8;
            grbResults.TabStop = false;
            grbResults.Text = "Route Details";
            // 
            // lblDestination
            // 
            lblDestination.AutoSize = true;
            lblDestination.Location = new Point(23, 90);
            lblDestination.Name = "lblDestination";
            lblDestination.Size = new Size(88, 20);
            lblDestination.TabIndex = 4;
            lblDestination.Text = "Destination:";
            lblDestination.Click += this.label1_Click_2;
            // 
            // boxDestination
            // 
            boxDestination.Location = new Point(150, 87);
            boxDestination.Margin = new Padding(3, 4, 3, 4);
            boxDestination.Name = "boxDestination";
            boxDestination.Size = new Size(152, 27);
            boxDestination.TabIndex = 5;
            boxDestination.Text = "Kyiv";
            // 
            // btnLoadMap
            // 
            btnLoadMap.Location = new Point(150, 34);
            btnLoadMap.Name = "btnLoadMap";
            btnLoadMap.Size = new Size(152, 29);
            btnLoadMap.TabIndex = 6;
            btnLoadMap.Text = "Load Map";
            btnLoadMap.UseVisualStyleBackColor = true;
            // 
            // btnPlan
            // 
            btnPlan.Location = new Point(150, 140);
            btnPlan.Name = "btnPlan";
            btnPlan.Size = new Size(152, 31);
            btnPlan.TabIndex = 7;
            btnPlan.Text = "Plan Route";
            btnPlan.UseVisualStyleBackColor = true;
            // 
            // lsbRoute
            // 
            lsbRoute.FormattingEnabled = true;
            lsbRoute.Location = new Point(18, 94);
            lsbRoute.Name = "lsbRoute";
            lsbRoute.SelectionMode = SelectionMode.MultiSimple;
            lsbRoute.Size = new Size(691, 104);
            lsbRoute.TabIndex = 8;
            // 
            // lblDistText
            // 
            lblDistText.AutoSize = true;
            lblDistText.Location = new Point(18, 32);
            lblDistText.Name = "lblDistText";
            lblDistText.Size = new Size(104, 20);
            lblDistText.TabIndex = 9;
            lblDistText.Text = "Total distance:";
            lblDistText.Click += this.label1_Click_3;
            // 
            // lblRoute
            // 
            lblRoute.AutoSize = true;
            lblRoute.Location = new Point(18, 62);
            lblRoute.Name = "lblRoute";
            lblRoute.Size = new Size(51, 20);
            lblRoute.TabIndex = 10;
            lblRoute.Text = "Route:";
            // 
            // lblDistNumber
            // 
            lblDistNumber.AutoSize = true;
            lblDistNumber.Location = new Point(123, 32);
            lblDistNumber.Name = "lblDistNumber";
            lblDistNumber.Size = new Size(17, 20);
            lblDistNumber.TabIndex = 11;
            lblDistNumber.Text = "0";
            lblDistNumber.Click += this.label1_Click_4;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 477);
            Controls.Add(grbResults);
            Controls.Add(grbPlans);
            Controls.Add(grbActions);
            Controls.Add(grbTravaler);
            Margin = new Padding(3, 4, 3, 4);
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
    }
}
