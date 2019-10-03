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
    using NUnit.Framework;

    /// <summary>
    /// Test suite for Spreadsheet.
    /// </summary>
    [TestFixture]
    public class TestSpreadsheet
    {
        [Test]
        public void TestMethod()
        {
            // TODO: Add your test code here
            var answer = 42;
            Assert.That(answer, Is.EqualTo(42), "Some useful error message");
        }
    }
}
