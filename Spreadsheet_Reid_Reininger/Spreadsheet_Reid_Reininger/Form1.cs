// Reid Reininger
// 11512839
namespace Spreadsheet_Reid_Reininger
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
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
            this.sheet.PropertyChanged += this.Sheet_PropertyChanged;

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
            if (e.PropertyName == "Text" || e.PropertyName == "Value")
            {
                visibleCell.Value = cell.Value;
            }
            else if (e.PropertyName == "BGColor")
            {
                visibleCell.Style.BackColor = System.Drawing.Color.FromArgb((int)cell.BGColor);
            }

            // update undo/redo text
            this.undoToolStripMenuItem.Text = "Undo " + this.sheet.UndoDescription;
            this.redoToolStripMenuItem.Text = "Redo " + this.sheet.RedoDescription;
        }

        private void Sheet_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Undos")
            {
                this.undoToolStripMenuItem.Enabled = this.sheet.Undos;
            }
            else if (e.PropertyName == "Redos")
            {
                this.redoToolStripMenuItem.Enabled = this.sheet.Redos;
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
                List<Cell> cells = new List<Cell>();
                foreach (DataGridViewCell visibleCell in this.dataGridView1.SelectedCells)
                {
                    cells.Add(this.sheet.GetCell(visibleCell.RowIndex, visibleCell.ColumnIndex));
                }

                this.sheet.SetCellBGColor(cells.ToArray(), (uint)this.colorDialog1.Color.ToArgb());
            }
        }

        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.sheet.Undo();
        }

        private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.sheet.Redo();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream savefile;
            this.saveFileDialog1.Filter = "Spreadsheet Reid Reininger files  (*.srr_xml)|*.srr_xml";
            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((savefile = this.saveFileDialog1.OpenFile()) != null)
                {
                    this.sheet.SaveXml(savefile);
                    savefile.Close();
                }
            }
        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream loadFile;
            this.openFileDialog1.Filter = "Spreadsheet Reid Reininger files  (*.srr_xml)|*.srr_xml";
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((loadFile = this.openFileDialog1.OpenFile()) != null)
                {
                    this.sheet.LoadXml(loadFile);
                    loadFile.Close();
                }
            }
        }
    }
}
