// Reid Reininger
// 11512839
namespace Cpts321
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Manage commands to change spreadsheet, including undo/redo operations.
    /// </summary>
    internal class CommandManager : INotifyPropertyChanged
    {
        private NotifyEmptyStack<IUndoableCommand> undos = new NotifyEmptyStack<IUndoableCommand>();
        private NotifyEmptyStack<IUndoableCommand> redos = new NotifyEmptyStack<IUndoableCommand>();

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandManager"/> class.
        /// </summary>
        public CommandManager()
        {
            // subscribe to NotifyEmptyStack PropertyChangedEvents
            this.undos.PropertyChanged += this.Undos_PropertyChanged;
            this.redos.PropertyChanged += this.Redos_PropertyChanged;
        }

        /// <summary>
        /// Fires when property changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets a value indicating whether Undos are available.
        /// </summary>
        public bool Undos
        {
            get => this.undos.Count > 0;
        }

        /// <summary>
        /// Gets a value indicating whether Redos are available.
        /// </summary>
        public bool Redos
        {
            get => this.redos.Count > 0;
        }

        /// <summary>
        /// Gets desription of next undo operation.
        /// </summary>
        public string UndoDescription
        {
            get => this.GetTopDescription(this.undos);
        }

        /// <summary>
        /// Gets description of next redo operation.
        /// </summary>
        public string RedoDescription
        {
            get => this.GetTopDescription(this.redos);
        }

        /// <summary>
        /// Executes command.
        /// </summary>
        /// <param name="command">Command to execute.</param>
        public void Execute(ICommand command)
        {
            if (command is IUndoableCommand)
            {
                this.undos.Push((IUndoableCommand)command);
            }

            command.Execute();
        }

        /// <summary>
        /// Undo last undoable operation.
        /// </summary>
        public void Undo()
        {
            if (this.undos.Count > 0)
            {
                IUndoableCommand command = this.undos.Pop();
                this.redos.Push(command);
                command.Undo();
            }
        }

        /// <summary>
        /// Redo last undone operation.
        /// </summary>
        public void Redo()
        {
            // Redo if available
            if (this.redos.Count > 0)
            {
                IUndoableCommand command = this.redos.Pop();
                command.Execute();
                this.undos.Push(command);
            }
        }

        /// <summary>
        /// Return description of top command on stack.
        /// </summary>
        /// <param name="commands">Stack of commands.</param>
        /// <returns>String description of top command on stack.</returns>
        private string GetTopDescription(Stack<IUndoableCommand> commands)
        {
            if (commands.Count > 0)
            {
                return commands.Peek().Description();
            }

            return null;
        }

        private void Undos_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Any")
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Undos"));
            }
        }

        private void Redos_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Any")
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Redos"));
            }
        }
    }
}
