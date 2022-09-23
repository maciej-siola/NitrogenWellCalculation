namespace GlowicaCisnieniowaAzot
{
    partial class BaseForm
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
            this.Copyright = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TopTemperature = new System.Windows.Forms.TextBox();
            this.TopPressure = new System.Windows.Forms.TextBox();
            this.TopDepth = new System.Windows.Forms.TextBox();
            this.MiddleDepth = new System.Windows.Forms.TextBox();
            this.MiddlePressure = new System.Windows.Forms.TextBox();
            this.BottomDepth = new System.Windows.Forms.TextBox();
            this.BottomPressure = new System.Windows.Forms.TextBox();
            this.BottomTemperature = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.BottomDensity = new System.Windows.Forms.TextBox();
            this.MiddleDensity = new System.Windows.Forms.TextBox();
            this.TopDensity = new System.Windows.Forms.TextBox();
            this.ActualTemperature = new System.Windows.Forms.TextBox();
            this.ActualDepth = new System.Windows.Forms.TextBox();
            this.ActualPressure = new System.Windows.Forms.TextBox();
            this.ActualDensity = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Copyright
            // 
            this.Copyright.AutoSize = true;
            this.Copyright.Location = new System.Drawing.Point(393, 532);
            this.Copyright.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Copyright.Name = "Copyright";
            this.Copyright.Size = new System.Drawing.Size(168, 15);
            this.Copyright.TabIndex = 0;
            this.Copyright.Text = "Projekt autorstwa: Maciej Sioła";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(55, 27);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Temperatura [°C]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(276, 27);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Głębokość [m]";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(519, 27);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "Ciśnienie [MPa]";
            // 
            // TopTemperature
            // 
            this.TopTemperature.Location = new System.Drawing.Point(64, 55);
            this.TopTemperature.Margin = new System.Windows.Forms.Padding(2);
            this.TopTemperature.Name = "TopTemperature";
            this.TopTemperature.Size = new System.Drawing.Size(106, 23);
            this.TopTemperature.TabIndex = 13;
            this.TopTemperature.Text = "8";
            this.TopTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TopTemperature.TextChanged += new System.EventHandler(this.TopTemperature_TextChanged);
            // 
            // TopPressure
            // 
            this.TopPressure.Location = new System.Drawing.Point(519, 55);
            this.TopPressure.Margin = new System.Windows.Forms.Padding(2);
            this.TopPressure.Name = "TopPressure";
            this.TopPressure.Size = new System.Drawing.Size(106, 23);
            this.TopPressure.TabIndex = 14;
            this.TopPressure.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TopPressure.TextChanged += new System.EventHandler(this.TopPressure_TextChanged);
            // 
            // TopDepth
            // 
            this.TopDepth.Location = new System.Drawing.Point(276, 55);
            this.TopDepth.Margin = new System.Windows.Forms.Padding(2);
            this.TopDepth.Name = "TopDepth";
            this.TopDepth.Size = new System.Drawing.Size(106, 23);
            this.TopDepth.TabIndex = 15;
            this.TopDepth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TopDepth.TextChanged += new System.EventHandler(this.TopDepth_TextChanged);
            // 
            // MiddleDepth
            // 
            this.MiddleDepth.BackColor = System.Drawing.SystemColors.Window;
            this.MiddleDepth.Location = new System.Drawing.Point(276, 236);
            this.MiddleDepth.Margin = new System.Windows.Forms.Padding(2);
            this.MiddleDepth.Name = "MiddleDepth";
            this.MiddleDepth.Size = new System.Drawing.Size(106, 23);
            this.MiddleDepth.TabIndex = 18;
            this.MiddleDepth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MiddleDepth.TextChanged += new System.EventHandler(this.MiddleDepth_TextChanged);
            // 
            // MiddlePressure
            // 
            this.MiddlePressure.Location = new System.Drawing.Point(519, 236);
            this.MiddlePressure.Margin = new System.Windows.Forms.Padding(2);
            this.MiddlePressure.Name = "MiddlePressure";
            this.MiddlePressure.Size = new System.Drawing.Size(106, 23);
            this.MiddlePressure.TabIndex = 17;
            this.MiddlePressure.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MiddlePressure.TextChanged += new System.EventHandler(this.MiddlePressure_TextChanged);
            // 
            // BottomDepth
            // 
            this.BottomDepth.Location = new System.Drawing.Point(276, 479);
            this.BottomDepth.Margin = new System.Windows.Forms.Padding(2);
            this.BottomDepth.Name = "BottomDepth";
            this.BottomDepth.Size = new System.Drawing.Size(106, 23);
            this.BottomDepth.TabIndex = 21;
            this.BottomDepth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.BottomDepth.TextChanged += new System.EventHandler(this.BottomDepth_TextChanged);
            // 
            // BottomPressure
            // 
            this.BottomPressure.Location = new System.Drawing.Point(519, 479);
            this.BottomPressure.Margin = new System.Windows.Forms.Padding(2);
            this.BottomPressure.Name = "BottomPressure";
            this.BottomPressure.Size = new System.Drawing.Size(106, 23);
            this.BottomPressure.TabIndex = 20;
            this.BottomPressure.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.BottomPressure.TextChanged += new System.EventHandler(this.BottomPressure_TextChanged);
            // 
            // BottomTemperature
            // 
            this.BottomTemperature.Location = new System.Drawing.Point(64, 479);
            this.BottomTemperature.Margin = new System.Windows.Forms.Padding(2);
            this.BottomTemperature.Name = "BottomTemperature";
            this.BottomTemperature.Size = new System.Drawing.Size(106, 23);
            this.BottomTemperature.TabIndex = 19;
            this.BottomTemperature.Text = "8";
            this.BottomTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.BottomTemperature.TextChanged += new System.EventHandler(this.BottomTemperature_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(729, 27);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(127, 20);
            this.label9.TabIndex = 22;
            this.label9.Text = "Gęstość [kg/m3]";
            // 
            // BottomDensity
            // 
            this.BottomDensity.Location = new System.Drawing.Point(743, 479);
            this.BottomDensity.Margin = new System.Windows.Forms.Padding(2);
            this.BottomDensity.Name = "BottomDensity";
            this.BottomDensity.ReadOnly = true;
            this.BottomDensity.Size = new System.Drawing.Size(106, 23);
            this.BottomDensity.TabIndex = 25;
            this.BottomDensity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // MiddleDensity
            // 
            this.MiddleDensity.Location = new System.Drawing.Point(743, 236);
            this.MiddleDensity.Margin = new System.Windows.Forms.Padding(2);
            this.MiddleDensity.Name = "MiddleDensity";
            this.MiddleDensity.ReadOnly = true;
            this.MiddleDensity.Size = new System.Drawing.Size(106, 23);
            this.MiddleDensity.TabIndex = 24;
            this.MiddleDensity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TopDensity
            // 
            this.TopDensity.Location = new System.Drawing.Point(743, 55);
            this.TopDensity.Margin = new System.Windows.Forms.Padding(2);
            this.TopDensity.Name = "TopDensity";
            this.TopDensity.ReadOnly = true;
            this.TopDensity.Size = new System.Drawing.Size(106, 23);
            this.TopDensity.TabIndex = 23;
            this.TopDensity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ActualTemperature
            // 
            this.ActualTemperature.Location = new System.Drawing.Point(64, 358);
            this.ActualTemperature.Margin = new System.Windows.Forms.Padding(2);
            this.ActualTemperature.Name = "ActualTemperature";
            this.ActualTemperature.ReadOnly = true;
            this.ActualTemperature.Size = new System.Drawing.Size(106, 23);
            this.ActualTemperature.TabIndex = 26;
            this.ActualTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ActualTemperature.Visible = false;
            // 
            // ActualDepth
            // 
            this.ActualDepth.Location = new System.Drawing.Point(276, 358);
            this.ActualDepth.Margin = new System.Windows.Forms.Padding(2);
            this.ActualDepth.Name = "ActualDepth";
            this.ActualDepth.ReadOnly = true;
            this.ActualDepth.Size = new System.Drawing.Size(106, 23);
            this.ActualDepth.TabIndex = 27;
            this.ActualDepth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ActualDepth.Visible = false;
            // 
            // ActualPressure
            // 
            this.ActualPressure.Location = new System.Drawing.Point(519, 358);
            this.ActualPressure.Margin = new System.Windows.Forms.Padding(2);
            this.ActualPressure.Name = "ActualPressure";
            this.ActualPressure.ReadOnly = true;
            this.ActualPressure.Size = new System.Drawing.Size(106, 23);
            this.ActualPressure.TabIndex = 28;
            this.ActualPressure.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ActualPressure.Visible = false;
            // 
            // ActualDensity
            // 
            this.ActualDensity.Location = new System.Drawing.Point(743, 358);
            this.ActualDensity.Margin = new System.Windows.Forms.Padding(2);
            this.ActualDensity.Name = "ActualDensity";
            this.ActualDensity.ReadOnly = true;
            this.ActualDensity.Size = new System.Drawing.Size(106, 23);
            this.ActualDensity.TabIndex = 29;
            this.ActualDensity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ActualDensity.Visible = false;
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 556);
            this.Controls.Add(this.ActualDensity);
            this.Controls.Add(this.ActualPressure);
            this.Controls.Add(this.ActualDepth);
            this.Controls.Add(this.ActualTemperature);
            this.Controls.Add(this.BottomDensity);
            this.Controls.Add(this.MiddleDensity);
            this.Controls.Add(this.TopDensity);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.BottomDepth);
            this.Controls.Add(this.BottomPressure);
            this.Controls.Add(this.BottomTemperature);
            this.Controls.Add(this.MiddleDepth);
            this.Controls.Add(this.MiddlePressure);
            this.Controls.Add(this.TopDepth);
            this.Controls.Add(this.TopPressure);
            this.Controls.Add(this.TopTemperature);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Copyright);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BaseForm";
            this.Text = "Kalkulacja Ciśnień";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label Copyright;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox TopTemperature;
        private TextBox TopPressure;
        private TextBox TopDepth;
        private TextBox MiddleDepth;
        private TextBox MiddlePressure;
        private TextBox BottomDepth;
        private TextBox BottomPressure;
        private TextBox BottomTemperature;
        private Label label9;
        private TextBox BottomDensity;
        private TextBox MiddleDensity;
        private TextBox TopDensity;
        private TextBox ActualTemperature;
        private TextBox ActualDepth;
        private TextBox ActualPressure;
        private TextBox ActualDensity;
    }
}