using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sipaa.Framework;
using System.Data.SQLite;
using System.Windows.Forms.VisualStyles;
using System.Threading;

namespace food_recipe
{
    public partial class Dashboard : Form
    {
        private string kategori = "";
        public Dashboard()
        {
            InitializeComponent();
            tampilkan_Card("", false);
            hideTabControl();
    
        }


        public void hideTabControl()
        {
            tabControlHome.Appearance = TabAppearance.FlatButtons;
            tabControlHome.ItemSize = new System.Drawing.Size(0,1);
            tabControlHome.SizeMode = TabSizeMode.Fixed;
        }


        public void tampilkan_Card(string filter, bool favorit)
        {
            Control flowlayout = btnDashboard.BackColor != Color.White ? flowLayoutResep : flowLayoutFavorit;
            flowlayout.Controls.Clear();

            new Thread(() =>
            {
                Database database = new Database("data_resep.db");
                var list_resep = database.getResepData(filter, favorit, this.kategori);

                flowlayout.Invoke(new Action(() =>
                {
                    if (list_resep.Count == 0)
                    {
                        flowlayout.Controls.Add(empty_box());
                        return;
                    }

                    foreach (var item in list_resep)
                    {
                        Card card = new Card(item.id, item.judulResep, item.deskripsi, item.image, item.favorit, this);
                        flowlayout.Controls.Add(card.card());
                    }
                }));
            }).Start();
        }


        public Control empty_box()
        {
            // Panel container horizontal
            Panel emptyPanel = new Panel();
            emptyPanel.Size = new Size(300, 100);
            emptyPanel.Margin = new Padding(10);
            emptyPanel.BackColor = Color.Transparent;

            // PictureBox
            PictureBox emptyImage = new PictureBox();
            emptyImage.Image = Properties.Resources.empty_box2;
            emptyImage.SizeMode = PictureBoxSizeMode.Zoom;
            emptyImage.Size = new Size(80, 80);
            emptyImage.Location = new Point(10, 10);

            // Label
            Label emptyLabel = new Label();
            emptyLabel.Text = "Tidak ada resep tersedia";
            emptyLabel.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            emptyLabel.AutoSize = false;
            emptyLabel.Size = new Size(190, 80);
            emptyLabel.Location = new Point(100, 10);
            emptyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // Tambahkan ke panel
            emptyPanel.Controls.Add(emptyImage);
            emptyPanel.Controls.Add(emptyLabel);

            return emptyPanel;
        }



        private void flowLayoutResep_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void btnDashboard_Click(object sender, EventArgs e)
        {

            btnDashboard.BackColor = System.Drawing.Color.FromArgb(96, 181, 255);
            btnDashboard.Image = Properties.Resources.dashboard__1_;
            btnDashboard.ForeColor = System.Drawing.Color.White;
            btnFavorit.BackColor = System.Drawing.Color.White;
            btnFavorit.ForeColor = System.Drawing.Color.Black;
            btnFavorit.Image = Properties.Resources.love;
            tabControlHome.SelectedTab = tabControlHome.TabPages[0];
            tampilkan_Card("", false);
        }

        private void btnFavorit_Click(object sender, EventArgs e)
        {
            btnDashboard.BackColor = System.Drawing.Color.White;
            btnDashboard.Image = Properties.Resources.dashboard;
            btnDashboard.ForeColor = System.Drawing.Color.Black;
            btnFavorit.BackColor = System.Drawing.Color.FromArgb(96, 181, 255);
            btnFavorit.ForeColor = System.Drawing.Color.White;
            btnFavorit.Image = Properties.Resources.love__1_;
            tabControlHome.SelectedTab = tabControlHome.TabPages[1];
            tampilkan_Card("", true);
        }


        public void Fading(Form formToShow, double opacity)
        {
            Form fading = new Form();

            try
            {
                fading.FormBorderStyle = FormBorderStyle.None;
                fading.Opacity = opacity;
                fading.BackColor = Color.Black;
                fading.Size = this.Size;
                fading.ShowInTaskbar = false;
                fading.Size = new Size(this.Width - 15, this.Height - 39);
                fading.StartPosition = FormStartPosition.Manual;
                fading.Location = new Point(this.Location.X, this.Location.Y);

                fading.Bounds = this.Bounds;
                fading.Show(this);
                formToShow.ShowDialog(fading); // tampilkan formToShow dengan 'fading' sebagai parent

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fading.Dispose();
            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            if (btnDashboard.BackColor != Color.White)
            {
                this.tampilkan_Card(txtCari.Texts, false);
            }
            else
            {
                this.tampilkan_Card(txtCari.Texts, true);
            }
        }


        private void txtCari_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter ) 
            //{
            //    this.tampilkan_Card("");
            //    e.SuppressKeyPress = true;
            //}
        }

