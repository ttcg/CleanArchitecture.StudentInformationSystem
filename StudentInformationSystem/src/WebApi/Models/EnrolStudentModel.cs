using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.WebApi.Models;

public class EnrolStudentModel
{
    [Required]
    public Guid StudentId { get; set; }

    [Required]
    public Guid CourseId { get; set; }
}
