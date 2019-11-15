// Reid Reininger
// 11512839
namespace Cpts321
{
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using NUnit.Framework;

    /// <summary>
    /// Tests for cell class.
    /// </summary>
    [TestFixture]
    public class TestCell
    {
        /// <summary>
        /// Default string for cell for testing purposes.
        /// </summary>
        private const string DefaultString = "Default String";

        /// <summary>
        /// Default uint for cell testing purposes.
        /// </summary>
        private const uint DefaultUint = 0xffffffff;

        /// <summary>
        /// Cell for testing.
        /// </summary>
        private Cell cell;

        /// <summary>
        /// Reset cell.
        /// </summary>
        [SetUp]
        public void NewCell()
        {
            this.cell = new MockCell(0, 0); // Minimal concrete class for testing
            Utility.GetProperty<Cell>("Text").SetValue(this.cell, DefaultString);
            Utility.GetProperty<Cell>("BGColor").SetValue(this.cell, DefaultUint);
        }

        /// <summary>
        /// Test valid input for Cell constructor.
        /// </summary>
        /// <param name="rowIndex">Cells' row index.</param>
        /// <param name="columnIndex">Cell's column index.</param>
        [TestCase(0, 0)]
        [TestCase(0, 1)]
        [TestCase(1, 0)]
        [TestCase(1, 1)]
        [TestCase(2, 3)]
        public void TestCellConstructorValidInput(int rowIndex, int columnIndex)
        {
            var cell = new MockCell(rowIndex, columnIndex);
            Assert.AreEqual(cell.RowIndex, rowIndex, "Incorrect row");
            Assert.AreEqual(cell.ColumnIndex, columnIndex, "Incorrect column");
        }

        /// <summary>
        /// Test invalid input for Cell constructor.
        /// </summary>
        /// <param name="rowIndex">Cell's row index.</param>
        /// <param name="columnIndex">Cell's column index.</param>
        [TestCase(0, -1)]
        [TestCase(-1, 0)]
        [TestCase(-1, -1)]
        public void TestCellConstructorInvalidInput(int rowIndex, int columnIndex)
        {
            Assert.Throws<ArgumentException>(() => new MockCell(rowIndex, columnIndex));
        }

        /// <summary>
        /// Test properties are readonly.
        /// </summary>
        /// <param name = "property">Property being tested.</param>
        [TestCase("RowIndex")]
        [TestCase("ColumnIndex")]
        public void TestReadOnlyProperties(string property)
        {
            Assert.IsFalse(typeof(Cell).GetProperty(property).CanWrite, $"Can set {property}");
            Assert.IsTrue(typeof(Cell).GetProperty(property).CanRead == true, $"Cannot get {property}");
        }

        /// <summary>
        /// Test properties have public get, nonpublic set.
        /// </summary>
        /// <param name="property">Property to test.</param>
        [TestCase("Text")]
        [TestCase("Value")]
        [TestCase("BGColor")]
        public void TestProtectedSetProperties(string property)
        {
            var methodInfo = Utility.GetProperty<Cell>(property);
            Assert.IsTrue(methodInfo.GetGetMethod(true).IsPublic, $"{property} getter is not public");
            Assert.IsFalse(methodInfo.GetSetMethod(true).IsPublic, $"{property} setter is public");
        }

        /// <summary>
        /// Test PropertyChanged event fires when Text property changes.
        /// </summary>
        /// <param name="testString">String to change Text to.</param>
        /// <param name="fire">Whether PropertyChanged event should fire or not.</param>
        [TestCase(DefaultString, false)]
        [TestCase("a", true)]
        public void TestSetTextPropertyChanged(string testString, bool fire)
        {
            bool fired = false;
            void Cell_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                fired = true;
            }

            this.cell.PropertyChanged += Cell_PropertyChanged;
            var textInfo = Utility.GetProperty<Cell>("Text");
            textInfo.SetValue(this.cell, testString);
            Assert.AreEqual(fire, fired);
        }

