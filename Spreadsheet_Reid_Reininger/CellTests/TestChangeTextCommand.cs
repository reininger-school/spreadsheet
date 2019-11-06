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
        private Cell cell = new MockCell(0, 0);

        /// <summary>
        /// Test execute with valid parameters.
        /// </summary>
        [Test]
        public void TestValidExecute()
        {
            const string testString = "test string";
            var textInfo = Utility.GetProperty<Cell>("Text");
            var command = new ChangeTextCommand(this.cell, testString);
            command.Execute();

            Assert.AreEqual(testString, textInfo.GetValue(this.cell, null));
        }
    }
}
