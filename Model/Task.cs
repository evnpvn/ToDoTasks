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
        public string TasklistID { get; set; }

        public string TaskID { get; set; }

        public string Name { get; set; }

        public bool Completed { get; set; }

        public bool Important { get; set; }

        public string Notes { get; set; }

        public List<Subtask> Subtasks { get; set; }
  
        //!Events

        //!Ctor
        public Task(string tasklistId)
        {
            this.TaskID = Guid.NewGuid().ToString();
            this.TasklistID = tasklistId;
            this.Subtasks = new List<Subtask>();
        }

        //!Methods
    }
}
