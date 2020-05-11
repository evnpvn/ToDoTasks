using System;
using System.Collections.Generic;
using System.Text;
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
            //TODO: update with actual logic for when a bew task can be created 
            //TODO: IE only when a task list is selected && textbox != null
            return true;
        }

        public void Execute(object parameter)
        {
            //TODO: fix this as well as the xaml bindings on the parameters if needed
            //parameters are currently being passed as null
            //parameter will be bound to the text in the textbox

            //create a new list<tasks>
            List<Task> tasks = new List<Task>() { };

            //create a new task
            Task newTask = new Task(TasksViewModel.SelectedTasklist.TasklistID);

            //set the values of that task
            newTask.Name = "";

            //add the task back to the list
            tasks.Add(newTask);

            //assign the task list back to the property on the viewModel
            //TasksViewModel.Tasks = tasks;



        }
    }
}
