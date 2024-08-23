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
        private string loggedInUsername;
        private SqlConnection connect = new SqlConnection(Database_config.ConnectionString);
        private product_detail productDetailControl;

        public main_system(string user_name)
        {
            InitializeComponent();
            load_product();
            Show_datagridview_deal_package_product();
            dataGridView1.CellClick += dataGridView1_CellClick;
            datagridview_product.CellClick += datagridview_product_CellContentClick;
            datagridview_package.CellClick += datagridview_package_CellContentClick;
            datagridview_deal.CellClick += datagridview_deal_CellContentClick;
            Hide_datagridview1();
            lb_back.Visible = false;
            this.loggedInUsername = user_name;
            MessageBox.Show("Welcome, " + loggedInUsername + "!");


             

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
                string type = dataGridView1.Rows[e.RowIndex].Cells["type"].Value.ToString();

                // Show the product_detail user control and load product details
                productDetailControl.Show();
                productDetailControl.BringToFront();
                productDetailControl.product_id = product_id; //product_id có thể là id của product, deal, package
                
                productDetailControl.load_product_detail(product_id, type, loggedInUsername);
            }
        }

        

        private void kb_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void load_product(string typeFilter = "", string searchText = "")
        {
            if (connect.State == ConnectionState.Closed) { connect.Open(); }
            string query = @"
        SELECT DISTINCT p.product_id AS id, p.name AS item_name, p.type AS item_type, p.price AS item_price, p.image AS item_image 
        FROM Product p
        LEFT JOIN Package_Product pp ON p.product_id = pp.product_id
        LEFT JOIN Package pk ON pp.package_id = pk.package_id
        WHERE (@typeFilter = '' OR p.type = @typeFilter)
          AND (p.name LIKE '%' + @searchText + '%' OR pk.name LIKE '%' + @searchText + '%')
        UNION ALL
        SELECT pk.package_id AS id, pk.name AS item_name, 'package' AS item_type, pk.price AS item_price, NULL AS item_image 
        FROM Package pk
        LEFT JOIN Package_Product pp ON pk.package_id = pp.package_id
        LEFT JOIN Product p ON pp.product_id = p.product_id
        WHERE (@typeFilter = 'package' OR @typeFilter = '')
          AND (p.name LIKE '%' + @searchText + '%' OR pk.name LIKE '%' + @searchText + '%')";

            SqlCommand cmd = new SqlCommand(query, connect);
            cmd.Parameters.AddWithValue("@typeFilter", typeFilter);
            cmd.Parameters.AddWithValue("@searchText", searchText);

            SqlDataReader reader = cmd.ExecuteReader();

            // Clear existing rows
            dataGridView1.Rows.Clear();
            dataGridView1.AllowUserToAddRows = false;

            // Read data from the database and add to DataGridView
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                string type = reader.GetString(2);
                double price = reader.GetDouble(3);
                string imagePath = reader.IsDBNull(4) ? null : reader.GetString(4);

                // Convert image path to Image object
                Image itemImage = null;
                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                {
                    using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        Image originalImage = Image.FromStream(stream);
                        itemImage = ResizeImage(originalImage, 50, 50);
                    }
                }

                // Add a new row with the item details
                dataGridView1.Rows.Add(id, name, type, price, itemImage);
            }

            reader.Close();
            connect.Close();
        }
     
        private void UpdateProductList()
        {
            string typeFilter = "";
            if (cb_rauter.Checked) typeFilter = "rauter";
            else if (cb_tablet.Checked) typeFilter = "tablet";
            else if (cb_mobile.Checked) typeFilter = "mobile";
            else if (cb_package.Checked) typeFilter = "package";

            load_product(typeFilter, tb_search.Text);

            // Show and hide relevant controls
            if (!string.IsNullOrEmpty(typeFilter) || !string.IsNullOrEmpty(tb_search.Text))
            {
                Show_datagridview1();
                Hide_datagridview_deal_package_product();
            }
            else
            {
                Hide_datagridview1();
                Show_datagridview_deal_package_product();
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
            UpdateProductList();
        }

        private void cb_tablet_CheckedChanged(object sender, EventArgs e)
        {
            UpdateProductList();
        }

        private void cb_mobile_CheckedChanged(object sender, EventArgs e)
        {
            UpdateProductList();
        }

        

        private void tb_search_TextChanged(object sender, EventArgs e)
        {
            UpdateProductList();
        }

       

        private void cb_package_CheckedChanged(object sender, EventArgs e)
        {
            UpdateProductList();
        }

        private void Show_datagridview1()
        {
            dataGridView1.Visible = true;
            lb_back.Visible = true;
        }

        private void Hide_datagridview1()
        {
            dataGridView1.Visible = false;
        }


        private void Hide_datagridview_deal_package_product()
        {
            datagridview_deal.Visible = false;
            lb_deal.Visible = false;
            datagridview_package.Visible = false;
            label_package.Visible = false;
            datagridview_product.Visible = false;
            label_product.Visible = false;
         
        }

        private void Show_datagridview_deal_package_product()
        {
            // Load most liked products, packages, and deals
            load_top_liked_products();
            load_top_liked_packages();
            load_top_liked_deals();

            datagridview_deal.Visible = true;
            lb_deal.Visible = true;
            datagridview_package.Visible = true;
            label_package.Visible = true;
            datagridview_product.Visible = true;
            label_product.Visible = true;
            lb_back.Visible = false;
        }

        private void lb_back_Click(object sender, EventArgs e)
        {
            Hide_datagridview1();
            Show_datagridview_deal_package_product();
            cb_mobile.Checked = false;
            cb_rauter.Checked = false;
            cb_package.Checked = false;
            cb_tablet.Checked = false;
            tb_search.Clear();
        }

        private void load_top_liked_products()
        {
            if (connect.State == ConnectionState.Closed) { connect.Open(); }
            string query = @"
            SELECT TOP 3 product_id, name, price, type, likes
            FROM Product
            ORDER BY likes DESC";

            SqlCommand cmd = new SqlCommand(query, connect);
            SqlDataReader reader = cmd.ExecuteReader();

            // Clear existing rows
            datagridview_product.Rows.Clear();
            datagridview_product.AllowUserToAddRows = false;

            // Read data from the database and add to DataGridView
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                double price = reader.GetDouble(2);
                string type = reader.GetString(3);
                int like = reader.GetInt32(4);



                // Add a new row with the item details
                datagridview_product.Rows.Add(id, name, price, type, like);
            }

            reader.Close();
            connect.Close();
        }

        private void load_top_liked_packages()
        {
            if (connect.State == ConnectionState.Closed) { connect.Open(); }
            string query = @"
            SELECT TOP 3 package_id, name, price, type, likes
            FROM Package
            ORDER BY likes DESC";

            SqlCommand cmd = new SqlCommand(query, connect);
            SqlDataReader reader = cmd.ExecuteReader();

            // Clear existing rows
            datagridview_package.Rows.Clear();
            datagridview_package.AllowUserToAddRows = false;

            // Read data from the database and add to DataGridView
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                double price = reader.GetDouble(2);
                string type = reader.GetString(3);
                int like = reader.GetInt32(4);

                // Add a new row with the item details
                datagridview_package.Rows.Add(id, name, price, type, like);
            }

            reader.Close();
            connect.Close();
        }

        private void load_top_liked_deals()
        {
            if (connect.State == ConnectionState.Closed) { connect.Open(); }
            string currentDate = DateTime.Today.ToString("M/d/yyyy");
           
            string query = @"
        SELECT TOP 3 deal_id, name, price, type, likes
        FROM Deal
        WHERE date = @currentDate
        ORDER BY likes DESC";

            SqlCommand cmd = new SqlCommand(query, connect);
            cmd.Parameters.AddWithValue("@currentDate", currentDate);

            SqlDataReader reader = cmd.ExecuteReader();

            // Clear existing rows
            datagridview_deal.Rows.Clear();
            datagridview_deal.AllowUserToAddRows = false;

            // Read data from the database and add to DataGridView
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                double price = reader.GetDouble(2);
                string type = reader.GetString(3);
                int like = reader.GetInt32(4);


                // Add a new row with the item details
                datagridview_deal.Rows.Add(id, name, price, type, like);
            }

            reader.Close();
            connect.Close();
        }

        private void datagridview_deal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get the product_id from the clicked row
                int product_id = (int)datagridview_deal.Rows[e.RowIndex].Cells["id_deal"].Value;
                string type = datagridview_deal.Rows[e.RowIndex].Cells["deal_type"].Value.ToString();

                // Show the product_detail user control and load product details
                productDetailControl.Show();
                productDetailControl.BringToFront();
                productDetailControl.product_id = product_id; // ở đây thì product_id là id của deal
                productDetailControl.load_product_detail(product_id, type, loggedInUsername);
            }

        }

        private void datagridview_product_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get the product_id from the clicked row
                int product_id = (int)datagridview_product.Rows[e.RowIndex].Cells["id_product"].Value;
                string type = datagridview_product.Rows[e.RowIndex].Cells["product_type"].Value.ToString();

                // Show the product_detail user control and load product details
                productDetailControl.Show();
                productDetailControl.BringToFront();
                productDetailControl.product_id = product_id; // ở đây thì product_id là id của product
                productDetailControl.load_product_detail(product_id, type, loggedInUsername);
            }

        }

        private void datagridview_package_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get the product_id from the clicked row
                int product_id = (int)datagridview_package.Rows[e.RowIndex].Cells["id_package"].Value;
                string type = datagridview_package.Rows[e.RowIndex].Cells["type_package"].Value.ToString();

                // Show the product_detail user control and load product details
                productDetailControl.Show();
                productDetailControl.BringToFront();
                productDetailControl.product_id = product_id;  // ở đây thì product_id là id của package
                productDetailControl.load_product_detail(product_id, type, loggedInUsername);
            }

        }
    }
}