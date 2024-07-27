using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheapDeals.comLTD
{
    public partial class product_detail : UserControl
    {
        private SqlConnection connect = new SqlConnection(Database_config.ConnectionString);
        public int product_id;
        public product_detail()
        {
            InitializeComponent();
            lb_back.Visible = false;
           
          
        }



        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void load_product_detail(int id, string type)
        {
            // Connection string (replace with your actual connection string)
            string connectionString = Database_config.ConnectionString;
            

            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open();
                    string query;

                    if (type == "package")
                    {
                        query = "SELECT name, 'package' AS type, price, debut_date, description, NULL AS image FROM Package WHERE package_id = @id";
                        list_package.Visible = false;
                        label3.Visible = false;
                        label2.Text = "Packge Detail";
                    }
                    else
                    {
                        query = "SELECT name, type, price, debut_date, description, image FROM Product WHERE product_id = @id";
                        list_package.Visible = true;
                        label3.Visible = true;
                        lb_back.Visible = false;
                    }

                    using (SqlCommand cmd = new SqlCommand(query, connect))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                tb_name.Text = reader["name"].ToString();
                                tb_type.Text = reader["type"].ToString();
                                tb_price.Text = reader["price"].ToString();
                                tb_date.Text = reader["debut_date"].ToString();
                                tb_description.Text = reader["description"].ToString();

                                // Load and display the image if it's a product
                                if (type != "package")
                                {
                                    string imagePath = reader["image"].ToString();
                                    if (File.Exists(imagePath))
                                    {
                                        using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                                        {
                                            Image originalImage = Image.FromStream(stream);
                                            Image resizedImage = ResizeImage(originalImage, box_image.Width, box_image.Height);
                                            box_image.Image = resizedImage;
                                        }
                                    }
                                    else
                                    {
                                        box_image.Image = null;
                                    }
                                }
                                else
                                {
                                    box_image.Image = null;
                                }
                            }
                        }
                    }

                    if (type != "package")
                    {
                        string query_related_package = @"
                    SELECT p.name 
                    FROM Product po 
                    JOIN Package_Product pp ON po.product_id = pp.product_id
                    JOIN Package p ON pp.package_id = p.package_id
                    WHERE po.product_id = @id";

                        using (SqlCommand relatedCmd = new SqlCommand(query_related_package, connect))
                        {
                            relatedCmd.Parameters.AddWithValue("@id", id);
                            using (SqlDataReader relatedReader = relatedCmd.ExecuteReader())
                            {
                                list_package.Items.Clear();
                                while (relatedReader.Read())
                                {
                                    list_package.Items.Add(relatedReader["name"].ToString());
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }


        private Image ResizeImage(Image img, int maxWidth, int maxHeight)
        {
            int originalWidth = img.Width;
            int originalHeight = img.Height;
            float ratio = Math.Min((float)maxWidth / originalWidth, (float)maxHeight / originalHeight);

            int newWidth = (int)(originalWidth * ratio);
            int newHeight = (int)(originalHeight * ratio);

            Bitmap newImage = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage(newImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(img, 0, 0, newWidth, newHeight);
            }

            return newImage;
        }

        private void box_image_Click(object sender, EventArgs e)
        {

        }

        private void list_package_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ensure there is a selected item
            if (list_package.SelectedIndex != -1)
            {
                // Extract semester information from the selected item
                string selected_package_name = list_package.SelectedItem.ToString();


                // Retrieve semester_id from database based on nameSemester and year
                /*try
                {*/
                string query = @"
                        SELECT package_id
                        FROM Package
                        WHERE name = @name"
                ;

                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    command.Parameters.AddWithValue("@name", selected_package_name);


                    if (connect.State == ConnectionState.Closed) { connect.Open(); };
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        int package_id = Convert.ToInt32(result);

                        // Load subjects for the selected semester
                        load_product_detail(package_id, "package");
                        lb_back.Visible = true;
                    }
                }

            }
        }

        private void lb_back_Click(object sender, EventArgs e)
        {
            load_product_detail(product_id, "product");
            
        }
    }
}
