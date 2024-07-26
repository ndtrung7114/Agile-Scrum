using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheapDeals.comLTD
{
    public partial class product_detail : UserControl
    {
        
        public product_detail()
        {
            InitializeComponent();
           
          
        }



        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void load_product_detail(int product_id)
        {
            // Connection string (replace with your actual connection string)
            string connectionString = Database_config.ConnectionString;

            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open();
                    string query = "SELECT name, type, price, debut_date, description, image FROM Product WHERE product_id = @product_id";
                    using (SqlCommand cmd = new SqlCommand(query, connect))
                    {
                        cmd.Parameters.AddWithValue("@product_id", product_id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                tb_name.Text = reader["name"].ToString();
                                tb_type.Text = reader["type"].ToString();
                                tb_price.Text = reader["price"].ToString();
                                tb_date.Text = reader["debut_date"].ToString();
                                tb_description.Text = reader["description"].ToString();

                                // Load and display the image
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
    }
}
