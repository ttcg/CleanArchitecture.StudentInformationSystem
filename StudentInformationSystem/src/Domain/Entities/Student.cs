using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Domain.Entities;

public class Student : AuditableEntity
{
    public Guid StudentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Gender Gender { get; set; }

    public string StudentFullName
    {
        get
        {
            return $"{FirstName} {LastName}";
        }
    }
}
