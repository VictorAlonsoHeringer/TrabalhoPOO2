namespace Development.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public Group Group { get; set; }
        public List<Mark> Marks { get; set; }

        public Student()
        {
            Group = new Group();
            Marks = new List<Mark>();
        }
    }
}
