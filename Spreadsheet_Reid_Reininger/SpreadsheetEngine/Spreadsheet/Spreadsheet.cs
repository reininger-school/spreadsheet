﻿// Reid Reininger
// 11512839
namespace Cpts321
{
    using SpreadsheetEngine;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// Contains all cells.
    /// </summary>
    public class Spreadsheet : INotifyPropertyChanged, IXmlSerializable
    {
        private Cell[,] cells;
        private ExpressionTree tree = new ExpressionTree("1");
        private CommandManager commandManager = new CommandManager();

        /// <summary>
        /// Initializes a new instance of the <see cref="Spreadsheet"/> class.
        /// </summary>
        /// <param name="rows">Number of rows.</param>
        /// <param name="columns">Number of columns.</param>
        public Spreadsheet(int rows, int columns)
        {
            // subscribe to CommandManage PropertyChanged.
            this.commandManager.PropertyChanged += this.CommandManager_PropertyChanged;

            this.cells = new Cell[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    this.cells[i, j] = CreateCell(CellType.Text, i, j);

                    // subscribe Spreadsheet to Cell's PropertyChanged event
                    this.cells[i, j].PropertyChanged += this.Cell_PropertyChanged;
                }
            }
        }

        /// <summary>
        /// Fires whenever a cell's property changes.
        /// </summary>
        public event PropertyChangedEventHandler CellPropertyChanged;

        /// <summary>
        /// Fire when property changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Types of Cells.
        /// </summary>
        public enum CellType
        {
            /// <summary>
            /// Cell with text value.
            /// </summary>
            Text,
        }

        /// <summary>
        /// Gets description of current redo operation.
        /// </summary>
        public string RedoDescription
        {
            get => this.commandManager.RedoDescription;
        }

        /// <summary>
        /// Gets description of current undo operation.
        /// </summary>
        public string UndoDescription
        {
            get => this.commandManager.UndoDescription;
        }

        /// <summary>
        /// Gets a value indicating whether undos are available.
        /// </summary>
        public bool Undos
        {
            get => this.commandManager.Undos;
        }

        /// <summary>
        /// Gets a value indicating whether redos are available.
        /// </summary>
        public bool Redos
        {
            get => this.commandManager.Redos;
        }

        /// <summary>
        /// Gets number of rows in Spreadsheet.
        /// </summary>
        public int RowCount
        {
            get => this.cells.GetLength(0);
        }

        /// <summary>
        /// Gets number of columns in Spreadsheet.
        /// </summary>
        public int ColumnCount
        {
            get => this.cells.GetLength(1);
        }

        /// <summary>
        /// Creates a cell of the given type.
        /// </summary>
        /// <param name="type">Type of cell to create.</param>
        /// <param name="row">Cell's row.</param>
        /// <param name="column">Cell's column.</param>
        /// <returns>New instance of cell type.</returns>
        public static Cell CreateCell(CellType type, int row, int column)
        {
            switch (type)
            {
                case CellType.Text:
                    return new TextCell(row, column);
                default:
                    return null;
            }
        }

        /// <summary>
        /// Gets cell at row and column.
        /// </summary>
        /// <param name="row">Cell's row.</param>
        /// <param name="column">Cell's column.</param>
        /// <returns>Reference to cell.</returns>
        public Cell GetCell(int row, int column)
        {
            // check row and column are not out of bounds.
            if (row < 0 || column < 0 || row >= this.RowCount || column >= this.ColumnCount)
            {
                return null;
            }

            return this.cells[row, column];
        }

        /// <summary>
        /// Gets cell with given name.
        /// </summary>
        /// <param name="name">Name of cell.</param>
        /// <returns>Cell with name.</returns>
        /// TODO: String parsing is clumsy and specific.
        public Cell GetCell(string name)
        {
            int row = 0, column = 0;
            row = int.Parse(Regex.Split(name, @"\D+")[1]) - 1;
            column = this.ConvertLetters(Regex.Split(name, @"\d+")[0]);
            return this.GetCell(row, column);
        }

        /// <summary>
        /// Set Cell's text.
        /// </summary>
        /// <param name="cell">Cell to change.</param>
        /// <param name="text">New Text value.</param>
        public void SetCellText(Cell cell, string text)
        {
            // Do nothing if text the same
            if (cell.Text == text)
            {
                return;
            }

            // create command
            this.commandManager.Execute(new ChangeTextCommand(cell, text));
        }

        /// <summary>
        /// Set Cells background color.
        /// </summary>
        /// <param name="cell">Cell to modify.</param>
        /// <param name="color">uint representation of color.</param>
        public void SetCellBGColor(Cell cell, uint color)
        {
            this.SetCellBGColor(new Cell[] { cell }, color);
        }

