﻿// 523CSB UnblockMe Solver Visual
// RelayCommand: Helper class for easy implementation of commands in VewModel through delegates
// A simple bonus is the generic interface to support parameter types less abstract than 'object'
//
// 2012-04-28	PV		First version
// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13

using System;
using System.Windows.Input;

namespace CS523B;

internal class RelayCommand<T>(Action<T> execute, Predicate<T> canExecute): ICommand
{
    private readonly Predicate<T> canExecute = canExecute;
    private readonly Action<T> execute = execute;

    // canExecute is optional, and by default is assumed returning true (directly in CanExecute)
    public RelayCommand(Action<T> execute) : this(execute, null)
    { }

    /* From ICommand */

    public bool CanExecute(object parameter) => canExecute == null || canExecute((T)parameter);

    /* From ICommand */

    public void Execute(object parameter) => execute?.Invoke((T)parameter);

    // The 'black magic' part: according to help, CommandManager.RequerySuggested Event occurs when the
    // CommandManager """detects conditions that might change the ability of a command to execute"""...
    // Ok, it works, but exactly how does this detection works is still a mystery to me...
    //
    // Added info from CommandManager.InvalidateRequerySuggested Method:
    // The CommandManager only pays attention to certain conditions in determining when the command target has changed,
    // such as change in keyboard focus. In situations where the CommandManager does not sufficiently determine a change
    // in conditions that cause a command to not be able to execute, InvalidateRequerySuggested can be called to force
    // the CommandManager to raise the RequerySuggested event.

    /* From ICommand */

    public event EventHandler CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }
}
