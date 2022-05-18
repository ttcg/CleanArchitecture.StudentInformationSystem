using Microsoft.Extensions.DependencyInjection;
using StudentInformationSystem.Application.Common.Interfaces.Repositories;
using StudentInformationSystem.Domain.Entities;

namespace StudentInformationSystem.Infrastructure.Repositories;

public static class RepositoryDataSeed
{
    public static async Task SeedSampleDataAsync(IServiceProvider services)
    {
        {
            await SeedStudentData();
            await SeedCourseData();
            await SeedTeacherData();
            await SeedEnrolmentData();
        }

        async Task SeedStudentData()
        {
            var studentRepository = services.GetRequiredService<IStudentRepository>();

            var data = new List<Student> {
                new Student {
                    StudentId = Guid.Parse("90464B9C-AA9B-F3D5-F732-36CE392DCBC3"),
                    FirstName = "Arsenio",
                    LastName = "Grant",
                    Gender     = Domain.Enums.Gender.Female
                },
                new Student {
                    StudentId = Guid.Parse("9617DBDE-41CB-4C94-1046-DA41B83B5DD4"),
                    FirstName = "Brenda",
                    LastName = "Bowen",
                    Gender = Domain.Enums.Gender.Male
                },
                new Student {
                    StudentId = Guid.Parse("B6C3C901-71F4-EA6C-2ADC-765E31921FD7"),
                    FirstName = "Winifred",
                    LastName = "Hanson",
                    Gender = Domain.Enums.Gender.Female
                },
                new Student{
                    StudentId = Guid.Parse("D54A190F-2BA7-834E-E042-1889EAC59CCC"),
                    FirstName = "Stacy",
                    LastName = "Clarke",
                    Gender = Domain.Enums.Gender.Male
                },
                new Student{
                    StudentId = Guid.Parse("230408C6-6795-2ACA-4D2D-961E95E2E544"),
                    FirstName = "Arthur",
                    LastName = "Jackson",
                    Gender = Domain.Enums.Gender.Male
                },
                new Student
                {
                    StudentId = new Guid("EA555CAC-E248-4EE2-B46C-DE65EF3B517D"),
                    FirstName = "John",
                    LastName = "Smith",
                    Gender = Domain.Enums.Gender.Other
                },
                new Student {
                    StudentId = Guid.Parse("C6728723-DA82-F595-AEEA-9A35445D0DD2"),
                    FirstName = "Yoshio",
                    LastName = "Gamble",
                    Gender = Domain.Enums.Gender.Other
                },
                new Student {
                    StudentId = Guid.Parse("85B9FFC8-8536-CD79-9D25-2A75D7783314"),
                    FirstName = "Cooper",
                    LastName = "Andrews",
                    Gender = Domain.Enums.Gender.Male
                },
                new Student {
                    StudentId = Guid.Parse("94A56664-B6B9-8BC2-1A36-643C36E77680"),
                    FirstName = "Brenden",
                    LastName = "Richardson",
                    Gender = Domain.Enums.Gender.Male
                },
                new Student {
                    StudentId = Guid.Parse("C122E2FB-4492-373C-C337-6AC4EA081E71"),
                    FirstName = "Christine",
                    LastName = "Maynard",
                    Gender = Domain.Enums.Gender.Female
                },
                new Student {
                    StudentId = Guid.Parse("8C35B523-6B6B-0934-F199-2CA85986BD8F"),
                    FirstName = "James",
                    LastName = "Craft",
                    Gender = Domain.Enums.Gender.Male
                }
            };

            foreach (var record in data)
            {
                await studentRepository.AddStudent(record, CancellationToken.None);
            }
        }

        async Task SeedCourseData()
        {
            var courseRepository = services.GetRequiredService<ICourseRepository>();

            var data = new List<Course> {
                new Course {
                    CourseId = Guid.Parse("e2acab1c-2013-44a3-9ebf-54b4fe8d101e"),
                    CourseName = "Computer Science BSc Honours"
                },
                new Course {
                    CourseId = Guid.Parse("33b69051-39c8-4881-aba1-439119194e1b"),
                    CourseName = "Computer Science (Game Engineering) BSc Honours"
                },
                new Course {
                    CourseId = Guid.Parse("2f0b182c-4aef-4f78-8d42-6b6f6d086f0a"),
                    CourseName = "Civil Engineering BEng Honours"
                },
                new Course{
                    CourseId = Guid.Parse("8b5ec296-7556-4eab-8f2b-d69e181d93b0"),
                    CourseName = "Chemical Engineering MEng Honours"
                },
                new Course{
                    CourseId = Guid.Parse("42c9edb3-e503-416a-8843-3bae521d04bf"),
                    CourseName = "Mechanical Engineering BEng Honours"
                }
            };

            foreach (var record in data)
            {
                await courseRepository.AddCourse(record, CancellationToken.None);
            }
        }

        async Task SeedTeacherData()
        {
            var teacherRepository = services.GetRequiredService<ITeacherRepository>();

            var data = new List<Teacher> {
                new Teacher {
                    TeacherId = Guid.Parse("5B4E65C3-AD8B-6963-4A85-DDE0E30103AF"),
                    FirstName = "Timothy",
                    LastName = "Salazar"
                },
                new Teacher {
                    TeacherId = Guid.Parse("F733A4BC-37A1-8E8E-DE6D-7A7C2E3DE301"),
                    FirstName = "Jenna",
                    LastName = "Vinson"
                },
                new Teacher {
                    TeacherId = Guid.Parse("B82C58BC-BDB0-1862-524E-2ECD769053FB"),
                    FirstName = "Nelle",
                    LastName = "Cline"
                },
                new Teacher {
                    TeacherId = Guid.Parse("2AF41F1D-6ADA-80C7-C5D8-D6D116EC8D24"),
                    FirstName = "Fletcher",
                    LastName = "Bridges"
                },
                new Teacher {
                    TeacherId = Guid.Parse("2C57B770-F4DA-DA39-2E29-DD2876B614DA"),
                    FirstName = "Edan",
                    LastName = "Hale"
                }
            };

            foreach (var record in data)
            {
                await teacherRepository.AddTeacher(record, CancellationToken.None);
            }
        }

        async Task SeedEnrolmentData()
        {
            var enrolmentRepository = services.GetRequiredService<IEnrolmentRepository>();

            var computerScienceCourseId = Guid.Parse("e2acab1c-2013-44a3-9ebf-54b4fe8d101e");
            var civilEngineeringCourseId = Guid.Parse("2f0b182c-4aef-4f78-8d42-6b6f6d086f0a");

            var data = new List<Enrolment>
            {
                new Enrolment
                {
                    EnrolmentId = Guid.Parse("c8b2f6bf-4597-4eaf-b8b3-43e3c06eb72f"),
                    StudentId = Guid.Parse("90464B9C-AA9B-F3D5-F732-36CE392DCBC3"),
                    CourseId = computerScienceCourseId
                },
                new Enrolment
                {
                    EnrolmentId = Guid.Parse("20d8b554-7796-4504-a718-2466f6de0653"),
                    StudentId = Guid.Parse("9617DBDE-41CB-4C94-1046-DA41B83B5DD4"),
                    CourseId = computerScienceCourseId
                },
                new Enrolment
                {
                    EnrolmentId = Guid.Parse("774603fe-7117-4b46-bce3-9b1cede76c54"),
                    StudentId = Guid.Parse("B6C3C901-71F4-EA6C-2ADC-765E31921FD7"),
                    CourseId = computerScienceCourseId
                },
                new Enrolment
                {
                    EnrolmentId = Guid.Parse("1cf79ff1-2720-4465-a5eb-3216d1135759"),
                    StudentId = Guid.Parse("D54A190F-2BA7-834E-E042-1889EAC59CCC"),
                    CourseId = computerScienceCourseId
                },

                new Enrolment
                {
                    EnrolmentId = Guid.Parse("70c59a38-fdb0-488c-bd62-90416274d752"),
                    StudentId = Guid.Parse("90464B9C-AA9B-F3D5-F732-36CE392DCBC3"),
                    CourseId = civilEngineeringCourseId
                },
                new Enrolment
                {
                    EnrolmentId = Guid.Parse("c090b32d-a096-409c-9bb7-60859fa673c4"),
                    StudentId = Guid.Parse("C122E2FB-4492-373C-C337-6AC4EA081E71"),
                    CourseId = civilEngineeringCourseId
                },
                new Enrolment
                {
                    EnrolmentId = Guid.Parse("63fd5241-c212-4e4c-81c4-3017e5dfee88"),
                    StudentId = Guid.Parse("8C35B523-6B6B-0934-F199-2CA85986BD8F"),
                    CourseId = civilEngineeringCourseId
                }
            };

            foreach (var record in data)
            {
                await enrolmentRepository.AddEnrolment(record, CancellationToken.None);
            }
        }
    }
}


