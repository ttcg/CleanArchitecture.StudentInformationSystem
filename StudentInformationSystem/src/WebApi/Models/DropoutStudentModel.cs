using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.WebApi.Models;

public class DropoutStudentModel
{
    [Required]
    public Guid StudentId { get; set; }

    [Required]
    public Guid CourseId { get; set; }
}
