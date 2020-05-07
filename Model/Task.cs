using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TodoTasks.Model
{
    public class Task : INotifyPropertyChanged
    {
        //!Fields

        //!Properties
        private Guid _tasklistID;
        public Guid TasklistID
        {
            get { return _tasklistID; }
            set { _tasklistID = value; }
        }

        private Guid _taskID;
        public Guid TaskID
        {
            get { return _taskID; }
            set { _taskID = value; }
        }

        private bool _completed;
        public bool Completed
        {
            get { return _completed; }
            set
            {
                _completed = value;
                PropertyUpdated("Completed");
            }
        }

        private bool _important;
        public bool Important
        {
            get { return _important; }
            set
            {
                _important = value;
                PropertyUpdated("Important");
            }
        }

        private List<string> _subtasks;

        public List<string> Subtasks
        {
            get { return _subtasks; }
            set
            {
                _subtasks = value;
                PropertyUpdated("Subtasks");
            }
        }

        //!Events
        public event PropertyChangedEventHandler PropertyChanged;

        //!Ctor
        public Task(Guid tasklistId)
        {
            this.TaskID = new Guid();
            this.TasklistID = tasklistId;
        }

        //!Methods
        private void PropertyUpdated(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
