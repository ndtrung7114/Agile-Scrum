namespace CheapDeals.comLTD
{
    partial class main_system
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_product = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_search = new System.Windows.Forms.TextBox();
            this.cb_rauter = new System.Windows.Forms.CheckBox();
            this.cb_tablet = new System.Windows.Forms.CheckBox();
            this.cb_mobile = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.image = new System.Windows.Forms.DataGridViewImageColumn();
            this.tab_deal = new System.Windows.Forms.TabPage();
            this.tab_package = new System.Windows.Forms.TabPage();
            this.kb_exit = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tab_product.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_product);
            this.tabControl1.Controls.Add(this.tab_deal);
            this.tabControl1.Controls.Add(this.tab_package);
            this.tabControl1.Location = new System.Drawing.Point(1, 26);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(426, 742);
            this.tabControl1.TabIndex = 1;
            // 
            // tab_product
            // 
            this.tab_product.Controls.Add(this.label1);
            this.tab_product.Controls.Add(this.tb_search);
            this.tab_product.Controls.Add(this.cb_rauter);
            this.tab_product.Controls.Add(this.cb_tablet);
            this.tab_product.Controls.Add(this.cb_mobile);
            this.tab_product.Controls.Add(this.dataGridView1);
            this.tab_product.Location = new System.Drawing.Point(4, 25);
            this.tab_product.Name = "tab_product";
            this.tab_product.Padding = new System.Windows.Forms.Padding(3);
            this.tab_product.Size = new System.Drawing.Size(418, 713);
            this.tab_product.TabIndex = 0;
            this.tab_product.Text = "Product";
            this.tab_product.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Search:";
            // 
            // tb_search
            // 
            this.tb_search.Location = new System.Drawing.Point(158, 42);
            this.tb_search.Name = "tb_search";
            this.tb_search.Size = new System.Drawing.Size(171, 22);
            this.tb_search.TabIndex = 4;
            this.tb_search.TextChanged += new System.EventHandler(this.tb_search_TextChanged);
            // 
            // cb_rauter
            // 
            this.cb_rauter.AutoSize = true;
            this.cb_rauter.Location = new System.Drawing.Point(308, 97);
            this.cb_rauter.Name = "cb_rauter";
            this.cb_rauter.Size = new System.Drawing.Size(69, 20);
            this.cb_rauter.TabIndex = 3;
            this.cb_rauter.Text = "Rauter";
            this.cb_rauter.UseVisualStyleBackColor = true;
            this.cb_rauter.CheckedChanged += new System.EventHandler(this.cb_rauter_CheckedChanged);
            // 
            // cb_tablet
            // 
            this.cb_tablet.AutoSize = true;
            this.cb_tablet.Location = new System.Drawing.Point(190, 97);
            this.cb_tablet.Name = "cb_tablet";
            this.cb_tablet.Size = new System.Drawing.Size(68, 20);
            this.cb_tablet.TabIndex = 2;
            this.cb_tablet.Text = "Tablet";
            this.cb_tablet.UseVisualStyleBackColor = true;
            this.cb_tablet.CheckedChanged += new System.EventHandler(this.cb_tablet_CheckedChanged);
            // 
            // cb_mobile
            // 
            this.cb_mobile.AutoSize = true;
            this.cb_mobile.Location = new System.Drawing.Point(74, 97);
            this.cb_mobile.Name = "cb_mobile";
            this.cb_mobile.Size = new System.Drawing.Size(70, 20);
            this.cb_mobile.TabIndex = 1;
            this.cb_mobile.Text = "Mobile";
            this.cb_mobile.UseVisualStyleBackColor = true;
            this.cb_mobile.CheckedChanged += new System.EventHandler(this.cb_mobile_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.type,
            this.price,
            this.image});
            this.dataGridView1.Location = new System.Drawing.Point(6, 145);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(407, 576);
            this.dataGridView1.TabIndex = 0;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.Width = 50;
            // 
            // name
            // 
            this.name.HeaderText = "Name";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            this.name.Width = 75;
            // 
            // type
            // 
            this.type.HeaderText = "Type";
            this.type.MinimumWidth = 6;
            this.type.Name = "type";
            this.type.Width = 75;
            // 
            // price
            // 
            this.price.HeaderText = "Price";
            this.price.MinimumWidth = 6;
            this.price.Name = "price";
            this.price.Width = 50;
            // 
            // image
            // 
            this.image.HeaderText = "Image";
            this.image.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.image.MinimumWidth = 6;
            this.image.Name = "image";
            this.image.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.image.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.image.Width = 125;
            // 
            // tab_deal
            // 
            this.tab_deal.Location = new System.Drawing.Point(4, 25);
            this.tab_deal.Name = "tab_deal";
            this.tab_deal.Padding = new System.Windows.Forms.Padding(3);
            this.tab_deal.Size = new System.Drawing.Size(418, 713);
            this.tab_deal.TabIndex = 1;
            this.tab_deal.Text = "Deal";
            this.tab_deal.UseVisualStyleBackColor = true;
            // 
            // tab_package
            // 
            this.tab_package.Location = new System.Drawing.Point(4, 25);
            this.tab_package.Name = "tab_package";
            this.tab_package.Padding = new System.Windows.Forms.Padding(3);
            this.tab_package.Size = new System.Drawing.Size(418, 713);
            this.tab_package.TabIndex = 2;
            this.tab_package.Text = "Package";
            this.tab_package.UseVisualStyleBackColor = true;
            // 
            // kb_exit
            // 
            this.kb_exit.AutoSize = true;
            this.kb_exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.kb_exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kb_exit.Location = new System.Drawing.Point(401, -2);
            this.kb_exit.Name = "kb_exit";
            this.kb_exit.Size = new System.Drawing.Size(26, 25);
            this.kb_exit.TabIndex = 2;
            this.kb_exit.Text = "X";
            this.kb_exit.Click += new System.EventHandler(this.kb_exit_Click);
            // 
            // main_system
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 780);
            this.Controls.Add(this.kb_exit);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "main_system";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "main_system";
            this.tabControl1.ResumeLayout(false);
            this.tab_product.ResumeLayout(false);
            this.tab_product.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_product;
        private System.Windows.Forms.CheckBox cb_rauter;
        private System.Windows.Forms.CheckBox cb_tablet;
        private System.Windows.Forms.CheckBox cb_mobile;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tab_deal;
        private System.Windows.Forms.TabPage tab_package;
        private System.Windows.Forms.Label kb_exit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_search;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewImageColumn image;
    }
}