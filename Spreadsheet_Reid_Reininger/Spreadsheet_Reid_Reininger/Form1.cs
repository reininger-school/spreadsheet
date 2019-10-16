// Reid Reininger
// 11512839
namespace Spreadsheet_Reid_Reininger
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using Cpts321;

    /// <summary>
    /// UI for spreadsheet application.
    /// </summary>
    public partial class Form1 : Form
    {
        private Spreadsheet sheet = new Spreadsheet(50, 26);

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
            this.sheet.CellPropertyChanged += this.Sheet_CellPropertyChanged;

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

        /// <summary>
        /// Change gridview to reflect changed cell property.
        /// </summary>
        /// <param name="sender">Changed cell.</param>
        /// <param name="e">Evenet args.</param>
        private void Sheet_CellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Cell cell = (Cell)sender;
            var visibleCell = this.dataGridView1.Rows[cell.RowIndex].Cells[cell.ColumnIndex];
            if (e.PropertyName == "Text")
            {
                visibleCell.Value = cell.Value;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.sheet.Demo();
        }
    }
}
