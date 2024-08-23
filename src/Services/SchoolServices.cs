using System;
using System.Collections.Generic;
using Development.Models;

namespace Development.Services
{
    public class SchoolService
    {
        public List<Group> Groups { get; set; } = new List<Group>();
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Teacher> Teachers { get; set; } = new List<Teacher>();
        public List<Subject> Subjects { get; set; } = new List<Subject>();
        public List<Mark> Marks { get; set; } = new List<Mark>();

        public void AddGroup(string groupName)
        {
            int groupId = Groups.Count + 1;
            Groups.Add(new Group { GroupId = groupId, Name = groupName });
        }

        public void AddStudent(string firstName, string lastName, int groupId)
        {
            var group = Groups.Find(g => g.GroupId == groupId);
            if (group != null)
            {
                int studentId = Students.Count + 1;
                var student = new Student { StudentId = studentId, FirstName = firstName, LastName = lastName, Group = group };
                Students.Add(student);
                group.Students.Add(student);
            }
        }

        public void AddTeacher(string firstName, string lastName)
        {
            int teacherId = Teachers.Count + 1;
            Teachers.Add(new Teacher { TeacherId = teacherId, FirstName = firstName, LastName = lastName });
        }

        public void AddSubject(string title)
        {
            int subjectId = Subjects.Count + 1;
            Subjects.Add(new Subject { SubjectId = subjectId, Title = title });
        }

        public void AssignTeacherToSubject(int teacherId, int subjectId, int groupId)
        {
            var teacher = Teachers.Find(t => t.TeacherId == teacherId);
            var subject = Subjects.Find(s => s.SubjectId == subjectId);
            var group = Groups.Find(g => g.GroupId == groupId);

            if (teacher != null && subject != null && group != null)
            {
                var subjectTeacher = new SubjectTeacher { Teacher = teacher, Subject = subject, Group = group };
                teacher.SubjectTeachers.Add(subjectTeacher);
                subject.SubjectTeachers.Add(subjectTeacher);
            }
        }

        public void AddMark(int studentId, int subjectId, int grade)
        {
            var student = Students.Find(s => s.StudentId == studentId);
            var subject = Subjects.Find(s => s.SubjectId == subjectId);

            if (student != null && subject != null)
            {
                int markId = Marks.Count + 1;
                var mark = new Mark { MarkId = markId, Student = student, Subject = subject, Date = DateTime.Now, Grade = grade };
                Marks.Add(mark);
                student.Marks.Add(mark);
            }
        }

        public void PrintStudentReportCard(int studentId)
        {
            var student = Students.Find(s => s.StudentId == studentId);
            if (student != null)
            {
                Console.WriteLine($"Report Card for {student.FirstName} {student.LastName}");
                foreach (var mark in student.Marks)
                {
                    Console.WriteLine($"{mark.Subject.Title}: {mark.Grade} (Date: {mark.Date.ToShortDateString()})");
                }
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
    }
}