        /// <summary>
        /// Set Cells' background color.
        /// </summary>
        /// <param name="cells">Cells to modify.</param>
        /// <param name="color">uint representation of color.</param>
        public void SetCellBGColor(Cell[] cells, uint color)
        {
            // do nothing if color the same
            if (cells.All((cell) => cell.BGColor == color))
            {
                return;
            }

            // create command
            this.commandManager.Execute(new ChangeBGColorCommand(cells, color));
        }

        /// <summary>
        /// Undo most recent change on undos stack.
        /// </summary>
        public void Undo()
        {
            this.commandManager.Undo();
        }

        /// <summary>
        /// Redo most recently undone command.
        /// </summary>
        public void Redo()
        {
            this.commandManager.Redo();
        }

        /// <summary>
        /// Convert string of letters to integer value.
        /// </summary>
        /// <param name="name">string of capital letters.</param>
        /// <returns>Number associated with letter.</returns>
        /// TODO: Meant to treat letters as base 26 system, currently only works with one letter strings.
        public int ConvertLetters(string name)
        {
            int result = 0;
            int index = 1;
            var revName = name.Reverse<char>();
            foreach (char c in revName)
            {
                result += (int)Math.Pow(c - 'A', index++);
            }

            return result;
        }

        /// <summary>
        /// Demo of cell values updating in UI.
        /// </summary>
        public void Demo()
        {
            var random = new Random();
            int row = 0, column = 0;
            for (int i = 0; i < 50; i++)
            {
                row = random.Next(0, this.RowCount - 1);
                column = random.Next(0, this.ColumnCount - 1);
                this.GetCell(row, column).Text = "Hello, World!";
            }

            for (int i = 1; i <= this.RowCount; i++)
            {
                this.GetCell(i - 1, 1).Text = $"This is cell B{i}";
                this.GetCell(i - 1, 0).Text = $"=B{i}";
            }
        }

        /// <summary>
        /// Save spreadsheet in xml format to stream.
        /// </summary>
        /// <param name="stream">Stream to write spreadsheet data to.</param>
        public void SaveXml(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("Stream cannot be null");
            }

