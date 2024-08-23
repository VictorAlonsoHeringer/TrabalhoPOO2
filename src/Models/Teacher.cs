namespace Development.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public List<SubjectTeacher> SubjectTeachers { get; set; }

        public Teacher()
        {
            SubjectTeachers = new List<SubjectTeacher>();
        }
    }
}
