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
        public string TasklistID { get; set; }

        public List<Task> Tasks { get; set; }

        public string Name { get; set; }

        //!Ctor
        public Tasklist()
        {
            this.TasklistID = Guid.NewGuid().ToString();
            this.Name = "Untitled list";
            this.Tasks = new List<Task>();
        }

        //!Events

        //!Methods
    }
}
