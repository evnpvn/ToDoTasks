using System;
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
            //TODO: test this
            //Only when a task list is selected && textbox != null
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

            //TODO: fix this as well as the xaml bindings on the parameters if needed
            //create a new task
            Task newTask = new Task(TasksViewModel.SelectedTasklist.TasklistID);
            newTask.Name = taskText;

            //assign the task list back to the property on the viewModel
            TasksViewModel.TasksList.Add(newTask);

        }
    }
}
