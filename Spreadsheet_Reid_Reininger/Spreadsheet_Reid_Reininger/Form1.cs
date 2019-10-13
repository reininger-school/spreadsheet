/*
Author: Reid Reininger
Student ID: 11512839
*/
namespace Spreadsheet_Reid_Reininger
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// UI code for spreadsheet application.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataGridViewRow newRow; // ref for adding rows to grid

            // add columns A-Z
            this.dataGridView1.Columns.Clear();
            for (char i = 'A'; i <= 'Z'; i++)
            {
                this.dataGridView1.Columns.Add(i.ToString(), i.ToString());
            }

            // add rows 1-50
            this.dataGridView1.Rows.Clear();
            for (int i = 1; i <= 50; i++)
            {
                newRow = new DataGridViewRow();
                newRow.HeaderCell.Value = i.ToString();
                this.dataGridView1.Rows.Add(newRow);
            }
        }
    }
}
