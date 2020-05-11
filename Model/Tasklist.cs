using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace TodoTasks.Model
{
    public class Tasklist
    {
        //!Fields

        //!Properties
        public Guid TasklistID { get; set; }

        public List<Task> Tasks { get; set; }

        public string Name { get; set; }


        //!Ctor
        public Tasklist()
        {
            this.TasklistID = new Guid();
            ObservableCollection<Task> tasks = new ObservableCollection<Task>();
    }

        //!Events

        //!Methods
    }
}
