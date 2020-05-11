using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TodoTasks.Model
{
    public class Task
    {
        //!Fields

        //!Properties
        public Guid TasklistID { get; set; }

        public Guid TaskID { get; set; }

        public string Name { get; set; }

        public bool Completed { get; set; }

        public bool Important { get; set; }

        public string Notes { get; set; }
  
        public DateTime DueDate { get; set; }

        //!Events

        //!Ctor
        public Task(Guid tasklistId)
        {
            this.TaskID = new Guid();
            this.TasklistID = tasklistId;
        }

        //!Methods
    }
}
