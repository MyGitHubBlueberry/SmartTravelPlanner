namespace SmartTravelPlanner
{
    partial class CreateTraveler
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
            SuspendLayout();
            // 
            // boxName
            // 
            boxName.Location = new Point(224, 48);
            boxName.Name = "boxName";
            boxName.Size = new Size(100, 23);
            boxName.TabIndex = 0;
            boxName.Text = "Alice";
            boxName.TextChanged += textBox1_TextChanged;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(114, 51);
            lblName.Name = "lblName";
            lblName.Size = new Size(42, 15);
            lblName.TabIndex = 1;
            lblName.Text = "Name:";
            lblName.Click += label1_Click;
            // 
            // lblStartingLocation
            // 
            lblStartingLocation.AutoSize = true;
            lblStartingLocation.Location = new Point(114, 81);
            lblStartingLocation.Name = "lblStartingLocation";
            lblStartingLocation.Size = new Size(97, 15);
            lblStartingLocation.TabIndex = 2;
            lblStartingLocation.Text = "Starting location:";
            lblStartingLocation.Click += label1_Click_1;
            // 
            // boxStartingLocation
            // 
            boxStartingLocation.Location = new Point(224, 78);
            boxStartingLocation.Name = "boxStartingLocation";
            boxStartingLocation.Size = new Size(100, 23);
            boxStartingLocation.TabIndex = 3;
            boxStartingLocation.Text = "Kiev";
            // 
            // btnCreateTraveler
            // 
            btnCreateTraveler.Location = new Point(163, 117);
            btnCreateTraveler.Name = "btnCreateTraveler";
            btnCreateTraveler.Size = new Size(108, 23);
            btnCreateTraveler.TabIndex = 4;
            btnCreateTraveler.Text = "Create Traveler";
            btnCreateTraveler.UseVisualStyleBackColor = true;
            // 
            // CreateTraveler
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(463, 238);
            Controls.Add(btnCreateTraveler);
            Controls.Add(boxStartingLocation);
            Controls.Add(lblStartingLocation);
            Controls.Add(lblName);
            Controls.Add(boxName);
            Name = "CreateTraveler";
            Text = "Create Traveler";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox boxName;
        private Label lblName;
        private Label lblStartingLocation;
        private TextBox boxStartingLocation;
        private Button btnCreateTraveler;
    }
}
