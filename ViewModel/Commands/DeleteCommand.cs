using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TodoTasks.Model;

namespace TodoTasks.ViewModel.Commands
{
    public class DeleteCommand : ICommand
    {
        //!Fields

        //!Properties
        TasksViewModel TasksViewModel { get; set; }

        //!Events
        public event EventHandler CanExecuteChanged;

        //!Ctor
        public DeleteCommand(TasksViewModel tasksViewModel)
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
            if(parameter is Task)
            {
                Task selectedTask = this.TasksViewModel.SelectedTask;

                //remove it from the observable collection if its not null
                this.TasksViewModel.TasksList?.Remove(selectedTask);
                //and remove selected task from task list if its not null
                this.TasksViewModel.SelectedTasklist.Tasks?.Remove(selectedTask);

                //update the Totalcount
                this.TasksViewModel.SelectedTasklist.TotalCount =
                        this.TasksViewModel.SelectedTasklist.Tasks.Count.ToString();
            }

            else if(parameter is Tasklist)
            {
                Tasklist selectedTasklist = this.TasksViewModel.SelectedTasklist;

                this.TasksViewModel.TasklistList?.Remove(selectedTasklist);
            } 
        }
    }
}
