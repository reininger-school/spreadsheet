using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spreadsheet_Reid_Reininger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.dataGridView1.Columns.Clear();
            //add columns A-Z
            for (char i = 'A'; i <= 'Z'; i++)
            {
                this.dataGridView1.Columns.Add(i.ToString(), i.ToString());
            }
        }
    }
}
