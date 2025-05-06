using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace food_recipe
{
    public partial class Dialog_Recipe : Form
    {
        private string id;
        private bool is_favorit;

        public Dialog_Recipe()
        {
            InitializeComponent();

        }

        



        public void setInformasi(string id, string judul_resep, string deskripsi, Image image, bool is_favorit)
        {
            this.id = id;
            txtJudul_Resep.Text = judul_resep;
            txtDeskripsi.Text = deskripsi;
            bg_image.Image = image;
            btnFavorit.Image = is_favorit ? btnFavorit.Image = Properties.Resources.heart : btnFavorit.Image = Properties.Resources.love__2_;
        }

        private void btnFavorit_Click(object sender, EventArgs e)
        {
            this.is_favorit = !this.is_favorit;
            btnFavorit.Image = this.is_favorit ? btnFavorit.Image = Properties.Resources.heart : btnFavorit.Image = Properties.Resources.love__2_;
            Database database = new Database("data_resep.db");
            database.tambahFavorit(this.id, this.is_favorit);
        }
    }
}