        private void resetTombolKategori()
        {
            btnAll.BackColor = Color.White;
            btnFood.BackColor = Color.White;
            btnDrink.BackColor = Color.White;
            btnAll.ForeColor = Color.Black;
            btnFood.ForeColor = Color.Black;
            btnDrink.ForeColor = Color.Black;
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            this.kategori = "";
            resetTombolKategori();
            btnAll.BackColor = Color.FromArgb(96, 181, 255);
            btnAll.ForeColor = Color.White;
    

        }

        private void btnFood_Click(object sender, EventArgs e)
        {
            this.kategori = "Makanan";
            resetTombolKategori();
            btnFood.BackColor = Color.FromArgb(96, 181, 255);
            btnFood.ForeColor = Color.White;
        }

        private void btnDrink_Click(object sender, EventArgs e)
        {
            this.kategori = "Minuman";
            resetTombolKategori();
            btnDrink.BackColor = Color.FromArgb(96, 181, 255);
            btnDrink.ForeColor = Color.White;
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            Form loginForm = Application.OpenForms["Dialog_Login"];
            if (loginForm != null)
            {
                loginForm.Show();
            }
            this.Close();
        }

        
    }


    public class Card
    {
        public byte[] image;
        public string id { get; set; }
        public string judul_resep { get; set; }
        public string deskripsi { get; set; }
        public bool is_favorit { get; set; }

        private Form formparent;


        public Card(String id, String judul_resep, string deskripsi, byte[] image,bool is_favorit, Form formparent)
        {
            this.id = id;
            this.judul_resep = judul_resep;
            this.deskripsi = deskripsi;
            this.image = image;
            this.is_favorit = is_favorit;
            this.formparent = formparent;
        }

    
        public Control card()
        {
            SPanel panel = new SPanel();
            Panel bottom_panel = new Panel();
            SButton btnimage = new SButton();
            SButton fav_btn = new SButton();
            Label label_resep = new Label();
            // konfigurasi bentuk panel

            panel.Size = new System.Drawing.Size(200, 200);
            panel.MaximumSize = new System.Drawing.Size(200, 200);
            panel.BorderRadius = 10;
            panel.BorderSize = 1;
            panel.BorderColor = System.Drawing.Color.Gainsboro;
            panel.BackColor = System.Drawing.Color.White;
            panel.Padding = new System.Windows.Forms.Padding(10,10, 10, 15);

            // konfigurassi btnimage
            btnimage.Size = new System.Drawing.Size(417, 120);
            btnimage.MaximumSize = new System.Drawing.Size(0, 0);
            btnimage.BackColor = System.Drawing.Color.FromArgb(255, 236, 219);
            Image newimage = ConvertByteArrayToImage(image);
            btnimage.Image = newimage;
            btnimage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(96, 181, 255);
            btnimage.Dock = DockStyle.Top;
            //Event click
            btnimage.Click += this.buka_resep;

            btnimage.MouseHover += (s, e) => {
                btnimage.Image = Properties.Resources.share;
            };

            btnimage.MouseLeave += (s, e) =>
            {
                btnimage.Image = newimage;
            };

            // konfigurasi favorite button

            fav_btn.Size = new System.Drawing.Size(45, 35);
            fav_btn.MaximumSize = new System.Drawing.Size(45, 35);
            fav_btn.BackColor = System.Drawing.Color.White;

            this.is_favorit = is_favorit;
            fav_btn.Image = this.is_favorit ? fav_btn.Image = Properties.Resources.heart : fav_btn.Image = Properties.Resources.love__2_;

            fav_btn.Dock = DockStyle.Right;
            // Event click
            fav_btn.Click += (s, e) =>
            {
                Database database = new Database("data_resep.db");
                this.is_favorit = !this.is_favorit;
                database.tambahFavorit(this.id, is_favorit);
                fav_btn.Image = this.is_favorit ? fav_btn.Image = Properties.Resources.heart : fav_btn.Image = Properties.Resources.love__2_;

            };

            // konfigurasi label
            label_resep.Text = this.judul_resep;
            label_resep.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold);
            label_resep.ForeColor = System.Drawing.Color.Black;
            label_resep.Dock = DockStyle.Left;


            //konfigurasi panel bawah
            bottom_panel.Dock = DockStyle.Bottom;
            bottom_panel.Controls.Add(label_resep);
            bottom_panel.Controls.Add(fav_btn);
            bottom_panel.Size = new System.Drawing.Size(417, 35);

            // tambahkan ke panel semua
            panel.Controls.Add(btnimage);
            panel.Controls.Add(bottom_panel);

            return panel;

        }

        public Image ConvertByteArrayToImage(byte[] byteArray)
        {
            if (byteArray == null || byteArray.Length == 0)
            {
                return null;  // Mengembalikan null jika byteArray kosong
            }

            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);  // Mengonversi byte[] menjadi Image
            }
        }

        public void Fading(Form formToShow, double opacity)
        {
            Form fading = new Form();

            try
            {
                fading.FormBorderStyle = FormBorderStyle.None;
                fading.Opacity = opacity;
                fading.BackColor = Color.Black;
                fading.Size = formparent.Size;
                fading.ShowInTaskbar = false;
                fading.Size = new Size(formparent.Width - 15, formparent.Height - 39);
                fading.StartPosition = FormStartPosition.Manual;
                fading.Location = new Point(formparent.Location.X+8, formparent.Location.Y+31);
                fading.Show(formparent);
                formToShow.ShowDialog(fading); // tampilkan formToShow dengan 'fading' sebagai parent

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fading.Dispose();
            }
        }


        public void buka_resep(object sender, EventArgs args)
        {
            Dialog_Recipe dialog_Recipe = new Dialog_Recipe();
            dialog_Recipe.setInformasi(this.id, this.judul_resep, this.deskripsi, ConvertByteArrayToImage(this.image), this.is_favorit);
            Fading(dialog_Recipe, 0.5);
            //dialog_Recipe.ShowDialog();
        }


    }

    public class Database
    {
        private string path;

        public Database(string db_path)
        {
            this.path = $"Data Source={db_path};version=3";
        }

        public List<Resep> getResepData(string search = "", bool favorit = false, string kategori="") {
            var reseps = new List<Resep>();
            try
            {
                using (var connection = new SQLiteConnection(this.path))
                {
                    connection.Open();
                    string query = "SELECT id, judul, deskripsi, image, favorit, kategori FROM Resep";
                    List<string> conditions = new List<string>();

                    if (favorit)
                        conditions.Add("favorit = 1");

                    if (!string.IsNullOrEmpty(search))
                        conditions.Add("judul LIKE @search");

                    if (!string.IsNullOrEmpty(kategori))
                        conditions.Add("kategori LIKE @kategori");

                    if (conditions.Count > 0)
                        query += " WHERE " + string.Join(" AND ", conditions);

                    var command = new SQLiteCommand(query, connection);
                    if (!string.IsNullOrEmpty(search))
                    {
                        command.Parameters.AddWithValue("@search", "%" + search + "%");
                    }
                    if (!string.IsNullOrEmpty(kategori))
                        command.Parameters.AddWithValue("@kategori", kategori);

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        reseps.Add(new Resep
                        {
                            id = reader["id"].ToString(),
                            judulResep = reader["judul"].ToString(),
                            deskripsi = reader["deskripsi"].ToString(),
                            image = reader["image"] != DBNull.Value ? (byte[])reader["image"] : new byte[0],
                            favorit = Convert.ToBoolean(reader["favorit"]),
                            kategori = reader["kategori"].ToString()



                        });
                    }
                    connection.Close();
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return reseps;
        }

        public void tambahFavorit(string id, bool favorit)
        {
            using(var connection = new SQLiteConnection(this.path))
            {
                connection.Open();
                string query = "UPDATE Resep SET favorit = @favorit WHERE id = @id";
                var command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@favorit", favorit);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }

    }

    public class Resep
    {
        public string id { get; set; }
        public string judulResep { get; set; }
        public string deskripsi { get; set; }
        public byte[] image { get; set; }
        public bool favorit { get; set; }
        public string kategori { get; set; }
    }
}
