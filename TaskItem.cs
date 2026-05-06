using System;
using System.Collections.Generic;

namespace TaskManager
{
    public class TaskItem
    {
        public bool IsDone { get; set; }
        public string Status { get; set; } = "Новая";
        public string Name { get; set; }         
        public string Priority { get; set; }     
        public string Deadline { get; set; } 
        public bool haveDeadline { get; set; }
        public List<Subtask> Subtasks { get; set; } 

        public TaskItem()
        {
            Subtasks = new List<Subtask>();
        }
    }

    public class Subtask
    {
        public string Name { get; set; }
        public bool IsDone { get; set; }
    }
}
