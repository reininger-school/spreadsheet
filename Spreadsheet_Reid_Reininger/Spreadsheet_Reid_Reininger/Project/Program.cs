/*
Author: Reid Reininger
Student ID: 11512839
*/
namespace Spreadsheet_Reid_Reininger
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Starts WinForm application.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
