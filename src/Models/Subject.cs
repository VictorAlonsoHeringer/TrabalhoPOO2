namespace Development.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string Title { get; set; } = string.Empty;
        public List<SubjectTeacher> SubjectTeachers { get; set; }

        public Subject()
        {
            SubjectTeachers = new List<SubjectTeacher>();
        }
    }
}
