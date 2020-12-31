using System;

namespace PlannerAPI.Models
{
    public partial class TodoItem : IEntity
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime Date { get; set; }
    }
}
