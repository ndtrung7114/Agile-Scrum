using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CheapDeals.comLTD
{
    public partial class main_system : Form
    {
        private SqlConnection connect = new SqlConnection(Database_config.ConnectionString);
        private product_detail productDetailControl;

        public main_system()
        {
            InitializeComponent();
            load_product();
            dataGridView1.CellClick += dataGridView1_CellClick;

            // Initialize the product_detail control
            productDetailControl = new product_detail();
            this.Controls.Add(productDetailControl);
            productDetailControl.Dock = DockStyle.Fill;
            productDetailControl.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the click is on a valid row
            if (e.RowIndex >= 0)
            {
                // Get the product_id from the clicked row
                int product_id = (int)dataGridView1.Rows[e.RowIndex].Cells["id"].Value;

                // Show the product_detail user control and load product details
                productDetailControl.Show();
                productDetailControl.BringToFront();
                productDetailControl.load_product_detail(product_id);
            }
        }

        private void kb_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void load_product(string typeFilter = "", string searchText = "")
        {
            try
            {
                connect.Open();
                string query = "SELECT product_id, name, type, price, image FROM Product";

                // Build the filter string
                string filter = "";
                if (!string.IsNullOrEmpty(typeFilter))
                {
                    filter = typeFilter;
                }

                if (!string.IsNullOrEmpty(searchText))
                {
                    if (!string.IsNullOrEmpty(filter))
                    {
                        filter += " AND ";
                    }
                    filter += "name LIKE '%' + @searchText + '%'";
                }

                if (!string.IsNullOrEmpty(filter))
                {
                    query += " WHERE " + filter;
                }

                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@searchText", searchText);

                SqlDataReader reader = cmd.ExecuteReader();

                // Clear existing rows
                dataGridView1.Rows.Clear();
                dataGridView1.AllowUserToAddRows = false;

                // Read data from the database and add to DataGridView
                while (reader.Read())
                {
                    int productId = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string type = reader.GetString(2);
                    double price = reader.GetDouble(3);
                    string imagePath = reader.IsDBNull(4) ? null : reader.GetString(4);

                    // Convert image path to Image object
                    Image productImage = null;
                    if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                    {
                        using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                        {
                            Image originalImage = Image.FromStream(stream);
                            productImage = ResizeImage(originalImage, 50, 50);
                        }
                    }

                    // Add a new row with the product details
                    dataGridView1.Rows.Add(productId, name, type, price, productImage);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                connect.Close();
            }
        }


        private Image ResizeImage(Image img, int width, int height)
        {
            Bitmap b = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(b))
            {
                g.DrawImage(img, 0, 0, width, height);
            }
            return b;
        }

        private void cb_rauter_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void cb_tablet_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void cb_mobile_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            string typeFilter = "";
            string searchText = tb_search.Text.Trim();

            if (cb_mobile.Checked)
            {
                typeFilter += "type = 'mobile'";
            }
            if (cb_tablet.Checked)
            {
                if (!string.IsNullOrEmpty(typeFilter))
                {
                    typeFilter += " OR ";
                }
                typeFilter += "type = 'tablet'";
            }
            if (cb_rauter.Checked)
            {
                if (!string.IsNullOrEmpty(typeFilter))
                {
                    typeFilter += " OR ";
                }
                typeFilter += "type = 'rauter'";
            }

            load_product(typeFilter, searchText);
        }

        private void tb_search_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void main_system_Load(object sender, EventArgs e)
        {
        }
    }
}
