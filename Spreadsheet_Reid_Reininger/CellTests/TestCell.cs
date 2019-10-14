// Reid Reininger
// ID: 11512839

namespace CellTests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using System.Security.Permissions;
    using System.Text;
    using System.Threading.Tasks;
    using Cpts321;
    using NUnit.Framework;

    /// <summary>
    /// Tests for cell class.
    /// </summary>
    [TestFixture]
    public class TestCell
    {
        /// <summary>
        /// Cell for testing.
        /// </summary>
        private Cell cell = new MockCell(0, 0);

        /// <summary>
        /// Test valid input for Cell constructor.
        /// </summary>
        /// <param name="rowIndex">Cells' row index.</param>
        /// <param name="columnIndex">Cell's column index.</param>
        [TestCase(0, 0)] // Edge case, least possible indices
        [TestCase(0, 1)] // Edge case
        [TestCase(1, 0)] // Edge case
        [TestCase(1, 1)] // Edge case
        [TestCase(2, 3)] // Normal case
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
        /// Test properties are nonpublic.
        /// </summary>
        /// <param name="property">Property to test.</param>
        public void TestProtectedProperties(string property)
        {
            foreach (var element in typeof(Cell).GetProperty(property, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance).GetAccessors(true))
            {
                Assert.IsFalse(element.IsPublic, $"{element.Name} is public");
            }
        }

        /// <summary>
        /// Fail text when property changes.
        /// </summary>
        /// <param name="sender">Object firing event.</param>
        /// <param name="e">Event args.</param>
        

        /// <summary>
        /// Test PropertyChanged event is not fired when Text is set to same text.
        /// </summary>
        [Test]
        public void TestSetTextSame()
        {
            const string testString = "Test String";
            void Cell_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                Assert.Fail("PropertyChanged event fired");
            }

            var textInfo = this.GetProperty<Cell>("Text");
            textInfo.SetValue(this.cell, testString);
            this.cell.PropertyChanged += Cell_PropertyChanged;
            textInfo.SetValue(this.cell, testString);
        }

        /// <summary>
        /// Returns PropertyInfo of given type and property.
        /// </summary>
        /// <typeparam name="T">Class containing property to get.</typeparam>
        /// <param name="property">Property to be retrieved.</param>
        /// <returns>Property info.</returns>
        public PropertyInfo GetProperty<T>(string property)
        {
            if (string.IsNullOrWhiteSpace(property))
            {
                Assert.Fail("Property cannot be null or whitespace");
            }

            var propertyInfo = typeof(T).GetProperty(property, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
            if (propertyInfo == null)
            {
                Assert.Fail($"Could not find property {property}");
            }

            return propertyInfo;
        }

        /// <summary>
        /// Return MethodInfo for given method.
        /// </summary>
        /// <typeparam name="T">Class containg method.</typeparam>
        /// <param name="method">Name of method to get MethodInfo for.</param>
        /// <returns>MethodInfo of method in class T.</returns>
        public MethodInfo GetMethod<T>(string method)
        {
            if (string.IsNullOrWhiteSpace(method))
            {
                Assert.Fail("Method cannot be null or whitespace");
            }

            var methodInfo = typeof(T).GetMethod(method, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
            if (methodInfo == null)
            {
                Assert.Fail($"Could not find method {method}");
            }

            return methodInfo;
        }
    }
}
