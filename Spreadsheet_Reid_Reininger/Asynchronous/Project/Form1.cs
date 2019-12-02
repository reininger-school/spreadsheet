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
    }
}
