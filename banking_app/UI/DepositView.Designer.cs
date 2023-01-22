namespace banking_app.UI
{
    partial class DepositView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.comboCurrencyDepo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAmounDepo = new System.Windows.Forms.TextBox();
            this.btnCreateDepo = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(118, 136);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Transaction currency: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboCurrencyDepo
            // 
            this.comboCurrencyDepo.FormattingEnabled = true;
            this.comboCurrencyDepo.Items.AddRange(new object[] {
            "CAD",
            "USD"});
            this.comboCurrencyDepo.Location = new System.Drawing.Point(335, 134);
            this.comboCurrencyDepo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboCurrencyDepo.Name = "comboCurrencyDepo";
            this.comboCurrencyDepo.Size = new System.Drawing.Size(276, 28);
            this.comboCurrencyDepo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(210, 178);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Amount: ";
            // 
            // txtAmounDepo
            // 
            this.txtAmounDepo.Location = new System.Drawing.Point(335, 176);
            this.txtAmounDepo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAmounDepo.Name = "txtAmounDepo";
            this.txtAmounDepo.Size = new System.Drawing.Size(277, 27);
            this.txtAmounDepo.TabIndex = 3;
            // 
            // btnCreateDepo
            // 
            this.btnCreateDepo.BackColor = System.Drawing.Color.Green;
            this.btnCreateDepo.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCreateDepo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCreateDepo.Location = new System.Drawing.Point(335, 233);
            this.btnCreateDepo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCreateDepo.Name = "btnCreateDepo";
            this.btnCreateDepo.Size = new System.Drawing.Size(275, 41);
            this.btnCreateDepo.TabIndex = 4;
            this.btnCreateDepo.Text = "Deposit";
            this.btnCreateDepo.UseVisualStyleBackColor = false;
            this.btnCreateDepo.Click += new System.EventHandler(this.btnCreateDepo_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::banking_app.Properties.Resources.bank_tree_high_resolution_logo_color_on_transparent_background;
            this.pictureBox1.Location = new System.Drawing.Point(1, -1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(221, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // DepositView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(708, 326);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCreateDepo);
            this.Controls.Add(this.txtAmounDepo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboCurrencyDepo);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "DepositView";
            this.Text = "DepositView";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private ComboBox comboCurrencyDepo;
        private Label label2;
        private TextBox txtAmounDepo;
        private Button btnCreateDepo;
        private PictureBox pictureBox1;
    }
}