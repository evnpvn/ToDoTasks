﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TodoTasks.Model;

namespace TodoTasks.ViewModel.Commands
{
    public class StartRenameCommand : ICommand
    {
        //!Properties
        public TasksViewModel TasksViewModel { get; set; }

        //!Events
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        //!Ctor
        public StartRenameCommand(TasksViewModel tasksViewModel)
        {
            this.TasksViewModel = tasksViewModel;
        }

        //!Methods
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //Create textbox overlayed on top of the tasklist textblock
            //But only set the tasklistrenaming = true for the Selected List

            if(parameter is Tasklist)
            {
                TasksViewModel.IsTasklistRenaming = true;
            }
        }
    }
}
