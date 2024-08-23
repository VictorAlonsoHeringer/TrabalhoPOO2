namespace Development.Models
{
    public class SubjectTeacher
    {
        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }
        public Group Group { get; set; }

        public SubjectTeacher()
        {
            Subject = new Subject();
            Teacher = new Teacher();
            Group = new Group();
        }
    }
}