        /// <summary>
        /// Test PropertyChanged event fires when BGColor property changes.
        /// </summary>
        /// <param name="testVal">String to change Text to.</param>
        /// <param name="fire">Whether PropertyChanged event should fire or not.</param>
        [TestCase(DefaultUint, false)]
        [TestCase(0x0000ffffU, true)]
        public void TestSetBGColorPropertyChanged(uint testVal, bool fire)
        {
            bool fired = false;
            void Cell_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                fired = true;
            }

            this.cell.PropertyChanged += Cell_PropertyChanged;
            var bGColorInfo = Utility.GetProperty<Cell>("BGColor");
            bGColorInfo.SetValue(this.cell, testVal);
            Assert.AreEqual(fire, fired);
        }

        /// <summary>
        /// Tests Cell implements INotifyPropertyChanged.
        /// </summary>
        [Test]
        public void TestImplementsINotifyPropertyChanged()
        {
            Assert.IsTrue(typeof(Cell).GetInterfaces().Contains(typeof(INotifyPropertyChanged)));
        }

        /// <summary>
        /// Test Cell is abstract class.
        /// </summary>
        [Test]
        public void TestIsAbstract()
        {
            Assert.IsTrue(typeof(Cell).IsAbstract);
        }

        /// <summary>
        /// Test Cell is public class.
        /// </summary>
        [Test]
        public void TestIsPublic()
        {
            Assert.IsTrue(typeof(Cell).IsPublic);
        }

        /// <summary>
        /// Test Value is same as Text when Text does not begin with a '='.
        /// </summary>
        /// <param name="text">Value of Text to test.</param>
        /// <param name="result">Whether Value should be the Same as Text.</param>
        [TestCase("", true)]
        [TestCase("a", true)]
        [TestCase("=", false)]
        [TestCase("=a", false)]
        public void TestValueIsText(string text, bool result)
        {
            var textInfo = Utility.GetProperty<Cell>("Text");
            var valueInfo = Utility.GetProperty<Cell>("Value");
            textInfo.SetValue(this.cell, text);
            bool same = textInfo.GetValue(this.cell) == valueInfo.GetValue(this.cell);
            Assert.IsTrue(same == result);
        }

        /// <summary>
        /// Test GetSchema always returns null.
        /// </summary>
        [Test]
        public void TestGetSchemaReturnNull()
        {
            Assert.IsNull(this.cell.GetSchema());
        }

        /// <summary>
        /// Test writing to non-null xml stream.
        /// </summary>
        [Test]
        public void TestXmlWriteNonNullWriter()
        {
            // setup mock stream
            const string mockFile = "temp.xml";
            StreamWriter stream = new StreamWriter(mockFile);
            XmlTextWriter writer = new XmlTextWriter(stream);

            Assert.DoesNotThrow(() => this.cell.WriteXml(writer));

            // cleanup
            writer.Close();
            File.Delete(mockFile);
        }

        /// <summary>
        /// Test writing to null XmlWriter.
        /// </summary>
        [Test]
        public void TestXmlWriteNullWriter()
        {
            Assert.Throws<ArgumentNullException>(() => this.cell.WriteXml(null));
        }

        /// <summary>
        /// Test no exceptions thrown for non-null reader.
        /// </summary>
        [Test]
        public void TestXmlReadNonNull()
        {
            // setup mock stream
            const string mockFile = "temp.xml";
            StreamReader stream = new StreamReader(mockFile);
            XmlTextReader reader = new XmlTextReader(stream);

            Assert.DoesNotThrow(() => this.cell.ReadXml(reader));

            // cleanup
            reader.Close();
            File.Delete(mockFile);
        }

        /// <summary>
        /// Test null reader.
        /// </summary>
        [Test]
        public void TestXmlReadNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.cell.ReadXml(null));
        }
    }
}
