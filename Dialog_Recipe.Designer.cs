namespace food_recipe
{
    partial class Dialog_Recipe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dialog_Recipe));
            this.txtJudul_Resep = new System.Windows.Forms.Label();
            this.txtDeskripsi = new System.Windows.Forms.RichTextBox();
            this.btnFavorit = new Sipaa.Framework.SButton();
            this.bg_image = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.bg_image)).BeginInit();
            this.SuspendLayout();
            // 
            // txtJudul_Resep
            // 
            this.txtJudul_Resep.AutoSize = true;
            this.txtJudul_Resep.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJudul_Resep.Location = new System.Drawing.Point(12, 139);
            this.txtJudul_Resep.Name = "txtJudul_Resep";
            this.txtJudul_Resep.Size = new System.Drawing.Size(154, 22);
            this.txtJudul_Resep.TabIndex = 5;
            this.txtJudul_Resep.Text = "Nasi Goreng Nenek";
            // 
            // txtDeskripsi
            // 
            this.txtDeskripsi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDeskripsi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeskripsi.Location = new System.Drawing.Point(16, 175);
            this.txtDeskripsi.Name = "txtDeskripsi";
            this.txtDeskripsi.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtDeskripsi.Size = new System.Drawing.Size(417, 153);
            this.txtDeskripsi.TabIndex = 6;
            this.txtDeskripsi.Text = resources.GetString("txtDeskripsi.Text");
            // 
            // btnFavorit
            // 
            this.btnFavorit.BackColor = System.Drawing.Color.White;
            this.btnFavorit.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnFavorit.BorderRadius = 10;
            this.btnFavorit.BorderSize = 0;
            this.btnFavorit.FlatAppearance.BorderSize = 0;
            this.btnFavorit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFavorit.ForeColor = System.Drawing.Color.White;
            this.btnFavorit.Image = global::food_recipe.Properties.Resources.heart;
            this.btnFavorit.Location = new System.Drawing.Point(388, 134);
            this.btnFavorit.Name = "btnFavorit";
            this.btnFavorit.Size = new System.Drawing.Size(45, 35);
            this.btnFavorit.TabIndex = 7;
            this.btnFavorit.UseVisualStyleBackColor = false;
            this.btnFavorit.Click += new System.EventHandler(this.btnFavorit_Click);
            // 
            // bg_image
            // 
            this.bg_image.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(221)))), ((int)(((byte)(255)))));
            this.bg_image.Dock = System.Windows.Forms.DockStyle.Top;
            this.bg_image.Image = global::food_recipe.Properties.Resources.food1;
            this.bg_image.Location = new System.Drawing.Point(0, 0);
            this.bg_image.Name = "bg_image";
            this.bg_image.Size = new System.Drawing.Size(445, 128);
            this.bg_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.bg_image.TabIndex = 0;
            this.bg_image.TabStop = false;
            // 
            // Dialog_Recipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(445, 340);
            this.Controls.Add(this.btnFavorit);
            this.Controls.Add(this.txtDeskripsi);
            this.Controls.Add(this.txtJudul_Resep);
            this.Controls.Add(this.bg_image);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dialog_Recipe";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Resep";
            ((System.ComponentModel.ISupportInitialize)(this.bg_image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox bg_image;
        private System.Windows.Forms.Label txtJudul_Resep;
        private System.Windows.Forms.RichTextBox txtDeskripsi;
        private Sipaa.Framework.SButton btnFavorit;
    }
}