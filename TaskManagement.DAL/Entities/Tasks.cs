using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskManagement.Utils.Enums;

namespace TaskManagement.DAL.Entities
{
    [Table("Tasks")]
    public class Tasks
    {
        [Column("Id")]
        [Key]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Description")]
        public string? Description { get; set; }

        [Column("StartDate")]
        public DateTime StartDate { get; set; }

        [Column("DueDate")]
        public DateTime DueDate { get; set; }

        [Column("Status")]
        public Status Status { get; set; }
    }
}
