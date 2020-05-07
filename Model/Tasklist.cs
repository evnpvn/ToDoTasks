using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TodoTasks.Model
{
    public class Tasklist : INotifyPropertyChanged
    {
        //!Fields

        //!Properties
        private Guid _tasklistID;
        public Guid TasklistID
        {
            get { return _tasklistID; }
            set { _tasklistID = value; }
        }

        private List<Task> _tasks;
        public List<Task> Tasks
        {
            get { return _tasks; }
            set 
            {
                _tasks = value;
                PropertyUpdated("Tasks");
            }
        }

        //!Ctor
        public Tasklist()
        {
            this.TasklistID = new Guid();
            this.Tasks = new List<Task>();
        }

        //!Events
        public event PropertyChangedEventHandler PropertyChanged;

        //!Methods
        private void PropertyUpdated(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
