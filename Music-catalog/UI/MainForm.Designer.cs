namespace Music_catalog.UI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            buttonSearch = new Button();
            textBoxSearch = new TextBox();
            CatalogTabControl = new TabControl();
            tabPage1 = new TabPage();
            CatalogGridView = new DataGridView();
            tabPage2 = new TabPage();
            AlbumGridView = new DataGridView();
            tabPage3 = new TabPage();
            CollectionGridView = new DataGridView();
            tabPage4 = new TabPage();
            ArtistGridView = new DataGridView();
            tabPage5 = new TabPage();
            GenreGridView = new DataGridView();
            groupBox1 = new GroupBox();
            ClearButton = new Button();
            groupBox2 = new GroupBox();
            AddFormButton = new Button();
            CatalogTabControl.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CatalogGridView).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AlbumGridView).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CollectionGridView).BeginInit();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ArtistGridView).BeginInit();
            tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GenreGridView).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(6, 78);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(94, 29);
            buttonSearch.TabIndex = 0;
            buttonSearch.Text = "Найти";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += ButtonSearch_Click;
            // 
            // textBoxSearch
            // 
            textBoxSearch.Location = new Point(6, 26);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(226, 27);
            textBoxSearch.TabIndex = 1;
            // 
            // CatalogTabControl
            // 
            CatalogTabControl.Controls.Add(tabPage1);
            CatalogTabControl.Controls.Add(tabPage2);
            CatalogTabControl.Controls.Add(tabPage3);
            CatalogTabControl.Controls.Add(tabPage4);
            CatalogTabControl.Controls.Add(tabPage5);
            CatalogTabControl.Location = new Point(12, 12);
            CatalogTabControl.Name = "CatalogTabControl";
            CatalogTabControl.SelectedIndex = 0;
            CatalogTabControl.Size = new Size(600, 426);
            CatalogTabControl.TabIndex = 2;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(CatalogGridView);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(592, 393);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Каталог";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // CatalogGridView
            // 
            CatalogGridView.AllowUserToAddRows = false;
            CatalogGridView.AllowUserToDeleteRows = false;
            CatalogGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CatalogGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            CatalogGridView.BackgroundColor = SystemColors.ControlLight;
            CatalogGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CatalogGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            CatalogGridView.Location = new Point(3, 3);
            CatalogGridView.Name = "CatalogGridView";
            CatalogGridView.RowHeadersWidth = 51;
            CatalogGridView.Size = new Size(586, 387);
            CatalogGridView.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(AlbumGridView);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(592, 393);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Альбомы";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // AlbumGridView
            // 
            AlbumGridView.AllowUserToAddRows = false;
            AlbumGridView.AllowUserToDeleteRows = false;
            AlbumGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            AlbumGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            AlbumGridView.BackgroundColor = SystemColors.ControlLight;
            AlbumGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            AlbumGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            AlbumGridView.Location = new Point(3, 3);
            AlbumGridView.Name = "AlbumGridView";
            AlbumGridView.RowHeadersWidth = 51;
            AlbumGridView.Size = new Size(586, 387);
            AlbumGridView.TabIndex = 0;
            AlbumGridView.CellContentClick += DataGridView_CellContentClick;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(CollectionGridView);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(592, 393);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Сборники";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // CollectionGridView
            // 
            CollectionGridView.AllowUserToAddRows = false;
            CollectionGridView.AllowUserToDeleteRows = false;
            CollectionGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CollectionGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            CollectionGridView.BackgroundColor = SystemColors.ControlLight;
            CollectionGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CollectionGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            CollectionGridView.Location = new Point(3, 3);
            CollectionGridView.Name = "CollectionGridView";
            CollectionGridView.RowHeadersWidth = 51;
            CollectionGridView.Size = new Size(586, 387);
            CollectionGridView.TabIndex = 0;
            CollectionGridView.CellContentClick += DataGridView_CellContentClick;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(ArtistGridView);
            tabPage4.Location = new Point(4, 29);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(592, 393);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Исполнители";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // ArtistGridView
            // 
            ArtistGridView.AllowUserToAddRows = false;
            ArtistGridView.AllowUserToDeleteRows = false;
            ArtistGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ArtistGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ArtistGridView.BackgroundColor = SystemColors.ControlLight;
            ArtistGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ArtistGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            ArtistGridView.Location = new Point(3, 3);
            ArtistGridView.Name = "ArtistGridView";
            ArtistGridView.RowHeadersWidth = 51;
            ArtistGridView.Size = new Size(586, 387);
            ArtistGridView.TabIndex = 0;
            ArtistGridView.CellContentClick += DataGridView_CellContentClick;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(GenreGridView);
            tabPage5.Location = new Point(4, 29);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(592, 393);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Жанры";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // GenreGridView
            // 
            GenreGridView.AllowUserToAddRows = false;
            GenreGridView.AllowUserToDeleteRows = false;
            GenreGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            GenreGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GenreGridView.BackgroundColor = SystemColors.ControlLight;
            GenreGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GenreGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            GenreGridView.Location = new Point(3, 3);
            GenreGridView.Name = "GenreGridView";
            GenreGridView.RowHeadersWidth = 51;
            GenreGridView.Size = new Size(586, 387);
            GenreGridView.TabIndex = 0;
            GenreGridView.CellContentClick += DataGridView_CellContentClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(ClearButton);
            groupBox1.Controls.Add(textBoxSearch);
            groupBox1.Controls.Add(buttonSearch);
            groupBox1.Location = new Point(618, 41);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(273, 113);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Поиск";
            // 
            // ClearButton
            // 
            ClearButton.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ClearButton.Location = new Point(238, 25);
            ClearButton.Margin = new Padding(0);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(29, 29);
            ClearButton.TabIndex = 2;
            ClearButton.Text = "X";
            ClearButton.UseVisualStyleBackColor = true;
            ClearButton.Click += ClearButton_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(AddFormButton);
            groupBox2.Location = new Point(618, 172);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(273, 91);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Добавить запись";
            // 
            // AddFormButton
            // 
            AddFormButton.Location = new Point(173, 56);
            AddFormButton.Name = "AddFormButton";
            AddFormButton.Size = new Size(94, 29);
            AddFormButton.TabIndex = 5;
            AddFormButton.Text = "Добавить";
            AddFormButton.UseVisualStyleBackColor = true;
            AddFormButton.Click += AddFormButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(903, 450);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(CatalogTabControl);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Каталог музыки";
            CatalogTabControl.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)CatalogGridView).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)AlbumGridView).EndInit();
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)CollectionGridView).EndInit();
            tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ArtistGridView).EndInit();
            tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)GenreGridView).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button buttonSearch;
        private TextBox textBoxSearch;
        private TabControl CatalogTabControl;
        private TabPage tabPage1;
        private DataGridView CatalogGridView;
        private TabPage tabPage2;
        private DataGridView AlbumGridView;
        private TabPage tabPage3;
        private DataGridView CollectionGridView;
        private TabPage tabPage4;
        private DataGridView ArtistGridView;
        private GroupBox groupBox1;
        private Button ClearButton;
        private GroupBox groupBox2;
        private Button AddFormButton;
        private TabPage tabPage5;
        private DataGridView GenreGridView;
    }
}