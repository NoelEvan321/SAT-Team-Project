namespace SAT_Team_Development.UI.MVC.Models
{
    public class EnrollmentViewModel
    {
        //Property to store Instructor Name and StartDate
        public string InstructorName { get; set; }
        public DateTime StartDate { get; set; }
        public EnrollmentViewModel(string instructorName, DateTime startDate)
        {
            InstructorName = instructorName;
            StartDate = startDate;
        }
    }
}
