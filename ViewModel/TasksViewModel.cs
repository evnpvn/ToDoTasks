using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using TodoTasks.Model;
using TodoTasks.ViewModel.Commands;

namespace TodoTasks.ViewModel
{
    public class TasksViewModel : INotifyPropertyChanged

    {
        //worst case scenario the model in the VM is an exact copy of the model
        //best case scenario it is only what is needed
        //!Fields

        //!Properties
        public ObservableCollection<Tasklist> TasklistList { get; set; } 

        public ObservableCollection<Task> TasksList { get; set; }

        //Removing subtasks to implement afterward
        ////public ObservableCollection<string> Subtasks { get; set; }

        private Tasklist _selectedTasklist;
        public Tasklist SelectedTasklist
        {
            get { return _selectedTasklist; }
            set 
            { 
                _selectedTasklist = value;
                this.TasksList.Clear();
                if(SelectedTasklist != null)
                {
                    if(SelectedTasklist.Tasks != null)
                    {
                        if(SelectedTasklist.Tasks.Count > 0)
                        {
                            foreach (Task task in this.SelectedTasklist.Tasks)
                            {
                                this.TasksList.Add(task);
                            }
                        }
                        
                    }
                }          
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

        private string _addaTaskText;
        public string AddaTaskText
        {
            get { return _addaTaskText; }
            set 
            {
                _addaTaskText = value;
                PropertyUpdated("AddaTaskText");
            }
        }


        private int _taskCount;
        public int TaskCount
        {
            get { return _taskCount; }
            set
            {
                _taskCount = this.SelectedTasklist.Tasks.Count;
                PropertyUpdated("TaskCount");
            }
        }

        private bool _isTasklistRenaming;
        public bool IsTasklistRenaming
        {
            get { return _isTasklistRenaming; }
            set 
            { 
                _isTasklistRenaming = value;
                PropertyUpdated("IsTasklistRenaming");
            }
        }

        private bool _isTaskRenaming;
        public bool IsTaskRenaming
        {
            get { return _isTaskRenaming; }
            set
            {
                _isTaskRenaming = value;
                PropertyUpdated("IsTaskRenaming");
            }
        }

        public NewTasklistCommand NewTasklistCommand { get; set; }
        public NewTaskCommand NewTaskCommand { get; set; }

        public StartRenameCommand StartRenameCommand { get; set; }
        public EndRenameCommand EndRenameCommand { get; set; }

        //!Events
        public event PropertyChangedEventHandler PropertyChanged;

        //!Ctor
        public TasksViewModel()
        {
            this.TasklistList = new ObservableCollection<Tasklist>
            {
                new Tasklist { Name = "Important" },
                new Tasklist { Name = "My Day" },
                new Tasklist { Name = "Flagged email" }
            };

            this.TasksList = new ObservableCollection<Task>();

            this.SelectedTasklist = TasklistList[0];

            this.NewTasklistCommand = new NewTasklistCommand(this);
            this.NewTaskCommand = new NewTaskCommand(this);

            this.StartRenameCommand = new StartRenameCommand(this);
            this.EndRenameCommand = new EndRenameCommand(this);
        }

        //!Methods
        public void PropertyUpdated(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}