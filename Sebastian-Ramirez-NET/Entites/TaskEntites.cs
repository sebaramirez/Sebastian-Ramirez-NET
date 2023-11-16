using Sebastian_Ramirez_NET.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sebastian_Ramirez_NET.Entites
{
    [Table("Tasks")]
    public class TaskEntites
    {
        [Key]
        [Column("task_id")]

        public int Id { get; set; }

        [Column("task_Title", TypeName = "VARCHAR(50)")]
        public string? Title { get; set; }

        [Column("task_Description", TypeName = "VARCHAR(100)")]
        public string? Description { get; set; }

        [Column("task_IsCompleted")]
        public bool IsCompleted { get; set; }

        public static implicit operator TaskEntites(TaskRegisterDTO v)
        {
            var task = new TaskEntites();
            task.Id = v.Id;
            task.Title = v.Title;
            task.Description = v.Description;
            task.IsCompleted = v.IsCompleted;
            return task;
        }
    }
}
