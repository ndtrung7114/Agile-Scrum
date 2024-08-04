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
            this.kb_exit = new System.Windows.Forms.Label();
            this.tab_order = new System.Windows.Forms.TabPage();
            this.tab_product = new System.Windows.Forms.TabPage();
            this.lb_back = new System.Windows.Forms.Label();
            this.label_package = new System.Windows.Forms.Label();
            this.label_product = new System.Windows.Forms.Label();
            this.lb_deal = new System.Windows.Forms.Label();
            this.datagridview_package = new System.Windows.Forms.DataGridView();
            this.id_package = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name_package = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price_package = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type_package = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.like_package = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datagridview_product = new System.Windows.Forms.DataGridView();
            this.id_product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name_product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price_product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.like_product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datagridview_deal = new System.Windows.Forms.DataGridView();
            this.id_deal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name_deal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price_deal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deal_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.like_deal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cb_package = new System.Windows.Forms.CheckBox();
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_product.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview_package)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview_product)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview_deal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kb_exit
            // 
            this.kb_exit.AutoSize = true;
            this.kb_exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.kb_exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kb_exit.Location = new System.Drawing.Point(301, -2);
            this.kb_exit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.kb_exit.Name = "kb_exit";
            this.kb_exit.Size = new System.Drawing.Size(20, 20);
            this.kb_exit.TabIndex = 2;
            this.kb_exit.Text = "X";
            this.kb_exit.Click += new System.EventHandler(this.kb_exit_Click);
            // 
            // tab_order
            // 
            this.tab_order.Location = new System.Drawing.Point(4, 4);
            this.tab_order.Margin = new System.Windows.Forms.Padding(2);
            this.tab_order.Name = "tab_order";
            this.tab_order.Padding = new System.Windows.Forms.Padding(2);
            this.tab_order.Size = new System.Drawing.Size(312, 578);
            this.tab_order.TabIndex = 2;
            this.tab_order.Text = "Order";
            this.tab_order.UseVisualStyleBackColor = true;
            // 
            // tab_product
            // 
            this.tab_product.Controls.Add(this.lb_back);
            this.tab_product.Controls.Add(this.label_package);
            this.tab_product.Controls.Add(this.label_product);
            this.tab_product.Controls.Add(this.lb_deal);
            this.tab_product.Controls.Add(this.datagridview_package);
            this.tab_product.Controls.Add(this.datagridview_product);
            this.tab_product.Controls.Add(this.datagridview_deal);
            this.tab_product.Controls.Add(this.cb_package);
            this.tab_product.Controls.Add(this.label1);
            this.tab_product.Controls.Add(this.tb_search);
            this.tab_product.Controls.Add(this.cb_rauter);
            this.tab_product.Controls.Add(this.cb_tablet);
            this.tab_product.Controls.Add(this.cb_mobile);
            this.tab_product.Controls.Add(this.dataGridView1);
            this.tab_product.Location = new System.Drawing.Point(4, 4);
            this.tab_product.Margin = new System.Windows.Forms.Padding(2);
            this.tab_product.Name = "tab_product";
            this.tab_product.Padding = new System.Windows.Forms.Padding(2);
            this.tab_product.Size = new System.Drawing.Size(312, 578);
            this.tab_product.TabIndex = 0;
            this.tab_product.Text = "Product";
            this.tab_product.UseVisualStyleBackColor = true;
            // 
            // lb_back
            // 
            this.lb_back.AutoSize = true;
            this.lb_back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_back.Location = new System.Drawing.Point(2, 56);
            this.lb_back.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_back.Name = "lb_back";
            this.lb_back.Size = new System.Drawing.Size(32, 13);
            this.lb_back.TabIndex = 18;
            this.lb_back.Text = "Back";
            this.lb_back.Click += new System.EventHandler(this.lb_back_Click);
            // 
            // label_package
            // 
            this.label_package.AutoSize = true;
            this.label_package.Location = new System.Drawing.Point(6, 423);
            this.label_package.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_package.Name = "label_package";
            this.label_package.Size = new System.Drawing.Size(103, 13);
            this.label_package.TabIndex = 17;
            this.label_package.Text = "Interested Package:";
            // 
            // label_product
            // 
            this.label_product.AutoSize = true;
            this.label_product.Location = new System.Drawing.Point(6, 258);
            this.label_product.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_product.Name = "label_product";
            this.label_product.Size = new System.Drawing.Size(86, 13);
            this.label_product.TabIndex = 16;
            this.label_product.Text = "Popular Product:";
            // 
            // lb_deal
            // 
            this.lb_deal.AutoSize = true;
            this.lb_deal.Location = new System.Drawing.Point(6, 90);
            this.lb_deal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_deal.Name = "lb_deal";
            this.lb_deal.Size = new System.Drawing.Size(85, 13);
            this.lb_deal.TabIndex = 15;
            this.lb_deal.Text = "Deal Hot Today:";
            // 
            // datagridview_package
            // 
            this.datagridview_package.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridview_package.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_package,
            this.name_package,
            this.price_package,
            this.type_package,
            this.like_package});
            this.datagridview_package.Location = new System.Drawing.Point(5, 448);
            this.datagridview_package.Name = "datagridview_package";
            this.datagridview_package.Size = new System.Drawing.Size(304, 124);
            this.datagridview_package.TabIndex = 14;
            this.datagridview_package.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridview_package_CellContentClick);
            // 
            // id_package
            // 
            this.id_package.HeaderText = "ID";
            this.id_package.Name = "id_package";
            this.id_package.Width = 30;
            // 
            // name_package
            // 
            this.name_package.HeaderText = "Name";
            this.name_package.Name = "name_package";
            this.name_package.Width = 75;
            // 
            // price_package
            // 
            this.price_package.HeaderText = "Price";
            this.price_package.Name = "price_package";
            this.price_package.Width = 35;
            // 
            // type_package
            // 
            this.type_package.HeaderText = "Type";
            this.type_package.Name = "type_package";
            this.type_package.Width = 75;
            // 
            // like_package
            // 
            this.like_package.HeaderText = "Likes";
            this.like_package.Name = "like_package";
            this.like_package.Width = 40;
            // 
            // datagridview_product
            // 
            this.datagridview_product.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridview_product.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_product,
            this.name_product,
            this.price_product,
            this.product_type,
            this.like_product});
            this.datagridview_product.Location = new System.Drawing.Point(5, 283);
            this.datagridview_product.Name = "datagridview_product";
            this.datagridview_product.Size = new System.Drawing.Size(304, 124);
            this.datagridview_product.TabIndex = 13;
            this.datagridview_product.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridview_product_CellContentClick);
            // 
            // id_product
            // 
            this.id_product.HeaderText = "ID";
            this.id_product.Name = "id_product";
            this.id_product.Width = 30;
            // 
            // name_product
            // 
            this.name_product.HeaderText = "Name";
            this.name_product.Name = "name_product";
            this.name_product.Width = 85;
            // 
            // price_product
            // 
            this.price_product.HeaderText = "Price";
            this.price_product.Name = "price_product";
            this.price_product.Width = 40;
            // 
            // product_type
            // 
            this.product_type.HeaderText = "Type";
            this.product_type.Name = "product_type";
            this.product_type.Width = 60;
            // 
            // like_product
            // 
            this.like_product.HeaderText = "Likes";
            this.like_product.Name = "like_product";
            this.like_product.Width = 40;
            // 
            // datagridview_deal
            // 
            this.datagridview_deal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridview_deal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_deal,
            this.name_deal,
            this.price_deal,
            this.deal_type,
            this.like_deal});
            this.datagridview_deal.Location = new System.Drawing.Point(4, 117);
            this.datagridview_deal.Margin = new System.Windows.Forms.Padding(2);
            this.datagridview_deal.Name = "datagridview_deal";
            this.datagridview_deal.RowHeadersWidth = 51;
            this.datagridview_deal.RowTemplate.Height = 24;
            this.datagridview_deal.Size = new System.Drawing.Size(305, 129);
            this.datagridview_deal.TabIndex = 12;
            this.datagridview_deal.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridview_deal_CellContentClick);
            // 
            // id_deal
            // 
            this.id_deal.HeaderText = "ID";
            this.id_deal.Name = "id_deal";
            this.id_deal.Width = 30;
            // 
            // name_deal
            // 
            this.name_deal.HeaderText = "Name";
            this.name_deal.Name = "name_deal";
            this.name_deal.Width = 80;
            // 
            // price_deal
            // 
            this.price_deal.HeaderText = "Price";
            this.price_deal.Name = "price_deal";
            this.price_deal.Width = 40;
            // 
            // deal_type
            // 
            this.deal_type.HeaderText = "Type";
            this.deal_type.Name = "deal_type";
            this.deal_type.Width = 60;
            // 
            // like_deal
            // 
            this.like_deal.HeaderText = "Likes";
            this.like_deal.Name = "like_deal";
            this.like_deal.Width = 40;
            // 
            // cb_package
            // 
            this.cb_package.AutoSize = true;
            this.cb_package.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_package.Location = new System.Drawing.Point(239, 37);
            this.cb_package.Margin = new System.Windows.Forms.Padding(2);
            this.cb_package.Name = "cb_package";
            this.cb_package.Size = new System.Drawing.Size(69, 17);
            this.cb_package.TabIndex = 6;
            this.cb_package.Text = "Package";
            this.cb_package.UseVisualStyleBackColor = true;
            this.cb_package.CheckedChanged += new System.EventHandler(this.cb_package_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Search:";
            // 
            // tb_search
            // 
            this.tb_search.Location = new System.Drawing.Point(112, 4);
            this.tb_search.Margin = new System.Windows.Forms.Padding(2);
            this.tb_search.Name = "tb_search";
            this.tb_search.Size = new System.Drawing.Size(129, 20);
            this.tb_search.TabIndex = 4;
            this.tb_search.TextChanged += new System.EventHandler(this.tb_search_TextChanged);
            // 
            // cb_rauter
            // 
            this.cb_rauter.AutoSize = true;
            this.cb_rauter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_rauter.Location = new System.Drawing.Point(162, 37);
            this.cb_rauter.Margin = new System.Windows.Forms.Padding(2);
            this.cb_rauter.Name = "cb_rauter";
            this.cb_rauter.Size = new System.Drawing.Size(58, 17);
            this.cb_rauter.TabIndex = 3;
            this.cb_rauter.Text = "Rauter";
            this.cb_rauter.UseVisualStyleBackColor = true;
            this.cb_rauter.CheckedChanged += new System.EventHandler(this.cb_rauter_CheckedChanged);
            // 
            // cb_tablet
            // 
            this.cb_tablet.AutoSize = true;
            this.cb_tablet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_tablet.Location = new System.Drawing.Point(79, 37);
            this.cb_tablet.Margin = new System.Windows.Forms.Padding(2);
            this.cb_tablet.Name = "cb_tablet";
            this.cb_tablet.Size = new System.Drawing.Size(56, 17);
            this.cb_tablet.TabIndex = 2;
            this.cb_tablet.Text = "Tablet";
            this.cb_tablet.UseVisualStyleBackColor = true;
            this.cb_tablet.CheckedChanged += new System.EventHandler(this.cb_tablet_CheckedChanged);
            // 
            // cb_mobile
            // 
            this.cb_mobile.AutoSize = true;
            this.cb_mobile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_mobile.Location = new System.Drawing.Point(4, 37);
            this.cb_mobile.Margin = new System.Windows.Forms.Padding(2);
            this.cb_mobile.Name = "cb_mobile";
            this.cb_mobile.Size = new System.Drawing.Size(57, 17);
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
            this.dataGridView1.Location = new System.Drawing.Point(4, 81);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(305, 495);
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
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tab_product);
            this.tabControl1.Controls.Add(this.tab_order);
            this.tabControl1.Location = new System.Drawing.Point(1, 20);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(320, 604);
            this.tabControl1.TabIndex = 1;
            // 
            // main_system
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 634);
            this.Controls.Add(this.kb_exit);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "main_system";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "main_system";
            this.tab_product.ResumeLayout(false);
            this.tab_product.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview_package)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview_product)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview_deal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label kb_exit;
        private System.Windows.Forms.TabPage tab_order;
        private System.Windows.Forms.TabPage tab_product;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_search;
        private System.Windows.Forms.CheckBox cb_rauter;
        private System.Windows.Forms.CheckBox cb_tablet;
        private System.Windows.Forms.CheckBox cb_mobile;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.CheckBox cb_package;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewImageColumn image;
        private System.Windows.Forms.Label label_package;
        private System.Windows.Forms.Label label_product;
        private System.Windows.Forms.Label lb_deal;
        private System.Windows.Forms.DataGridView datagridview_package;
        private System.Windows.Forms.DataGridView datagridview_product;
        private System.Windows.Forms.DataGridView datagridview_deal;
        private System.Windows.Forms.Label lb_back;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_package;
        private System.Windows.Forms.DataGridViewTextBoxColumn name_package;
        private System.Windows.Forms.DataGridViewTextBoxColumn price_package;
        private System.Windows.Forms.DataGridViewTextBoxColumn type_package;
        private System.Windows.Forms.DataGridViewTextBoxColumn like_package;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_product;
        private System.Windows.Forms.DataGridViewTextBoxColumn name_product;
        private System.Windows.Forms.DataGridViewTextBoxColumn price_product;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn like_product;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_deal;
        private System.Windows.Forms.DataGridViewTextBoxColumn name_deal;
        private System.Windows.Forms.DataGridViewTextBoxColumn price_deal;
        private System.Windows.Forms.DataGridViewTextBoxColumn deal_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn like_deal;
    }
}