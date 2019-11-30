namespace Asynchronous
{
    partial class AsynchronousForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.SortButton = new System.Windows.Forms.Button();
            this.SortResults = new System.Windows.Forms.TextBox();
            this.UrlBox = new System.Windows.Forms.GroupBox();
            this.UrlTextBox = new System.Windows.Forms.TextBox();
            this.UrlButton = new System.Windows.Forms.Button();
            this.DownloadResultTextBox = new System.Windows.Forms.TextBox();
            this.DownloadGroupBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.UrlBox.SuspendLayout();
            this.DownloadGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(10, 10);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(10);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.SortResults);
            this.splitContainer1.Panel1.Controls.Add(this.SortButton);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DownloadGroupBox);
            this.splitContainer1.Panel2.Controls.Add(this.UrlButton);
            this.splitContainer1.Panel2.Controls.Add(this.UrlBox);
            this.splitContainer1.Size = new System.Drawing.Size(780, 430);
            this.splitContainer1.SplitterDistance = 378;
            this.splitContainer1.SplitterWidth = 20;
            this.splitContainer1.TabIndex = 0;
            // 
            // SortButton
            // 
            this.SortButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.SortButton.Location = new System.Drawing.Point(0, 0);
            this.SortButton.Margin = new System.Windows.Forms.Padding(10);
            this.SortButton.Name = "SortButton";
            this.SortButton.Size = new System.Drawing.Size(378, 36);
            this.SortButton.TabIndex = 0;
            this.SortButton.Text = "Go(sort)";
            this.SortButton.UseVisualStyleBackColor = true;
            // 
            // SortResults
            // 
            this.SortResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SortResults.Location = new System.Drawing.Point(0, 36);
            this.SortResults.Margin = new System.Windows.Forms.Padding(10);
            this.SortResults.Multiline = true;
            this.SortResults.Name = "SortResults";
            this.SortResults.Size = new System.Drawing.Size(378, 394);
            this.SortResults.TabIndex = 1;
            // 
            // UrlBox
            // 
            this.UrlBox.Controls.Add(this.UrlTextBox);
            this.UrlBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.UrlBox.Location = new System.Drawing.Point(0, 0);
            this.UrlBox.Name = "UrlBox";
            this.UrlBox.Size = new System.Drawing.Size(382, 54);
            this.UrlBox.TabIndex = 0;
            this.UrlBox.TabStop = false;
            this.UrlBox.Text = "URL";
            // 
            // UrlTextBox
            // 
            this.UrlTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UrlTextBox.Location = new System.Drawing.Point(3, 18);
            this.UrlTextBox.Name = "UrlTextBox";
            this.UrlTextBox.Size = new System.Drawing.Size(376, 22);
            this.UrlTextBox.TabIndex = 0;
            // 
            // UrlButton
            // 
            this.UrlButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.UrlButton.Location = new System.Drawing.Point(0, 54);
            this.UrlButton.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.UrlButton.Name = "UrlButton";
            this.UrlButton.Size = new System.Drawing.Size(382, 30);
            this.UrlButton.TabIndex = 1;
            this.UrlButton.Text = "Go(download string from URL)";
            this.UrlButton.UseVisualStyleBackColor = true;
            // 
            // DownloadResultTextBox
            // 
            this.DownloadResultTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DownloadResultTextBox.Location = new System.Drawing.Point(10, 25);
            this.DownloadResultTextBox.Multiline = true;
            this.DownloadResultTextBox.Name = "DownloadResultTextBox";
            this.DownloadResultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DownloadResultTextBox.Size = new System.Drawing.Size(362, 311);
            this.DownloadResultTextBox.TabIndex = 1;
            // 
            // DownloadGroupBox
            // 
            this.DownloadGroupBox.Controls.Add(this.DownloadResultTextBox);
            this.DownloadGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DownloadGroupBox.Location = new System.Drawing.Point(0, 84);
            this.DownloadGroupBox.Margin = new System.Windows.Forms.Padding(10);
            this.DownloadGroupBox.Name = "DownloadGroupBox";
            this.DownloadGroupBox.Padding = new System.Windows.Forms.Padding(10);
            this.DownloadGroupBox.Size = new System.Drawing.Size(382, 346);
            this.DownloadGroupBox.TabIndex = 2;
            this.DownloadGroupBox.TabStop = false;
            this.DownloadGroupBox.Text = "Download Result (as string)";
            // 
            // AsynchronousForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "AsynchronousForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Asynchronous Methods";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.UrlBox.ResumeLayout(false);
            this.UrlBox.PerformLayout();
            this.DownloadGroupBox.ResumeLayout(false);
            this.DownloadGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button SortButton;
        private System.Windows.Forms.TextBox SortResults;
        private System.Windows.Forms.GroupBox UrlBox;
        private System.Windows.Forms.TextBox UrlTextBox;
        private System.Windows.Forms.Button UrlButton;
        private System.Windows.Forms.TextBox DownloadResultTextBox;
        private System.Windows.Forms.GroupBox DownloadGroupBox;
    }
}

