namespace StudentSystem.Api.Models.Students
{
    using System.ComponentModel.DataAnnotations;

    public class SaveStudentRequestModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string LastName { get; set; }

        public int Level { get; set; }
    }
}