// Reid Reininger
// 11512839
namespace Cpts321
{
    using NUnit.Framework;

    /// <summary>
    /// ChangeTextCommand test suite.
    /// </summary>
    [TestFixture]
    public class TestChangeBGColorCommand
    {
        private const uint TestColor = 0x0000FFFF;
        private Cell cell = new MockCell(0, 0);

        /// <summary>
        /// Test execute with valid parameters.
        /// </summary>
        [Test]
        public void TestValidExecute()
        {
            var command = new ChangeBGColorCommand(this.cell, TestColor);
            command.Execute();

            Assert.AreEqual(TestColor, this.cell.BGColor);
        }

        /// <summary>
        /// Test undo with valid parameters.
        /// </summary>
        [Test]
        public void TestValidUndo()
        {
            const uint originalColor = 0xffffffffU;
            this.cell.BGColor = originalColor;
            var command = new ChangeBGColorCommand(this.cell, TestColor);
            command.Execute();
            command.Undo();
            Assert.AreEqual(originalColor, this.cell.BGColor);
        }
    }
}