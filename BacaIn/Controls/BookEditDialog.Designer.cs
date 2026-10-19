namespace BacaIn.Controls
{
    partial class BookEditDialog
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            mainLayout = new TableLayoutPanel();
            fieldsLayout = new TableLayoutPanel();
            isbnLabel = new Label();
            isbnLayout = new TableLayoutPanel();
            isbnTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            lookupButton = new Guna.UI2.WinForms.Guna2Button();
            titleLabel = new Label();
            titleTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            authorLabel = new Label();
            authorTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            publisherLabel = new Label();
            publisherTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            yearLabel = new Label();
            yearTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            descLabel = new Label();
            descTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            coverLabel = new Label();
            coverTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            copiesPanel = new Guna.UI2.WinForms.Guna2Panel();
            copiesLayout = new TableLayoutPanel();
            copiesHeaderLabel = new Label();
            addCopyLayout = new TableLayoutPanel();
            barcodeTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            conditionComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            addCopyButton = new Guna.UI2.WinForms.Guna2Button();
            copiesGrid = new Guna.UI2.WinForms.Guna2DataGridView();
            barcodeColumn = new DataGridViewTextBoxColumn();
            conditionColumn = new DataGridViewTextBoxColumn();
            statusColumn = new DataGridViewTextBoxColumn();
            removeColumn = new DataGridViewButtonColumn();
            bottomLayout = new FlowLayoutPanel();
            saveButton = new Guna.UI2.WinForms.Guna2Button();
            cancelButton = new Guna.UI2.WinForms.Guna2Button();
            statusMessageLabel = new Label();
            mainLayout.SuspendLayout();
            fieldsLayout.SuspendLayout();
            isbnLayout.SuspendLayout();
            copiesPanel.SuspendLayout();
            copiesLayout.SuspendLayout();
            addCopyLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)copiesGrid).BeginInit();
            bottomLayout.SuspendLayout();
            SuspendLayout();
            // 
            // mainLayout
            // 
            mainLayout.ColumnCount = 2;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            mainLayout.Controls.Add(fieldsLayout, 0, 0);
            mainLayout.Controls.Add(copiesPanel, 1, 0);
            mainLayout.Controls.Add(bottomLayout, 0, 1);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(0, 0);
            mainLayout.Name = "mainLayout";
            mainLayout.Padding = new Padding(20);
            mainLayout.RowCount = 2;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            mainLayout.Size = new Size(880, 560);
            mainLayout.TabIndex = 0;
            // 
            // fieldsLayout
            // 
            fieldsLayout.ColumnCount = 2;
            fieldsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            fieldsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            fieldsLayout.Controls.Add(isbnLabel, 0, 0);
            fieldsLayout.Controls.Add(isbnLayout, 1, 0);
            fieldsLayout.Controls.Add(titleLabel, 0, 1);
            fieldsLayout.Controls.Add(titleTextBox, 1, 1);
            fieldsLayout.Controls.Add(authorLabel, 0, 2);
            fieldsLayout.Controls.Add(authorTextBox, 1, 2);
            fieldsLayout.Controls.Add(publisherLabel, 0, 3);
            fieldsLayout.Controls.Add(publisherTextBox, 1, 3);
            fieldsLayout.Controls.Add(yearLabel, 0, 4);
            fieldsLayout.Controls.Add(yearTextBox, 1, 4);
            fieldsLayout.Controls.Add(descLabel, 0, 5);
            fieldsLayout.Controls.Add(descTextBox, 1, 5);
            fieldsLayout.Controls.Add(coverLabel, 0, 6);
            fieldsLayout.Controls.Add(coverTextBox, 1, 6);
            fieldsLayout.Dock = DockStyle.Fill;
            fieldsLayout.Location = new Point(23, 23);
            fieldsLayout.Name = "fieldsLayout";
            fieldsLayout.RowCount = 7;
            fieldsLayout.RowStyles.Add(new RowStyle());
            fieldsLayout.RowStyles.Add(new RowStyle());
            fieldsLayout.RowStyles.Add(new RowStyle());
            fieldsLayout.RowStyles.Add(new RowStyle());
            fieldsLayout.RowStyles.Add(new RowStyle());
            fieldsLayout.RowStyles.Add(new RowStyle());
            fieldsLayout.RowStyles.Add(new RowStyle());
            fieldsLayout.Size = new Size(456, 464);
            fieldsLayout.TabIndex = 0;
            // 
            // isbnLabel
            // 
            isbnLabel.Anchor = AnchorStyles.Left;
            isbnLabel.AutoSize = true;
            isbnLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            isbnLabel.ForeColor = Color.FromArgb(26, 26, 26);
            isbnLabel.Location = new Point(3, 10);
            isbnLabel.Name = "isbnLabel";
            isbnLabel.Size = new Size(41, 17);
            isbnLabel.TabIndex = 0;
            isbnLabel.Text = "ISBN:";
            // 
            // isbnLayout
            // 
            isbnLayout.ColumnCount = 2;
            isbnLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            isbnLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            isbnLayout.Controls.Add(isbnTextBox, 0, 0);
            isbnLayout.Controls.Add(lookupButton, 1, 0);
            isbnLayout.Dock = DockStyle.Fill;
            isbnLayout.Location = new Point(120, 0);
            isbnLayout.Margin = new Padding(0, 0, 0, 8);
            isbnLayout.Name = "isbnLayout";
            isbnLayout.RowCount = 1;
            isbnLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            isbnLayout.Size = new Size(336, 38);
            isbnLayout.TabIndex = 1;
            // 
            // isbnTextBox
            // 
            isbnTextBox.BorderColor = Color.FromArgb(128, 128, 128);
            isbnTextBox.BorderRadius = 4;
            isbnTextBox.DefaultText = "";
            isbnTextBox.Dock = DockStyle.Fill;
            isbnTextBox.Font = new Font("Segoe UI", 9.5F);
            isbnTextBox.Location = new Point(0, 0);
            isbnTextBox.Margin = new Padding(0, 0, 8, 0);
            isbnTextBox.Name = "isbnTextBox";
            isbnTextBox.PlaceholderText = "e.g. 9789793062792";
            isbnTextBox.Size = new Size(248, 38);
            isbnTextBox.TabIndex = 0;
            // 
            // lookupButton
            // 
            lookupButton.BorderColor = Color.FromArgb(57, 112, 41);
            lookupButton.BorderRadius = 4;
            lookupButton.BorderThickness = 1;
            lookupButton.FillColor = Color.FromArgb(239, 248, 236);
            lookupButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lookupButton.ForeColor = Color.FromArgb(57, 112, 41);
            lookupButton.Location = new Point(256, 0);
            lookupButton.Margin = new Padding(0);
            lookupButton.Name = "lookupButton";
            lookupButton.Size = new Size(80, 38);
            lookupButton.TabIndex = 1;
            lookupButton.Text = "Lookup";
            // 
            // titleLabel
            // 
            titleLabel.Anchor = AnchorStyles.Left;
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            titleLabel.ForeColor = Color.FromArgb(26, 26, 26);
            titleLabel.Location = new Point(3, 56);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(40, 17);
            titleLabel.TabIndex = 2;
            titleLabel.Text = "Title:";
            // 
            // titleTextBox
            // 
            titleTextBox.BorderColor = Color.FromArgb(128, 128, 128);
            titleTextBox.BorderRadius = 4;
            titleTextBox.DefaultText = "";
            titleTextBox.Dock = DockStyle.Fill;
            titleTextBox.Font = new Font("Segoe UI", 9.5F);
            titleTextBox.Location = new Point(120, 46);
            titleTextBox.Margin = new Padding(0, 0, 0, 8);
            titleTextBox.Name = "titleTextBox";
            titleTextBox.Size = new Size(336, 38);
            titleTextBox.TabIndex = 3;
            // 
            // authorLabel
            // 
            authorLabel.Anchor = AnchorStyles.Left;
            authorLabel.AutoSize = true;
            authorLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            authorLabel.ForeColor = Color.FromArgb(26, 26, 26);
            authorLabel.Location = new Point(3, 102);
            authorLabel.Name = "authorLabel";
            authorLabel.Size = new Size(55, 17);
            authorLabel.TabIndex = 4;
            authorLabel.Text = "Author:";
            // 
            // authorTextBox
            // 
            authorTextBox.BorderColor = Color.FromArgb(128, 128, 128);
            authorTextBox.BorderRadius = 4;
            authorTextBox.DefaultText = "";
            authorTextBox.Dock = DockStyle.Fill;
            authorTextBox.Font = new Font("Segoe UI", 9.5F);
            authorTextBox.Location = new Point(120, 92);
            authorTextBox.Margin = new Padding(0, 0, 0, 8);
            authorTextBox.Name = "authorTextBox";
            authorTextBox.Size = new Size(336, 38);
            authorTextBox.TabIndex = 5;
            // 
            // publisherLabel
            // 
            publisherLabel.Anchor = AnchorStyles.Left;
            publisherLabel.AutoSize = true;
            publisherLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            publisherLabel.ForeColor = Color.FromArgb(26, 26, 26);
            publisherLabel.Location = new Point(3, 148);
            publisherLabel.Name = "publisherLabel";
            publisherLabel.Size = new Size(69, 17);
            publisherLabel.TabIndex = 6;
            publisherLabel.Text = "Publisher:";
            // 
            // publisherTextBox
            // 
            publisherTextBox.BorderColor = Color.FromArgb(128, 128, 128);
            publisherTextBox.BorderRadius = 4;
            publisherTextBox.DefaultText = "";
            publisherTextBox.Dock = DockStyle.Fill;
            publisherTextBox.Font = new Font("Segoe UI", 9.5F);
            publisherTextBox.Location = new Point(120, 138);
            publisherTextBox.Margin = new Padding(0, 0, 0, 8);
            publisherTextBox.Name = "publisherTextBox";
            publisherTextBox.Size = new Size(336, 38);
            publisherTextBox.TabIndex = 7;
            // 
            // yearLabel
            // 
            yearLabel.Anchor = AnchorStyles.Left;
            yearLabel.AutoSize = true;
            yearLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            yearLabel.ForeColor = Color.FromArgb(26, 26, 26);
            yearLabel.Location = new Point(3, 194);
            yearLabel.Name = "yearLabel";
            yearLabel.Size = new Size(38, 17);
            yearLabel.TabIndex = 8;
            yearLabel.Text = "Year:";
            // 
            // yearTextBox
            // 
            yearTextBox.BorderColor = Color.FromArgb(128, 128, 128);
            yearTextBox.BorderRadius = 4;
            yearTextBox.DefaultText = "";
            yearTextBox.Dock = DockStyle.Fill;
            yearTextBox.Font = new Font("Segoe UI", 9.5F);
            yearTextBox.Location = new Point(120, 184);
            yearTextBox.Margin = new Padding(0, 0, 0, 8);
            yearTextBox.Name = "yearTextBox";
            yearTextBox.PlaceholderText = "e.g. 2024";
            yearTextBox.Size = new Size(336, 38);
            yearTextBox.TabIndex = 9;
            // 
            // descLabel
            // 
            descLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            descLabel.AutoSize = true;
            descLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            descLabel.ForeColor = Color.FromArgb(26, 26, 26);
            descLabel.Location = new Point(3, 233);
            descLabel.Margin = new Padding(3, 3, 0, 0);
            descLabel.Name = "descLabel";
            descLabel.Size = new Size(83, 17);
            descLabel.TabIndex = 10;
            descLabel.Text = "Description:";
            // 
            // descTextBox
            // 
            descTextBox.BorderColor = Color.FromArgb(128, 128, 128);
            descTextBox.BorderRadius = 4;
            descTextBox.DefaultText = "";
            descTextBox.Dock = DockStyle.Fill;
            descTextBox.Font = new Font("Segoe UI", 9.5F);
            descTextBox.Location = new Point(120, 230);
            descTextBox.Margin = new Padding(0, 0, 0, 8);
            descTextBox.Multiline = true;
            descTextBox.Name = "descTextBox";
            descTextBox.Size = new Size(336, 60);
            descTextBox.TabIndex = 11;
            // 
            // coverLabel
            // 
            coverLabel.Anchor = AnchorStyles.Left;
            coverLabel.AutoSize = true;
            coverLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            coverLabel.ForeColor = Color.FromArgb(26, 26, 26);
            coverLabel.Location = new Point(3, 308);
            coverLabel.Name = "coverLabel";
            coverLabel.Size = new Size(73, 17);
            coverLabel.TabIndex = 12;
            coverLabel.Text = "Cover URL:";
            // 
            // coverTextBox
            // 
            coverTextBox.BorderColor = Color.FromArgb(128, 128, 128);
            coverTextBox.BorderRadius = 4;
            coverTextBox.DefaultText = "";
            coverTextBox.Dock = DockStyle.Fill;
            coverTextBox.Font = new Font("Segoe UI", 9.5F);
            coverTextBox.Location = new Point(120, 298);
            coverTextBox.Margin = new Padding(0, 0, 0, 8);
            coverTextBox.Name = "coverTextBox";
            coverTextBox.PlaceholderText = "https://...";
            coverTextBox.Size = new Size(336, 38);
            coverTextBox.TabIndex = 13;
            // 
            // copiesPanel
            // 
            copiesPanel.BackColor = Color.White;
            copiesPanel.BorderColor = Color.FromArgb(204, 204, 204);
            copiesPanel.BorderRadius = 6;
            copiesPanel.BorderThickness = 1;
            copiesPanel.Controls.Add(copiesLayout);
            copiesPanel.Dock = DockStyle.Fill;
            copiesPanel.FillColor = Color.White;
            copiesPanel.Location = new Point(497, 23);
            copiesPanel.Margin = new Padding(15, 3, 3, 3);
            copiesPanel.Name = "copiesPanel";
            copiesPanel.Padding = new Padding(12);
            copiesPanel.Size = new Size(360, 464);
            copiesPanel.TabIndex = 1;
            // 
            // copiesLayout
            // 
            copiesLayout.ColumnCount = 1;
            copiesLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            copiesLayout.Controls.Add(copiesHeaderLabel, 0, 0);
            copiesLayout.Controls.Add(addCopyLayout, 0, 1);
            copiesLayout.Controls.Add(copiesGrid, 0, 2);
            copiesLayout.Dock = DockStyle.Fill;
            copiesLayout.Location = new Point(12, 12);
            copiesLayout.Name = "copiesLayout";
            copiesLayout.RowCount = 3;
            copiesLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            copiesLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            copiesLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            copiesLayout.Size = new Size(336, 440);
            copiesLayout.TabIndex = 0;
            // 
            // copiesHeaderLabel
            // 
            copiesHeaderLabel.AutoSize = true;
            copiesHeaderLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            copiesHeaderLabel.ForeColor = Color.FromArgb(26, 26, 26);
            copiesHeaderLabel.Location = new Point(0, 0);
            copiesHeaderLabel.Margin = new Padding(0, 0, 0, 8);
            copiesHeaderLabel.Name = "copiesHeaderLabel";
            copiesHeaderLabel.Size = new Size(130, 20);
            copiesHeaderLabel.TabIndex = 0;
            copiesHeaderLabel.Text = "Physical Copies";
            // 
            // addCopyLayout
            // 
            addCopyLayout.ColumnCount = 3;
            addCopyLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            addCopyLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            addCopyLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            addCopyLayout.Controls.Add(barcodeTextBox, 0, 0);
            addCopyLayout.Controls.Add(conditionComboBox, 1, 0);
            addCopyLayout.Controls.Add(addCopyButton, 2, 0);
            addCopyLayout.Dock = DockStyle.Fill;
            addCopyLayout.Location = new Point(0, 28);
            addCopyLayout.Margin = new Padding(0, 0, 0, 8);
            addCopyLayout.Name = "addCopyLayout";
            addCopyLayout.RowCount = 1;
            addCopyLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            addCopyLayout.Size = new Size(336, 36);
            addCopyLayout.TabIndex = 1;
            // 
            // barcodeTextBox
            // 
            barcodeTextBox.BorderColor = Color.FromArgb(128, 128, 128);
            barcodeTextBox.BorderRadius = 4;
            barcodeTextBox.DefaultText = "";
            barcodeTextBox.Dock = DockStyle.Fill;
            barcodeTextBox.Font = new Font("Segoe UI", 9F);
            barcodeTextBox.Location = new Point(0, 0);
            barcodeTextBox.Margin = new Padding(0, 0, 4, 0);
            barcodeTextBox.Name = "barcodeTextBox";
            barcodeTextBox.PlaceholderText = "Barcode";
            barcodeTextBox.Size = new Size(130, 36);
            barcodeTextBox.TabIndex = 0;
            // 
            // conditionComboBox
            // 
            conditionComboBox.BorderColor = Color.FromArgb(128, 128, 128);
            conditionComboBox.BorderRadius = 4;
            conditionComboBox.Dock = DockStyle.Fill;
            conditionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            conditionComboBox.Font = new Font("Segoe UI", 9F);
            conditionComboBox.Items.AddRange(new object[] { "NEW", "GOOD", "FAIR", "POOR" });
            conditionComboBox.Location = new Point(134, 0);
            conditionComboBox.Margin = new Padding(0, 0, 4, 0);
            conditionComboBox.Name = "conditionComboBox";
            conditionComboBox.Size = new Size(130, 36);
            conditionComboBox.StartIndex = 1;
            conditionComboBox.TabIndex = 1;
            // 
            // addCopyButton
            // 
            addCopyButton.BorderColor = Color.FromArgb(57, 112, 41);
            addCopyButton.BorderRadius = 4;
            addCopyButton.BorderThickness = 1;
            addCopyButton.FillColor = Color.FromArgb(57, 112, 41);
            addCopyButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            addCopyButton.ForeColor = Color.White;
            addCopyButton.Location = new Point(268, 0);
            addCopyButton.Margin = new Padding(0);
            addCopyButton.Name = "addCopyButton";
            addCopyButton.Size = new Size(68, 36);
            addCopyButton.TabIndex = 2;
            addCopyButton.Text = "Add";
            // 
            // copiesGrid
            // 
            copiesGrid.AllowUserToAddRows = false;
            copiesGrid.AllowUserToDeleteRows = false;
            copiesGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            copiesGrid.BackgroundColor = Color.White;
            copiesGrid.BorderStyle = BorderStyle.None;
            copiesGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = Color.FromArgb(242, 242, 242);
            headerStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            headerStyle.ForeColor = Color.FromArgb(26, 26, 26);
            headerStyle.SelectionBackColor = Color.FromArgb(242, 242, 242);
            headerStyle.SelectionForeColor = Color.FromArgb(26, 26, 26);
            copiesGrid.ColumnHeadersDefaultCellStyle = headerStyle;
            copiesGrid.ColumnHeadersHeight = 30;
            copiesGrid.Columns.AddRange(new DataGridViewColumn[] { barcodeColumn, conditionColumn, statusColumn, removeColumn });
            cellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            cellStyle.BackColor = Color.White;
            cellStyle.Font = new Font("Segoe UI", 9F);
            cellStyle.ForeColor = Color.FromArgb(26, 26, 26);
            cellStyle.SelectionBackColor = Color.FromArgb(223, 241, 218);
            cellStyle.SelectionForeColor = Color.FromArgb(26, 26, 26);
            copiesGrid.DefaultCellStyle = cellStyle;
            copiesGrid.Dock = DockStyle.Fill;
            copiesGrid.Location = new Point(0, 72);
            copiesGrid.Name = "copiesGrid";
            copiesGrid.RowHeadersVisible = false;
            copiesGrid.RowTemplate.Height = 28;
            copiesGrid.Size = new Size(336, 365);
            copiesGrid.TabIndex = 2;
            copiesGrid.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(223, 241, 218);
            copiesGrid.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(26, 26, 26);
            // 
            // barcodeColumn
            // 
            barcodeColumn.FillWeight = 40F;
            barcodeColumn.HeaderText = "Barcode";
            barcodeColumn.Name = "barcodeColumn";
            barcodeColumn.ReadOnly = true;
            // 
            // conditionColumn
            // 
            conditionColumn.FillWeight = 30F;
            conditionColumn.HeaderText = "Cond.";
            conditionColumn.Name = "conditionColumn";
            conditionColumn.ReadOnly = true;
            // 
            // statusColumn
            // 
            statusColumn.FillWeight = 30F;
            statusColumn.HeaderText = "Status";
            statusColumn.Name = "statusColumn";
            statusColumn.ReadOnly = true;
            // 
            // removeColumn
            // 
            removeColumn.FillWeight = 25F;
            removeColumn.HeaderText = "";
            removeColumn.Name = "removeColumn";
            removeColumn.Text = "Del";
            removeColumn.UseColumnTextForButtonValue = true;
            // 
            // bottomLayout
            // 
            mainLayout.SetColumnSpan(bottomLayout, 2);
            bottomLayout.Controls.Add(saveButton);
            bottomLayout.Controls.Add(cancelButton);
            bottomLayout.Controls.Add(statusMessageLabel);
            bottomLayout.Dock = DockStyle.Fill;
            bottomLayout.FlowDirection = FlowDirection.RightToLeft;
            bottomLayout.Location = new Point(23, 493);
            bottomLayout.Name = "bottomLayout";
            bottomLayout.Padding = new Padding(0, 10, 0, 0);
            bottomLayout.Size = new Size(834, 44);
            bottomLayout.TabIndex = 2;
            // 
            // saveButton
            // 
            saveButton.BorderColor = Color.FromArgb(57, 112, 41);
            saveButton.BorderRadius = 4;
            saveButton.BorderThickness = 1;
            saveButton.FillColor = Color.FromArgb(57, 112, 41);
            saveButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            saveButton.ForeColor = Color.White;
            saveButton.Location = new Point(734, 10);
            saveButton.Margin = new Padding(8, 0, 0, 0);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(100, 36);
            saveButton.TabIndex = 0;
            saveButton.Text = "Save Book";
            // 
            // cancelButton
            // 
            cancelButton.BorderColor = Color.FromArgb(128, 128, 128);
            cancelButton.BorderRadius = 4;
            cancelButton.BorderThickness = 1;
            cancelButton.FillColor = Color.White;
            cancelButton.Font = new Font("Segoe UI", 10F);
            cancelButton.ForeColor = Color.FromArgb(26, 26, 26);
            cancelButton.Location = new Point(626, 10);
            cancelButton.Margin = new Padding(0);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(100, 36);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "Cancel";
            // 
            // statusMessageLabel
            // 
            statusMessageLabel.Anchor = AnchorStyles.Left;
            statusMessageLabel.AutoSize = true;
            statusMessageLabel.Font = new Font("Segoe UI", 9.5F);
            statusMessageLabel.ForeColor = Color.FromArgb(153, 27, 27);
            statusMessageLabel.Location = new Point(571, 19);
            statusMessageLabel.Name = "statusMessageLabel";
            statusMessageLabel.Size = new Size(52, 17);
            statusMessageLabel.TabIndex = 2;
            statusMessageLabel.Text = "status...";
            statusMessageLabel.Visible = false;
            // 
            // BookEditDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 242, 242);
            ClientSize = new Size(880, 560);
            Controls.Add(mainLayout);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BookEditDialog";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add / Modify Book";
            mainLayout.ResumeLayout(false);
            fieldsLayout.ResumeLayout(false);
            fieldsLayout.PerformLayout();
            isbnLayout.ResumeLayout(false);
            copiesPanel.ResumeLayout(false);
            copiesLayout.ResumeLayout(false);
            copiesLayout.PerformLayout();
            addCopyLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)copiesGrid).EndInit();
            bottomLayout.ResumeLayout(false);
            bottomLayout.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel mainLayout;
        private TableLayoutPanel fieldsLayout;
        private Label isbnLabel;
        private TableLayoutPanel isbnLayout;
        private Guna.UI2.WinForms.Guna2TextBox isbnTextBox;
        private Guna.UI2.WinForms.Guna2Button lookupButton;
        private Label titleLabel;
        private Guna.UI2.WinForms.Guna2TextBox titleTextBox;
        private Label authorLabel;
        private Guna.UI2.WinForms.Guna2TextBox authorTextBox;
        private Label publisherLabel;
        private Guna.UI2.WinForms.Guna2TextBox publisherTextBox;
        private Label yearLabel;
        private Guna.UI2.WinForms.Guna2TextBox yearTextBox;
        private Label descLabel;
        private Guna.UI2.WinForms.Guna2TextBox descTextBox;
        private Label coverLabel;
        private Guna.UI2.WinForms.Guna2TextBox coverTextBox;
        private Guna.UI2.WinForms.Guna2Panel copiesPanel;
        private TableLayoutPanel copiesLayout;
        private Label copiesHeaderLabel;
        private TableLayoutPanel addCopyLayout;
        private Guna.UI2.WinForms.Guna2TextBox barcodeTextBox;
        private Guna.UI2.WinForms.Guna2ComboBox conditionComboBox;
        private Guna.UI2.WinForms.Guna2Button addCopyButton;
        private Guna.UI2.WinForms.Guna2DataGridView copiesGrid;
        private DataGridViewTextBoxColumn barcodeColumn;
        private DataGridViewTextBoxColumn conditionColumn;
        private DataGridViewTextBoxColumn statusColumn;
        private DataGridViewButtonColumn removeColumn;
        private FlowLayoutPanel bottomLayout;
        private Guna.UI2.WinForms.Guna2Button saveButton;
        private Guna.UI2.WinForms.Guna2Button cancelButton;
        private Label statusMessageLabel;
    }
}