            XmlTextWriter writer = new XmlTextWriter(new StreamWriter(stream));
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement("Spreadsheet");
            this.WriteXml(writer);
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }

        /// <summary>
        /// Load spreadsheet data from .srr_xml file.
        /// </summary>
        /// <param name="stream">Stream to load data from.</param>
        public void LoadXml(Stream stream)
        {
            XmlTextReader reader = new XmlTextReader(new StreamReader(stream));
            this.ClearCellData();
            this.commandManager.ClearUndoRedos();

            // move to first element
            try
            {
                reader.MoveToContent();
            }

            // abort load if invalid xml
            catch
            {
                return;
            }

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name == "Cell")
                    {
                        if (reader.HasAttributes)
                        {
                            int row, column;

                            row = int.Parse(reader.GetAttribute("RowIndex"));
                            column = int.Parse(reader.GetAttribute("ColumnIndex"));
                            this.cells[row, column].ReadXml(reader);
                        }
                    }
                }
            }

            reader.Close();
        }

        /// <summary>
        /// Do not use. Should always return null.
        /// </summary>
        /// <returns>Null.</returns>
        public XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Read in spreadsheet data from xml file.
        /// </summary>
        /// <param name="reader">Reader for xml data.</param>
        public void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Write spreadsheet data to xml file.
        /// </summary>
        /// <param name="writer">Stream to writer xml data to.</param>
        public void WriteXml(XmlWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("Writer cannot be null");
            }

            Cell defaultCell = new TextCell(0, 0);
            foreach (Cell cell in this.cells)
            {
                bool dirtyText = cell.Text != defaultCell.Text;
                bool dirtyBGColor = cell.BGColor != defaultCell.BGColor;

                if (dirtyText || dirtyBGColor)
                {
                    writer.WriteStartElement("Cell");
                    writer.WriteAttributeString("RowIndex", cell.RowIndex.ToString());
                    writer.WriteAttributeString("ColumnIndex", cell.ColumnIndex.ToString());
                    cell.WriteXml(writer);
                    writer.WriteEndElement();
                }
            }
        }

        /// <summary>
        /// Sets cell's value when a property changes, and fires CellPropertyChanged event.
        /// </summary>
        /// <param name="sender">Changed cell.</param>
        /// <param name="e">Event args from changed cell.</param>
        private void Cell_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Cell cell = (Cell)sender;
            if (e.PropertyName == "Text" || e.PropertyName == "DependencyValue")
            {
                this.SetCellValue(cell);
            }

            this.CellPropertyChanged?.Invoke(sender, e);
        }

        private void CommandManager_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Redos")
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Redos"));
            }
            else if (e.PropertyName == "Undos")
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Undos"));
            }
        }

        /// <summary>
        /// Unsubscribe cell from all cells it depends on for formula, and remove from dependency list.
        /// </summary>
        /// <param name="cell">Cell to remove all subscriptions.</param>
        private void UnsubscribeCellDependencies(Cell cell)
        {
            foreach (var variable in cell.Dependencies)
            {
                this.GetCell(variable).PropertyChanged -= cell.Cell_PropertyChanged;
            }

            cell.Dependencies.Clear();
        }

        /// <summary>
        /// Sets all cell data to default.
        /// </summary>
        private void ClearCellData()
        {
            Cell defaultCell = Spreadsheet.CreateCell(CellType.Text, 0, 0);
            foreach (Cell cell in this.cells)
            {
                cell.Text = defaultCell.Text;
                cell.BGColor = defaultCell.BGColor;
            }
        }

        private bool CheckReferenceName(string name)
        {
            // check format
            if (Regex.IsMatch(name, @"^[A-Z][0-9]+$"))
            {
                int column = this.ConvertLetters(Regex.Match(name, @"[A-Z]+").Value);
                int row = int.Parse(Regex.Match(name, @"[0-9]+").Value);

                if (column < this.ColumnCount && row <= this.RowCount)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Check if cell is part of a cycle of dependencies.
        /// </summary>
        /// <param name="cell">Cell to check.</param>
        /// <returns>True if cell belongs to a cycle.</returns>
        private bool CheckCycle(Cell cell)
        {
            List<Cell> discovered = new List<Cell>();
            bool CheckCycleHelper(Cell node)
            {
                discovered.Add(node);
                foreach (string dependency in node.Dependencies)
                {
                    if (discovered.Contains(this.GetCell(dependency)))
                    {
                        return true;
                    }

                    if (CheckCycleHelper(this.GetCell(dependency)))
                    {
                        return true;
                    }
                }

                return false;
            }

            return CheckCycleHelper(cell);
        }

        private void SetCellValue(Cell cell)
        {
            this.UnsubscribeCellDependencies(cell);

            // if not formula do nothing
            if (string.IsNullOrWhiteSpace(cell.Text) || cell.Text[0] != '=')
            {
                return;
            }

            // get formula without whitespace
            string formula = Regex.Replace(cell.Text, @"\s", string.Empty);

            // if simple assignment
            if (Regex.IsMatch(formula, @"^=[A-Z]+[0-9]+$"))
            {
                // check reference to valid cell
                if (!this.CheckReferenceName(formula.Substring(1)))
                {
                    cell.Value = "!(invalid ref)";
                    return;
                }

                // check reference to self
                if (this.GetCell(formula.Substring(1)) == cell)
                {
                    cell.Value = "!(self ref)";
                    return;
                }

                // if ref to blank cell, set value to zero, otherwise cell value
                if (string.IsNullOrEmpty(this.GetCell(formula.Substring(1)).Value))
                {
                    cell.Value = "0";
                }
                else
                {
                    cell.Value = this.GetCell(formula.Substring(1)).Value;
                }

                // add reference to dependcies and check for cycle
                cell.Dependencies.Add(formula.Substring(1));
                if (this.CheckCycle(cell))
                {
                    cell.Value = "!(circular ref)";
                }

                this.GetCell(formula.Substring(1)).PropertyChanged += cell.Cell_PropertyChanged;
            }

            // if expression
            else
            {
                this.tree.Expression = formula.Substring(1);

                // set variable values in tree
                foreach (string variable in this.tree.Variables)
                {
                    if (!this.CheckReferenceName(variable))
                    {
                        cell.Value = "!(invalid ref)";
                        return;
                    }

                    if (this.GetCell(variable) == cell)
                    {
                        cell.Value = "!(self ref)";
                        return;
                    }

                    double value = 0;
                    double.TryParse(this.GetCell(variable).Value, out value);
                    this.tree.SetVariable(variable, value);

                    // subscribe cell to dependencies and check for cycle
                    cell.Dependencies.Add(variable);
                    if (this.CheckCycle(this.GetCell(variable)))
                    {
                        cell.Value = "!(circular ref)";
                    }

                    this.GetCell(variable).PropertyChanged += cell.Cell_PropertyChanged;
                }

                cell.Value = this.tree.Evaluate().ToString();
            }
        }
    }
}
