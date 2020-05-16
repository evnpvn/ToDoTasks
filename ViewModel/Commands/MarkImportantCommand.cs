using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using TodoTasks.Model;

namespace TodoTasks.ViewModel.Commands
{
    public class MarkImportantCommand : ICommand
    {
        //!Properties
        public TasksViewModel TasksViewModel { get; set; }

        //!Ctor
        public MarkImportantCommand(TasksViewModel tasksViewModel)
        {
            this.TasksViewModel = tasksViewModel;
        }

        //!Events
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        //!Methods
        public bool CanExecute(object parameter)
        {
            //you can only mark important if the task you are trying to mark important == selected task
            if (parameter is string)
            {
                if (this.TasksViewModel.SelectedTask != null)
                {
                    if (parameter as string == this.TasksViewModel.SelectedTask.Name)
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }

        public void Execute(object parameter)
        {
            Tasklist importantList = (this.TasksViewModel.TasklistList.Where(tlist => tlist.Name == "Important").FirstOrDefault()) as Tasklist;

            if (this.TasksViewModel.SelectedTask.Important == false)
            {
                this.TasksViewModel.SelectedTask.Important = true;             

                //if the important list doesn't contain this task, add it
                if (importantList.Tasks.Contains(this.TasksViewModel.SelectedTask) == false)
                {
                    importantList.Tasks.Add(this.TasksViewModel.SelectedTask);

                    //is the list you are currently looking at is the important task list 
                    //then add it to that list as well
                    if(this.TasksViewModel.SelectedTasklist.Name == "Important")
                    {
                        TasksViewModel.SelectedTasklist.Tasks.Add(this.TasksViewModel.SelectedTask);
                    }
                }
            }
            else
            {
                this.TasksViewModel.SelectedTask.Important = false;

                //if the important list does contain this task, Remove it
                if (importantList.Tasks.Contains(this.TasksViewModel.SelectedTask) == true)
                {
                    importantList.Tasks.Remove(this.TasksViewModel.SelectedTask);

                    //is the list you are currently looking at is the important task list 
                    //then remove it to that list as well
                    if (this.TasksViewModel.SelectedTasklist.Name == "Important")
                    {
                        TasksViewModel.SelectedTasklist.Tasks.Remove(this.TasksViewModel.SelectedTask);
                    }
                }
            }
        }
    }
}
