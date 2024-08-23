namespace Development.Models
{
    public class Mark
    {
        public int MarkId { get; set; }
        public Student Student { get; set; }
        public Subject Subject { get; set; }
        public DateTime Date { get; set; }
        public int Grade { get; set; }

        public Mark()
        {
            Student = new Student();
            Subject = new Subject();
            Date = DateTime.Now;
        }
    }
}
