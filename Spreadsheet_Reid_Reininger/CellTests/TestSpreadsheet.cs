/*
Author: Reid Reininger
Student ID: 11512839
*/
namespace CellTests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Cpts321;
    using NUnit.Framework;

    /// <summary>
    /// Test suite for Spreadsheet.
    /// </summary>
    [TestFixture]
    public class TestSpreadsheet
    {
        /// <summary>
        /// Test constructor using valid input.
        /// </summary>
        /// <param name="rows">Rows in spreadsheet.</param>
        /// <param name="columns">Columns in spreadsheet.</param>
        [TestCase(0, 0)]
        [TestCase(0, 1)]
        [TestCase(1, 0)]
        [TestCase(1, 1)]
        public void TestConstructorValidInput(int rows, int columns)
        {
            var sheet = new Spreadsheet(rows, columns);
        }
    }
}
