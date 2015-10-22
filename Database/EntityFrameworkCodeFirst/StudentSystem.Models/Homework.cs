namespace StudentSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Homework
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime TimeSend { get; set; }

        public int StudentId { get; set; }

        public virtual Student Student { get; set; }

        public Guid CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
