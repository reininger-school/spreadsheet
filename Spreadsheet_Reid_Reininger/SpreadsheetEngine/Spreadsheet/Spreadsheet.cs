// Reid Reininger
// 11512839
namespace Cpts321
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Text.RegularExpressions;
    using SpreadsheetEngine;

    /// <summary>
    /// Contains all cells.
    /// </summary>
    public class Spreadsheet : INotifyPropertyChanged
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

        private void SetCellValue(Cell cell)
        {
            this.UnsubscribeCellDependencies(cell);

            // if formula
            if (!string.IsNullOrWhiteSpace(cell.Text) && cell.Text[0] == '=')
            {
                // if simple assignment
                if (Regex.IsMatch(cell.Text, @"^=[A-Z]+[0-9]+$"))
                {
                    cell.Value = this.GetCell(cell.Text.Substring(1)).Value;
                    cell.Dependencies.Add(cell.Text.Substring(1));
                    this.GetCell(cell.Text.Substring(1)).PropertyChanged += cell.Cell_PropertyChanged;
                }

                // if expression
                else
                {
                    this.tree.Expression = cell.Text.Substring(1);

                    // set variable values in tree
                    bool allDoubles = true;
                    foreach (var variable in this.tree.Variables)
                    {
                        double value = 0;

                        // if tryparse fails
                        if (!double.TryParse(this.GetCell(variable).Value, out value))
                        {
                            allDoubles = false;
                            break;
                        }

                        this.tree.SetVariable(variable, value);

                        // subscribe cell to dependencies
                        cell.Dependencies.Add(variable);
                        this.GetCell(variable).PropertyChanged += cell.Cell_PropertyChanged;
                    }

                    // check all cells in formula contain double values
                    if (allDoubles)
                    {
                        cell.Value = this.tree.Evaluate().ToString();
                    }
                    else
                    {
                        cell.Value = "ERR";
                    }
                }
            }
        }
    }
}
