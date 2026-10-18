namespace BacaIn
{
    partial class BookDetailPage
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Releases owned components.
        /// </summary>
        /// <param name="disposing">Whether managed resources should be disposed.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle alternateStyle = new DataGridViewCellStyle();
            pageLayout = new TableLayoutPanel();
            headerLayout = new TableLayoutPanel();
            headingLabel = new Label();
            studentLabel = new Label();
            actionsLayout = new TableLayoutPanel();
            backButton = new Guna.UI2.WinForms.Guna2Button();
            detailPanel = new Guna.UI2.WinForms.Guna2Panel();
            cardLayout = new TableLayoutPanel();
            infoLayout = new TableLayoutPanel();
            coverPanel = new Guna.UI2.WinForms.Guna2Panel();
            coverPlaceholderLabel = new Label();
            metaLayout = new TableLayoutPanel();
            titleLabel = new Label();
            authorLabel = new Label();
            publisherLabel = new Label();
            yearLabel = new Label();
            isbnLabel = new Label();
            descriptionHeadingLabel = new Label();
            descriptionLabel = new Label();
            reservationLayout = new TableLayoutPanel();
            availabilityLabel = new Label();
            reserveButton = new Guna.UI2.WinForms.Guna2Button();
            copiesHeadingLabel = new Label();
            copiesGrid = new Guna.UI2.WinForms.Guna2DataGridView();
            barcodeColumn = new DataGridViewTextBoxColumn();
            conditionColumn = new DataGridViewTextBoxColumn();
            statusColumn = new DataGridViewTextBoxColumn();
            previewLabel = new Label();
            pageLayout.SuspendLayout();
            headerLayout.SuspendLayout();
            actionsLayout.SuspendLayout();
            detailPanel.SuspendLayout();
            cardLayout.SuspendLayout();
            infoLayout.SuspendLayout();
            coverPanel.SuspendLayout();
            metaLayout.SuspendLayout();
            reservationLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)copiesGrid).BeginInit();
            SuspendLayout();
            // 
            // pageLayout
            // 
            pageLayout.AutoScroll = true;
            pageLayout.ColumnCount = 1;
            pageLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pageLayout.Controls.Add(headerLayout, 0, 0);
            pageLayout.Controls.Add(actionsLayout, 0, 1);
            pageLayout.Controls.Add(detailPanel, 0, 2);
            pageLayout.Controls.Add(previewLabel, 0, 3);
            pageLayout.Dock = DockStyle.Fill;
            pageLayout.Margin = new Padding(0);
            pageLayout.MinimumSize = new Size(640, 500);
            pageLayout.Name = "pageLayout";
            pageLayout.Padding = new Padding(24);
            pageLayout.RowCount = 4;
            pageLayout.RowStyles.Add(new RowStyle());
            pageLayout.RowStyles.Add(new RowStyle());
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pageLayout.RowStyles.Add(new RowStyle());
            pageLayout.Size = new Size(1048, 800);
            pageLayout.TabIndex = 0;
            // 
            // headerLayout
            // 
            headerLayout.AutoSize = true;
            headerLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            headerLayout.ColumnCount = 2;
            headerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            headerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            headerLayout.Controls.Add(headingLabel, 0, 0);
            headerLayout.Controls.Add(studentLabel, 1, 0);
            headerLayout.Dock = DockStyle.Fill;
            headerLayout.Margin = new Padding(0, 0, 0, 12);
            headerLayout.Name = "headerLayout";
            headerLayout.RowCount = 1;
            headerLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            headerLayout.TabIndex = 0;
            // 
            // headingLabel
            // 
            headingLabel.AutoSize = true;
            headingLabel.Dock = DockStyle.Fill;
            headingLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            headingLabel.ForeColor = Color.FromArgb(36, 51, 46);
            headingLabel.Margin = new Padding(0);
            headingLabel.Name = "headingLabel";
            headingLabel.TabIndex = 0;
            headingLabel.Text = "View Book Detail";
            // 
            // studentLabel
            // 
            studentLabel.Anchor = AnchorStyles.Right;
            studentLabel.AutoSize = true;
            studentLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            studentLabel.ForeColor = Color.FromArgb(47, 93, 80);
            studentLabel.Margin = new Padding(0);
            studentLabel.Name = "studentLabel";
            studentLabel.TabIndex = 1;
            studentLabel.Text = "Student: Aji";
            studentLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // actionsLayout
            // 
            actionsLayout.AutoSize = true;
            actionsLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            actionsLayout.ColumnCount = 1;
            actionsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            actionsLayout.Controls.Add(backButton, 0, 0);
            actionsLayout.Dock = DockStyle.Fill;
            actionsLayout.Margin = new Padding(0, 0, 0, 16);
            actionsLayout.Name = "actionsLayout";
            actionsLayout.RowCount = 1;
            actionsLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            actionsLayout.TabIndex = 1;
            // 
            // backButton
            // 
            backButton.AccessibleName = "Back to catalog";
            backButton.AccessibleDescription = "Return to book catalog page";
            backButton.BorderColor = Color.FromArgb(120, 135, 126);
            backButton.BorderRadius = 6;
            backButton.BorderThickness = 1;
            backButton.FillColor = Color.White;
            backButton.FocusedColor = Color.FromArgb(47, 93, 80);
            backButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            backButton.ForeColor = Color.FromArgb(36, 51, 46);
            backButton.HoverState.BorderColor = Color.FromArgb(47, 93, 80);
            backButton.HoverState.FillColor = Color.FromArgb(229, 239, 232);
            backButton.Margin = new Padding(0);
            backButton.Name = "backButton";
            backButton.PressedColor = Color.FromArgb(36, 72, 62);
            backButton.Size = new Size(160, 38);
            backButton.TabIndex = 0;
            backButton.Text = "← Back to Catalog";
            backButton.Click += backButton_Click;
            // 
            // detailPanel
            // 
            detailPanel.BorderColor = Color.FromArgb(216, 223, 216);
            detailPanel.BorderRadius = 8;
            detailPanel.BorderThickness = 1;
            detailPanel.Controls.Add(cardLayout);
            detailPanel.Dock = DockStyle.Fill;
            detailPanel.FillColor = Color.White;
            detailPanel.Margin = new Padding(0);
            detailPanel.Name = "detailPanel";
            detailPanel.Padding = new Padding(20);
            detailPanel.Size = new Size(1000, 630);
            detailPanel.TabIndex = 2;
            // 
            // cardLayout
            // 
            cardLayout.AutoScroll = true;
            cardLayout.BackColor = Color.White;
            cardLayout.ColumnCount = 1;
            cardLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            cardLayout.Controls.Add(infoLayout, 0, 0);
            cardLayout.Controls.Add(reservationLayout, 0, 1);
            cardLayout.Controls.Add(copiesHeadingLabel, 0, 2);
            cardLayout.Controls.Add(copiesGrid, 0, 3);
            cardLayout.Dock = DockStyle.Fill;
            cardLayout.Margin = new Padding(0);
            cardLayout.Name = "cardLayout";
            cardLayout.RowCount = 4;
            cardLayout.RowStyles.Add(new RowStyle());
            cardLayout.RowStyles.Add(new RowStyle());
            cardLayout.RowStyles.Add(new RowStyle());
            cardLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            cardLayout.TabIndex = 0;
            // 
            // infoLayout
            // 
            infoLayout.AutoSize = true;
            infoLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            infoLayout.ColumnCount = 2;
            infoLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            infoLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            infoLayout.Controls.Add(coverPanel, 0, 0);
            infoLayout.Controls.Add(metaLayout, 1, 0);
            infoLayout.Dock = DockStyle.Fill;
            infoLayout.Margin = new Padding(0, 0, 0, 20);
            infoLayout.Name = "infoLayout";
            infoLayout.RowCount = 1;
            infoLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            infoLayout.TabIndex = 0;
            // 
            // coverPanel
            // 
            coverPanel.BorderColor = Color.FromArgb(216, 223, 216);
            coverPanel.BorderRadius = 6;
            coverPanel.BorderThickness = 1;
            coverPanel.Controls.Add(coverPlaceholderLabel);
            coverPanel.FillColor = Color.FromArgb(247, 248, 244);
            coverPanel.Margin = new Padding(0, 0, 16, 0);
            coverPanel.Name = "coverPanel";
            coverPanel.Size = new Size(135, 185);
            coverPanel.TabIndex = 0;
            // 
            // coverPlaceholderLabel
            // 
            coverPlaceholderLabel.Dock = DockStyle.Fill;
            coverPlaceholderLabel.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            coverPlaceholderLabel.ForeColor = Color.FromArgb(95, 111, 103);
            coverPlaceholderLabel.Location = new Point(0, 0);
            coverPlaceholderLabel.Margin = new Padding(0);
            coverPlaceholderLabel.Name = "coverPlaceholderLabel";
            coverPlaceholderLabel.Size = new Size(135, 185);
            coverPlaceholderLabel.TabIndex = 0;
            coverPlaceholderLabel.Text = "Book Cover";
            coverPlaceholderLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // metaLayout
            // 
            metaLayout.AutoSize = true;
            metaLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            metaLayout.ColumnCount = 1;
            metaLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            metaLayout.Controls.Add(titleLabel, 0, 0);
            metaLayout.Controls.Add(authorLabel, 0, 1);
            metaLayout.Controls.Add(publisherLabel, 0, 2);
            metaLayout.Controls.Add(yearLabel, 0, 3);
            metaLayout.Controls.Add(isbnLabel, 0, 4);
            metaLayout.Controls.Add(descriptionHeadingLabel, 0, 5);
            metaLayout.Controls.Add(descriptionLabel, 0, 6);
            metaLayout.Dock = DockStyle.Fill;
            metaLayout.Margin = new Padding(0);
            metaLayout.Name = "metaLayout";
            metaLayout.RowCount = 7;
            metaLayout.RowStyles.Add(new RowStyle());
            metaLayout.RowStyles.Add(new RowStyle());
            metaLayout.RowStyles.Add(new RowStyle());
            metaLayout.RowStyles.Add(new RowStyle());
            metaLayout.RowStyles.Add(new RowStyle());
            metaLayout.RowStyles.Add(new RowStyle());
            metaLayout.RowStyles.Add(new RowStyle());
            metaLayout.TabIndex = 1;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            titleLabel.ForeColor = Color.FromArgb(36, 51, 46);
            titleLabel.Margin = new Padding(0, 0, 0, 4);
            titleLabel.Name = "titleLabel";
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Laskar Pelangi";
            // 
            // authorLabel
            // 
            authorLabel.AutoSize = true;
            authorLabel.Font = new Font("Segoe UI", 10.5F);
            authorLabel.ForeColor = Color.FromArgb(95, 111, 103);
            authorLabel.Margin = new Padding(0, 0, 0, 4);
            authorLabel.Name = "authorLabel";
            authorLabel.TabIndex = 1;
            authorLabel.Text = "Author: Andrea Hirata";
            // 
            // publisherLabel
            // 
            publisherLabel.AutoSize = true;
            publisherLabel.Font = new Font("Segoe UI", 10.5F);
            publisherLabel.ForeColor = Color.FromArgb(95, 111, 103);
            publisherLabel.Margin = new Padding(0, 0, 0, 4);
            publisherLabel.Name = "publisherLabel";
            publisherLabel.TabIndex = 2;
            publisherLabel.Text = "Publisher: Bentang Pustaka";
            // 
            // yearLabel
            // 
            yearLabel.AutoSize = true;
            yearLabel.Font = new Font("Segoe UI", 10.5F);
            yearLabel.ForeColor = Color.FromArgb(95, 111, 103);
            yearLabel.Margin = new Padding(0, 0, 0, 4);
            yearLabel.Name = "yearLabel";
            yearLabel.TabIndex = 3;
            yearLabel.Text = "Publication year: 2005";
            // 
            // isbnLabel
            // 
            isbnLabel.AutoSize = true;
            isbnLabel.Font = new Font("Segoe UI", 10.5F);
            isbnLabel.ForeColor = Color.FromArgb(95, 111, 103);
            isbnLabel.Margin = new Padding(0, 0, 0, 10);
            isbnLabel.Name = "isbnLabel";
            isbnLabel.TabIndex = 4;
            isbnLabel.Text = "ISBN: 9789793062792";
            // 
            // descriptionHeadingLabel
            // 
            descriptionHeadingLabel.AutoSize = true;
            descriptionHeadingLabel.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            descriptionHeadingLabel.ForeColor = Color.FromArgb(36, 51, 46);
            descriptionHeadingLabel.Margin = new Padding(0, 0, 0, 4);
            descriptionHeadingLabel.Name = "descriptionHeadingLabel";
            descriptionHeadingLabel.TabIndex = 5;
            descriptionHeadingLabel.Text = "Description";
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Font = new Font("Segoe UI", 10F);
            descriptionLabel.ForeColor = Color.FromArgb(95, 111, 103);
            descriptionLabel.Margin = new Padding(0);
            descriptionLabel.MaximumSize = new Size(600, 0);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.TabIndex = 6;
            descriptionLabel.Text = "A story of friendship and education on Belitung Island.";
            // 
            // reservationLayout
            // 
            reservationLayout.AutoSize = true;
            reservationLayout.ColumnCount = 2;
            reservationLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            reservationLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            reservationLayout.Controls.Add(availabilityLabel, 0, 0);
            reservationLayout.Controls.Add(reserveButton, 1, 0);
            reservationLayout.Dock = DockStyle.Fill;
            reservationLayout.Margin = new Padding(0, 0, 0, 20);
            reservationLayout.Name = "reservationLayout";
            reservationLayout.RowCount = 1;
            reservationLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            reservationLayout.TabIndex = 1;
            // 
            // availabilityLabel
            // 
            availabilityLabel.Anchor = AnchorStyles.Left;
            availabilityLabel.AutoSize = true;
            availabilityLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            availabilityLabel.ForeColor = Color.FromArgb(47, 93, 80);
            availabilityLabel.Margin = new Padding(0);
            availabilityLabel.Name = "availabilityLabel";
            availabilityLabel.TabIndex = 0;
            availabilityLabel.Text = "Available copies: 2 of 4";
            // 
            // reserveButton
            // 
            reserveButton.AccessibleName = "Reserve book";
            reserveButton.AccessibleDescription = "Design preview action. Book reservation is not connected.";
            reserveButton.BorderColor = Color.FromArgb(47, 93, 80);
            reserveButton.BorderRadius = 6;
            reserveButton.BorderThickness = 1;
            reserveButton.FillColor = Color.FromArgb(47, 93, 80);
            reserveButton.FocusedColor = Color.FromArgb(36, 72, 62);
            reserveButton.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            reserveButton.ForeColor = Color.White;
            reserveButton.HoverState.FillColor = Color.FromArgb(36, 72, 62);
            reserveButton.Margin = new Padding(0);
            reserveButton.Name = "reserveButton";
            reserveButton.PressedColor = Color.FromArgb(36, 72, 62);
            reserveButton.Size = new Size(150, 40);
            reserveButton.TabIndex = 1;
            reserveButton.Text = "Reserve Book";
            // 
            // copiesHeadingLabel
            // 
            copiesHeadingLabel.AutoSize = true;
            copiesHeadingLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            copiesHeadingLabel.ForeColor = Color.FromArgb(36, 51, 46);
            copiesHeadingLabel.Margin = new Padding(0, 0, 0, 8);
            copiesHeadingLabel.Name = "copiesHeadingLabel";
            copiesHeadingLabel.TabIndex = 2;
            copiesHeadingLabel.Text = "Copies in Library";
            // 
            // copiesGrid
            // 
            copiesGrid.AccessibleName = "Book copies table";
            copiesGrid.AccessibleDescription = "Design preview table showing inventory copies, conditions, and availability.";
            copiesGrid.AllowUserToAddRows = false;
            copiesGrid.AllowUserToDeleteRows = false;
            copiesGrid.AllowUserToResizeRows = false;
            alternateStyle.BackColor = Color.FromArgb(247, 248, 244);
            copiesGrid.AlternatingRowsDefaultCellStyle = alternateStyle;
            copiesGrid.AutoGenerateColumns = false;
            copiesGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            copiesGrid.BackgroundColor = Color.White;
            copiesGrid.BorderStyle = BorderStyle.None;
            copiesGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            copiesGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = Color.FromArgb(229, 239, 232);
            headerStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            headerStyle.ForeColor = Color.FromArgb(36, 51, 46);
            headerStyle.SelectionBackColor = Color.FromArgb(229, 239, 232);
            headerStyle.SelectionForeColor = Color.FromArgb(36, 51, 46);
            headerStyle.WrapMode = DataGridViewTriState.True;
            copiesGrid.ColumnHeadersDefaultCellStyle = headerStyle;
            copiesGrid.ColumnHeadersHeight = 36;
            copiesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            copiesGrid.Columns.AddRange(new DataGridViewColumn[] {
            barcodeColumn,
            conditionColumn,
            statusColumn});
            cellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            cellStyle.BackColor = Color.White;
            cellStyle.Font = new Font("Segoe UI", 10F);
            cellStyle.ForeColor = Color.FromArgb(36, 51, 46);
            cellStyle.SelectionBackColor = Color.FromArgb(229, 239, 232);
            cellStyle.SelectionForeColor = Color.FromArgb(36, 51, 46);
            cellStyle.WrapMode = DataGridViewTriState.False;
            copiesGrid.DefaultCellStyle = cellStyle;
            copiesGrid.Dock = DockStyle.Fill;
            copiesGrid.EnableHeadersVisualStyles = false;
            copiesGrid.GridColor = Color.FromArgb(216, 223, 216);
            copiesGrid.Margin = new Padding(0);
            copiesGrid.MinimumSize = new Size(0, 180);
            copiesGrid.MultiSelect = false;
            copiesGrid.Name = "copiesGrid";
            copiesGrid.ReadOnly = true;
            copiesGrid.RowHeadersVisible = false;
            copiesGrid.RowTemplate.Height = 36;
            copiesGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            copiesGrid.TabIndex = 3;
            // 
            // barcodeColumn
            // 
            barcodeColumn.FillWeight = 150F;
            barcodeColumn.HeaderText = "Barcode";
            barcodeColumn.MinimumWidth = 120;
            barcodeColumn.Name = "barcodeColumn";
            barcodeColumn.ReadOnly = true;
            // 
            // conditionColumn
            // 
            conditionColumn.FillWeight = 150F;
            conditionColumn.HeaderText = "Condition";
            conditionColumn.MinimumWidth = 120;
            conditionColumn.Name = "conditionColumn";
            conditionColumn.ReadOnly = true;
            // 
            // statusColumn
            // 
            statusColumn.FillWeight = 150F;
            statusColumn.HeaderText = "Status";
            statusColumn.MinimumWidth = 120;
            statusColumn.Name = "statusColumn";
            statusColumn.ReadOnly = true;
            // 
            // previewLabel
            // 
            previewLabel.AutoSize = true;
            previewLabel.Dock = DockStyle.Fill;
            previewLabel.Font = new Font("Segoe UI", 10F);
            previewLabel.ForeColor = Color.FromArgb(95, 111, 103);
            previewLabel.Margin = new Padding(0, 12, 0, 0);
            previewLabel.Name = "previewLabel";
            previewLabel.TabIndex = 3;
            previewLabel.Text = "Design preview — book details and reservation actions are not connected.";
            // 
            // BookDetailPage
            // 
            AccessibleName = "Book Detail";
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(247, 248, 244);
            Controls.Add(pageLayout);
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(0);
            Name = "BookDetailPage";
            Size = new Size(1048, 800);
            pageLayout.ResumeLayout(false);
            pageLayout.PerformLayout();
            headerLayout.ResumeLayout(false);
            headerLayout.PerformLayout();
            actionsLayout.ResumeLayout(false);
            detailPanel.ResumeLayout(false);
            cardLayout.ResumeLayout(false);
            cardLayout.PerformLayout();
            infoLayout.ResumeLayout(false);
            infoLayout.PerformLayout();
            coverPanel.ResumeLayout(false);
            metaLayout.ResumeLayout(false);
            metaLayout.PerformLayout();
            reservationLayout.ResumeLayout(false);
            reservationLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)copiesGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel pageLayout;
        private TableLayoutPanel headerLayout;
        private Label headingLabel;
        private Label studentLabel;
        private TableLayoutPanel actionsLayout;
        private Guna.UI2.WinForms.Guna2Button backButton;
        private Guna.UI2.WinForms.Guna2Panel detailPanel;
        private TableLayoutPanel cardLayout;
        private TableLayoutPanel infoLayout;
        private Guna.UI2.WinForms.Guna2Panel coverPanel;
        private Label coverPlaceholderLabel;
        private TableLayoutPanel metaLayout;
        private Label titleLabel;
        private Label authorLabel;
        private Label publisherLabel;
        private Label yearLabel;
        private Label isbnLabel;
        private Label descriptionHeadingLabel;
        private Label descriptionLabel;
        private TableLayoutPanel reservationLayout;
        private Label availabilityLabel;
        private Guna.UI2.WinForms.Guna2Button reserveButton;
        private Label copiesHeadingLabel;
        private Guna.UI2.WinForms.Guna2DataGridView copiesGrid;
        private DataGridViewTextBoxColumn barcodeColumn;
        private DataGridViewTextBoxColumn conditionColumn;
        private DataGridViewTextBoxColumn statusColumn;
        private Label previewLabel;
    }
}
