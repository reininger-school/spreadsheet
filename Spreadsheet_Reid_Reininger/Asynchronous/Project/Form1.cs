// Reid Reininger
// 11512839
namespace Asynchronous
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Asynchronous;
    using System.Net;

    /// <summary>
    /// Application GUI.
    /// </summary>
    public partial class AsynchronousForm : Form
    {
        private IntListSorter sorter = new IntListSorter(8, 1_000_000);

        /// <summary>
        /// Initializes a new instance of the <see cref="AsynchronousForm"/> class.
        /// </summary>
        public AsynchronousForm()
        {
            this.InitializeComponent();
        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            this.SortButton.Enabled = false;
            Thread t = new Thread(() =>
            {
                this.sorter.Sort();
                this.SortButton.Enabled = true;
                this.SortResults.Text = $"Single-threaded time: {this.sorter.SingleThreadTime}\r\n";
                this.SortResults.AppendText($"Multi-threaded time: {this.sorter.MultiThreadTime}\r\n");
            });
            t.Start();
        }

        private void UrlButton_Click(object sender, EventArgs e)
        {
            this.UrlTextBox.Enabled = false;
            this.DownloadResultTextBox.Enabled = false;
            this.UrlButton.Enabled = false;
            Thread t = new Thread(() =>
            {
                this.DownloadResultTextBox.Text = new WebClient().DownloadString(this.UrlTextBox.Text.Trim());
                this.UrlTextBox.Enabled = true;
                this.DownloadResultTextBox.Enabled = true;
                this.UrlButton.Enabled = true;
            });
            t.Start();
        }
    }
}
