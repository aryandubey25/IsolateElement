// <copyright file="RelayCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace IsolateElement
{
    using System;
    using System.Windows.Input;

#pragma warning disable SA1600 // Elements should be documented
    public class RelayCommand : ICommand
#pragma warning restore SA1600 // Elements should be documented
    {
        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class.
        /// </summary>
        /// <param name="execute"> Hi.</param>
        /// <param name="canExecute">Hiiii.</param>
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        /// <inheritdoc/>
        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        /// <inheritdoc/>
        public void Execute(object parameter)
        {
            this.execute(parameter);
        }

        /// <inheritdoc/>
        #pragma warning disable SA1201
        public event EventHandler CanExecuteChanged
        {
#pragma warning restore SA1201
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
