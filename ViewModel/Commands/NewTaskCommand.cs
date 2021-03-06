﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using TodoTasks.Model;

namespace TodoTasks.ViewModel.Commands
{
    public class NewTaskCommand : ICommand
    {
        //!Properties
        public TasksViewModel TasksViewModel { get; set; }

        //!Events
        public event EventHandler CanExecuteChanged;

        //!Ctor
        public NewTaskCommand(TasksViewModel tasksViewModel)
        {
            this.TasksViewModel = tasksViewModel;
        }

        //!Methods
        public bool CanExecute(object parameter)
        {
            string taskText = parameter as string;

            if (string.IsNullOrEmpty(taskText) == false && string.IsNullOrWhiteSpace(taskText) == false)
            {
                if (TasksViewModel.SelectedTasklist != null)
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }

        public void Execute(object parameter)
        {
            string taskText = parameter as string;
            Tasklist selectedTasklist = TasksViewModel.SelectedTasklist;

            //create a new task
            Task newTask = new Task(selectedTasklist.TasklistID)
            {
                Name = taskText
            };

            //if it's created in the important list then mark it important
            if (selectedTasklist == TasksViewModel.DefaultImportantList)
            {
                newTask.Important = true;
            }

            //add this directly to the observable collection
            //add it to the list of tasks against the task list as well
            this.TasksViewModel.TasksList.Add(newTask);
            this.TasksViewModel.SelectedTasklist.Tasks.Add(newTask);

            ////set the selected task to the newly created task
            //this.TasksViewModel.SelectedTask = newTask;

            //set the add a task text box to blank
            this.TasksViewModel.AddaTaskText = "";

            //update the task count
            this.TasksViewModel.SelectedTasklist.TotalCount = this.TasksViewModel.SelectedTasklist.Tasks.Count.ToString();
        }

    }
}
