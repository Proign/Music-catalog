namespace Music_catalog.UI
{
    partial class AddForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddForm));
            ArtistGroupBox = new GroupBox();
            GenreComboBox = new ComboBox();
            GenreLabel = new Label();
            ArtistNameTextBox = new TextBox();
            ArtistName = new Label();
            GenreGroupBox = new GroupBox();
            GenreTextBox = new TextBox();
            AddGenreLabel = new Label();
            AlbumGroupBox = new GroupBox();
            AlbumGenreComboBox = new ComboBox();
            label1 = new Label();
            GetArtistComboBox = new ComboBox();
            AlbumArtistLabel = new Label();
            AlbumTextBox = new TextBox();
            AddAlbumLabel = new Label();
            TrackGroupBox = new GroupBox();
            TrackDurationTextBox = new TextBox();
            TrackDurationLabel = new Label();
            GetAlbumComboBox = new ComboBox();
            TrackAlbumLabel = new Label();
            TrackArtistComboBox = new ComboBox();
            label3 = new Label();
            TrackNameTextBox = new TextBox();
            label4 = new Label();
            CollectionGroupBox = new GroupBox();
            CollectionCListBox = new CheckedListBox();
            CollectionTextBox = new TextBox();
            CollectionLabel = new Label();
            AddButton = new Button();
            ArtistGroupBox.SuspendLayout();
            GenreGroupBox.SuspendLayout();
            AlbumGroupBox.SuspendLayout();
            TrackGroupBox.SuspendLayout();
            CollectionGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // ArtistGroupBox
            // 
            ArtistGroupBox.Controls.Add(GenreComboBox);
            ArtistGroupBox.Controls.Add(GenreLabel);
            ArtistGroupBox.Controls.Add(ArtistNameTextBox);
            ArtistGroupBox.Controls.Add(ArtistName);
            ArtistGroupBox.Location = new Point(12, 97);
            ArtistGroupBox.Name = "ArtistGroupBox";
            ArtistGroupBox.Size = new Size(297, 127);
            ArtistGroupBox.TabIndex = 0;
            ArtistGroupBox.TabStop = false;
            ArtistGroupBox.Text = "2. Исполнитель";
            // 
            // GenreComboBox
            // 
            GenreComboBox.FormattingEnabled = true;
            GenreComboBox.Location = new Point(60, 78);
            GenreComboBox.Name = "GenreComboBox";
            GenreComboBox.Size = new Size(220, 28);
            GenreComboBox.TabIndex = 3;
            // 
            // GenreLabel
            // 
            GenreLabel.AutoSize = true;
            GenreLabel.Location = new Point(6, 81);
            GenreLabel.Name = "GenreLabel";
            GenreLabel.Size = new Size(48, 20);
            GenreLabel.TabIndex = 2;
            GenreLabel.Text = "Жанр";
            // 
            // ArtistNameTextBox
            // 
            ArtistNameTextBox.Location = new Point(60, 35);
            ArtistNameTextBox.Name = "ArtistNameTextBox";
            ArtistNameTextBox.Size = new Size(220, 27);
            ArtistNameTextBox.TabIndex = 1;
            // 
            // ArtistName
            // 
            ArtistName.AutoSize = true;
            ArtistName.Location = new Point(6, 38);
            ArtistName.Name = "ArtistName";
            ArtistName.Size = new Size(39, 20);
            ArtistName.TabIndex = 0;
            ArtistName.Text = "Имя";
            // 
            // GenreGroupBox
            // 
            GenreGroupBox.Controls.Add(GenreTextBox);
            GenreGroupBox.Controls.Add(AddGenreLabel);
            GenreGroupBox.Location = new Point(12, 12);
            GenreGroupBox.Name = "GenreGroupBox";
            GenreGroupBox.Size = new Size(297, 79);
            GenreGroupBox.TabIndex = 1;
            GenreGroupBox.TabStop = false;
            GenreGroupBox.Text = "1. Жанр";
            // 
            // GenreTextBox
            // 
            GenreTextBox.Location = new Point(89, 31);
            GenreTextBox.Name = "GenreTextBox";
            GenreTextBox.Size = new Size(191, 27);
            GenreTextBox.TabIndex = 4;
            // 
            // AddGenreLabel
            // 
            AddGenreLabel.AutoSize = true;
            AddGenreLabel.Location = new Point(6, 34);
            AddGenreLabel.Name = "AddGenreLabel";
            AddGenreLabel.Size = new Size(77, 20);
            AddGenreLabel.TabIndex = 3;
            AddGenreLabel.Text = "Название";
            // 
            // AlbumGroupBox
            // 
            AlbumGroupBox.Controls.Add(AlbumGenreComboBox);
            AlbumGroupBox.Controls.Add(label1);
            AlbumGroupBox.Controls.Add(GetArtistComboBox);
            AlbumGroupBox.Controls.Add(AlbumArtistLabel);
            AlbumGroupBox.Controls.Add(AlbumTextBox);
            AlbumGroupBox.Controls.Add(AddAlbumLabel);
            AlbumGroupBox.Location = new Point(12, 230);
            AlbumGroupBox.Name = "AlbumGroupBox";
            AlbumGroupBox.Size = new Size(297, 159);
            AlbumGroupBox.TabIndex = 2;
            AlbumGroupBox.TabStop = false;
            AlbumGroupBox.Text = "3. Альбом";
            // 
            // AlbumGenreComboBox
            // 
            AlbumGenreComboBox.FormattingEnabled = true;
            AlbumGenreComboBox.Location = new Point(113, 118);
            AlbumGenreComboBox.Name = "AlbumGenreComboBox";
            AlbumGenreComboBox.Size = new Size(167, 28);
            AlbumGenreComboBox.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 121);
            label1.Name = "label1";
            label1.Size = new Size(48, 20);
            label1.TabIndex = 8;
            label1.Text = "Жанр";
            // 
            // GetArtistComboBox
            // 
            GetArtistComboBox.FormattingEnabled = true;
            GetArtistComboBox.Location = new Point(113, 76);
            GetArtistComboBox.Name = "GetArtistComboBox";
            GetArtistComboBox.Size = new Size(167, 28);
            GetArtistComboBox.TabIndex = 7;
            // 
            // AlbumArtistLabel
            // 
            AlbumArtistLabel.AutoSize = true;
            AlbumArtistLabel.Location = new Point(6, 79);
            AlbumArtistLabel.Name = "AlbumArtistLabel";
            AlbumArtistLabel.Size = new Size(101, 20);
            AlbumArtistLabel.TabIndex = 6;
            AlbumArtistLabel.Text = "Исполнитель";
            // 
            // AlbumTextBox
            // 
            AlbumTextBox.Location = new Point(113, 33);
            AlbumTextBox.Name = "AlbumTextBox";
            AlbumTextBox.Size = new Size(167, 27);
            AlbumTextBox.TabIndex = 5;
            // 
            // AddAlbumLabel
            // 
            AddAlbumLabel.AutoSize = true;
            AddAlbumLabel.Location = new Point(6, 33);
            AddAlbumLabel.Name = "AddAlbumLabel";
            AddAlbumLabel.Size = new Size(77, 20);
            AddAlbumLabel.TabIndex = 0;
            AddAlbumLabel.Text = "Название";
            // 
            // TrackGroupBox
            // 
            TrackGroupBox.Controls.Add(TrackDurationTextBox);
            TrackGroupBox.Controls.Add(TrackDurationLabel);
            TrackGroupBox.Controls.Add(GetAlbumComboBox);
            TrackGroupBox.Controls.Add(TrackAlbumLabel);
            TrackGroupBox.Controls.Add(TrackArtistComboBox);
            TrackGroupBox.Controls.Add(label3);
            TrackGroupBox.Controls.Add(TrackNameTextBox);
            TrackGroupBox.Controls.Add(label4);
            TrackGroupBox.Location = new Point(331, 12);
            TrackGroupBox.Name = "TrackGroupBox";
            TrackGroupBox.Size = new Size(326, 212);
            TrackGroupBox.TabIndex = 3;
            TrackGroupBox.TabStop = false;
            TrackGroupBox.Text = "4. Трек";
            // 
            // TrackDurationTextBox
            // 
            TrackDurationTextBox.Location = new Point(122, 160);
            TrackDurationTextBox.Name = "TrackDurationTextBox";
            TrackDurationTextBox.Size = new Size(187, 27);
            TrackDurationTextBox.TabIndex = 19;
            // 
            // TrackDurationLabel
            // 
            TrackDurationLabel.AutoSize = true;
            TrackDurationLabel.Location = new Point(6, 163);
            TrackDurationLabel.Name = "TrackDurationLabel";
            TrackDurationLabel.Size = new Size(94, 20);
            TrackDurationLabel.TabIndex = 18;
            TrackDurationLabel.Text = "Длина (Сек.)";
            // 
            // GetAlbumComboBox
            // 
            GetAlbumComboBox.FormattingEnabled = true;
            GetAlbumComboBox.Location = new Point(122, 116);
            GetAlbumComboBox.Name = "GetAlbumComboBox";
            GetAlbumComboBox.Size = new Size(187, 28);
            GetAlbumComboBox.TabIndex = 17;
            // 
            // TrackAlbumLabel
            // 
            TrackAlbumLabel.AutoSize = true;
            TrackAlbumLabel.Location = new Point(6, 119);
            TrackAlbumLabel.Name = "TrackAlbumLabel";
            TrackAlbumLabel.Size = new Size(64, 20);
            TrackAlbumLabel.TabIndex = 16;
            TrackAlbumLabel.Text = "Альбом";
            // 
            // TrackArtistComboBox
            // 
            TrackArtistComboBox.FormattingEnabled = true;
            TrackArtistComboBox.Location = new Point(122, 73);
            TrackArtistComboBox.Name = "TrackArtistComboBox";
            TrackArtistComboBox.Size = new Size(187, 28);
            TrackArtistComboBox.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 76);
            label3.Name = "label3";
            label3.Size = new Size(101, 20);
            label3.TabIndex = 12;
            label3.Text = "Исполнитель";
            // 
            // TrackNameTextBox
            // 
            TrackNameTextBox.Location = new Point(122, 30);
            TrackNameTextBox.Name = "TrackNameTextBox";
            TrackNameTextBox.Size = new Size(187, 27);
            TrackNameTextBox.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 33);
            label4.Name = "label4";
            label4.Size = new Size(77, 20);
            label4.TabIndex = 10;
            label4.Text = "Название";
            // 
            // CollectionGroupBox
            // 
            CollectionGroupBox.Controls.Add(CollectionCListBox);
            CollectionGroupBox.Controls.Add(CollectionTextBox);
            CollectionGroupBox.Controls.Add(CollectionLabel);
            CollectionGroupBox.Location = new Point(331, 230);
            CollectionGroupBox.Name = "CollectionGroupBox";
            CollectionGroupBox.Size = new Size(326, 274);
            CollectionGroupBox.TabIndex = 4;
            CollectionGroupBox.TabStop = false;
            CollectionGroupBox.Text = "5. Сборник";
            // 
            // CollectionCListBox
            // 
            CollectionCListBox.FormattingEnabled = true;
            CollectionCListBox.Location = new Point(6, 110);
            CollectionCListBox.Name = "CollectionCListBox";
            CollectionCListBox.Size = new Size(314, 158);
            CollectionCListBox.TabIndex = 8;
            // 
            // CollectionTextBox
            // 
            CollectionTextBox.Location = new Point(6, 61);
            CollectionTextBox.Name = "CollectionTextBox";
            CollectionTextBox.Size = new Size(314, 27);
            CollectionTextBox.TabIndex = 7;
            // 
            // CollectionLabel
            // 
            CollectionLabel.AutoSize = true;
            CollectionLabel.Location = new Point(6, 38);
            CollectionLabel.Name = "CollectionLabel";
            CollectionLabel.Size = new Size(77, 20);
            CollectionLabel.TabIndex = 6;
            CollectionLabel.Text = "Название";
            // 
            // AddButton
            // 
            AddButton.Location = new Point(18, 475);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(139, 29);
            AddButton.TabIndex = 5;
            AddButton.Text = "Добавить";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // AddForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(666, 542);
            Controls.Add(AddButton);
            Controls.Add(CollectionGroupBox);
            Controls.Add(TrackGroupBox);
            Controls.Add(AlbumGroupBox);
            Controls.Add(GenreGroupBox);
            Controls.Add(ArtistGroupBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddForm";
            Text = "Добавление данных";
            ArtistGroupBox.ResumeLayout(false);
            ArtistGroupBox.PerformLayout();
            GenreGroupBox.ResumeLayout(false);
            GenreGroupBox.PerformLayout();
            AlbumGroupBox.ResumeLayout(false);
            AlbumGroupBox.PerformLayout();
            TrackGroupBox.ResumeLayout(false);
            TrackGroupBox.PerformLayout();
            CollectionGroupBox.ResumeLayout(false);
            CollectionGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox ArtistGroupBox;
        private TextBox ArtistNameTextBox;
        private Label ArtistName;
        private Label GenreLabel;
        private ComboBox GenreComboBox;
        private GroupBox GenreGroupBox;
        private Label AddGenreLabel;
        private GroupBox AlbumGroupBox;
        private Label AddAlbumLabel;
        private ComboBox AlbumGenreComboBox;
        private Label label1;
        private ComboBox GetArtistComboBox;
        private Label AlbumArtistLabel;
        private TextBox AlbumTextBox;
        private GroupBox TrackGroupBox;
        private ComboBox GetAlbumComboBox;
        private Label TrackAlbumLabel;
        private ComboBox TrackArtistComboBox;
        private Label label3;
        private TextBox TrackNameTextBox;
        private Label label4;
        private GroupBox CollectionGroupBox;
        private CheckedListBox CollectionCListBox;
        private TextBox CollectionTextBox;
        private Label CollectionLabel;
        private Button AddButton;
        private TextBox GenreTextBox;
        private Label TrackDurationLabel;
        private TextBox TrackDurationTextBox;
    }
}