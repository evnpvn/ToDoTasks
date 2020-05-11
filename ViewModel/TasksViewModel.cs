using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using TodoTasks.Model;

namespace TodoTasks.ViewModel
{
    public class TasksViewModel : INotifyPropertyChanged

    {
        //worst case scenario the model in the VM is an exact copy of the model
        //best case scenario it is only what is needed
        //!Fields

        //!Properties
        public ObservableCollection<Tasklist> Tasklist { get; set; }

        public ObservableCollection<Task> Tasks { get; set; }

        //Removing subtasks to implement afterward
        ////public ObservableCollection<string> Subtasks { get; set; }


        private Tasklist _selectedTasklist;
        public Tasklist SelectedTasklist
        {
            get { return _selectedTasklist; }
            set 
            { 
                _selectedTasklist = value;
                PropertyUpdated("SelectedTasklist");
            }
        }

        private Task _selectedTask;
        public Task SelectedTask
        {
            get { return _selectedTask; }
            set
            {
                _selectedTask = value;
                PropertyUpdated("SelectedTask");
            }
        }

        private int _taskCount;
        public int TaskCount
        {
            get { return _taskCount; }
            set
            {
                _taskCount = this.Tasks.Count;
                PropertyUpdated("TaskCount");
            }
        }

        //!Events
        public event PropertyChangedEventHandler PropertyChanged;

        //!Ctor
        public TasksViewModel()
        {
            ObservableCollection<Tasklist> tasklist = new ObservableCollection<Tasklist>();
        }

        //!Methods
        public void PropertyUpdated(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}