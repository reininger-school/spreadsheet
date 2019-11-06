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
            else if (e.PropertyName == "BGColor")
            {
                visibleCell.Style.BackColor = System.Drawing.Color.FromArgb((int)cell.BGColor);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.sheet.Demo();
        }

        // Set visible cell to cell's text when editing
        private void DataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            var cell = this.sheet.GetCell(e.RowIndex, e.ColumnIndex);
            var visibleCell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            visibleCell.Value = cell.Text;
        }

        // set visble cell to cell value when finished editing text.
        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var cell = this.sheet.GetCell(e.RowIndex, e.ColumnIndex);
            var visibleCell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            this.sheet.SetCellText(cell, (string)visibleCell.Value);
            visibleCell.Value = cell.Value;
        }

        // Open color dialog box
        private void ChangeBackgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.colorDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (DataGridViewCell it in this.dataGridView1.SelectedCells)
                {
                    this.sheet.SetCellBGColor(this.sheet.GetCell(it.RowIndex, it.ColumnIndex), (uint)this.colorDialog1.Color.ToArgb());
                }
            }
        }

        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
    }
}
