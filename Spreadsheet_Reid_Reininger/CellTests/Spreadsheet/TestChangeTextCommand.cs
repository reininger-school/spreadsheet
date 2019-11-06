// Reid Reininger
// 11512839
namespace Cpts321
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;

    /// <summary>
    /// ChangeTextCommand test suite.
    /// </summary>
    [TestFixture]
    public class TestChangeTextCommand
    {
        private const string TestString = "test string";
        private Cell cell = new MockCell(0, 0);

        /// <summary>
        /// Test execute with valid parameters.
        /// </summary>
        [Test]
        public void TestValidExecute()
        {
            var command = new ChangeTextCommand(this.cell, TestString);
            command.Execute();

            Assert.AreEqual(TestString, this.cell.Text);
        }

        /// <summary>
        /// Test undo with valid parameters.
        /// </summary>
        [Test]
        public void TestValidUndo()
        {
            const string originalText = "original string";
            this.cell.Text = originalText;
            var command = new ChangeTextCommand(this.cell, TestString);
            command.Execute();
            command.Undo();
            Assert.AreEqual(originalText, this.cell.Text);
        }
    }
}
