﻿using System;
using System.Windows.Input;

namespace Lab.Utility
{
	public class RelayCommand : ICommand
	{
		public event EventHandler? CanExecuteChanged;

		private readonly Action<object?> _execute;
		private readonly Func<object?, bool> _canExecute;

		public RelayCommand(Action<object?> execute, Func<object?, bool> canExecute)
		{
			_execute = execute;
			_canExecute = canExecute;
		}

		public bool CanExecute(object? parameter)
		{
			return _canExecute.Invoke(parameter);
		}

		public void Execute(object? parameter)
		{
			_execute(parameter);
		}
		public void RaiseCanExecuteChanged()
		{
			CanExecuteChanged?.Invoke(this, EventArgs.Empty);
		}
	}
}

