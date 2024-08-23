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
        public string type;
        public string logged_username;
        public product_detail()
        {
            InitializeComponent();
            lb_back.Visible = false;
            
           
          
        }



        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            load_product_detail(product_id, "product", logged_username);
        }

        public void load_product_detail(int id, string type, string username)

        {
            this.type = type;
            logged_username = username;
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
                    else if (type == "deal")
                    {
                        query = "SELECT name, type, price, date, description, image FROM Deal WHERE deal_id = @id";
                        list_package.Visible = false;
                        label3.Visible = false;
                        lb_back.Visible = false;
                        label2.Text = "Deal Detail";
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
                                    tb_date.Text = reader["date"].ToString();
                                    tb_description.Text = reader["description"].ToString();

                                }
                            }
                        }
                        return;
                    }
                    else
                    {
                        query = "SELECT name, type, price, debut_date, description, image FROM Product WHERE product_id = @id";
                        list_package.Visible = true;
                        label3.Visible = true;
                        lb_back.Visible = false;
                        label2.Text = "Product Detail";
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
                                if (type != "package" )
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

                    if ( type != "deal" && type != "package" )
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
                        load_product_detail(package_id, "package", logged_username);
                        lb_back.Visible = true;
                    }
                }

            }
        }

        private void lb_back_Click(object sender, EventArgs e)
        {
            load_product_detail(product_id, "product", logged_username);
            
        }

        private void btn_like_Click(object sender, EventArgs e)
        {
            string queryCheckLike = "SELECT COUNT(*) FROM Tracking_like_product WHERE username = @username AND id_product = @id AND type = @type";
            string queryUpdateLike = string.Empty;
            string queryInsertTracking = "INSERT INTO Tracking_like_product (username, id_product, type) VALUES (@username, @id, @type)";

            // Determine the correct update query based on the type
            if (type == "deal")
            {
                queryUpdateLike = "UPDATE Deal SET likes = likes + 1 WHERE deal_id = @id";
            }
            else if (type == "package")
            {
                queryUpdateLike = "UPDATE Package SET likes = likes + 1 WHERE package_id = @id";
            }
            else
            {
                queryUpdateLike = "UPDATE Product SET likes = likes + 1 WHERE product_id = @id";
            }

            try
            {
                using (SqlCommand cmdCheckLike = new SqlCommand(queryCheckLike, connect))
                {
                    cmdCheckLike.Parameters.AddWithValue("@username", logged_username);
                    cmdCheckLike.Parameters.AddWithValue("@id", product_id);
                    cmdCheckLike.Parameters.AddWithValue("@type", type);

                    if (connect.State == ConnectionState.Closed)
                    {
                        connect.Open();
                    }

                    int likeCount = (int)cmdCheckLike.ExecuteScalar();

                    if (likeCount > 0)
                    {
                        MessageBox.Show("You have already liked this item.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    using (SqlTransaction transaction = connect.BeginTransaction())
                    {
                        try
                        {
                            // Update like count
                            using (SqlCommand cmdUpdateLike = new SqlCommand(queryUpdateLike, connect, transaction))
                            {
                                cmdUpdateLike.Parameters.AddWithValue("@id", product_id);
                                cmdUpdateLike.ExecuteNonQuery();
                            }

                            // Insert tracking record
                            using (SqlCommand cmdInsertTracking = new SqlCommand(queryInsertTracking, connect, transaction))
                            {
                                cmdInsertTracking.Parameters.AddWithValue("@username", logged_username);
                                cmdInsertTracking.Parameters.AddWithValue("@id", product_id);
                                cmdInsertTracking.Parameters.AddWithValue("@type", type);
                                cmdInsertTracking.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            MessageBox.Show("Like updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("An error occurred while updating the like: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }

        }
    }
}
