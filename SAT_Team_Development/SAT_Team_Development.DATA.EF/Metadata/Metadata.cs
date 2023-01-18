using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SAT_Team_Development.DATA.EF.Metadata
{
    public class CourseMetadata
    {
        [Required(ErrorMessage ="*Course Name is required")]
        [StringLength(50, ErrorMessage="*Max 50 characters")]
        [Display(Name = "Course")]
        public string CourseName { get; set; } = null!;

        [Required(ErrorMessage ="*Course description is required")]
        [Display(Name = "Course Description")]
        public string CourseDescription { get; set; } = null!;

        [Required(ErrorMessage = "*Credit hours is required")]
        [Range(0, byte.MaxValue, ErrorMessage ="Thats really large, whats wrong with you?")]
        [Display(Name = "Credit Hours")]
        public byte CreditHours { get; set; }

        [StringLength(250, ErrorMessage = "*Max 250 characters")]
        public string? Curriculum { get; set; }

        [StringLength(500, ErrorMessage ="*Max 500 characters")]
        public string? Notes { get; set; }

        [Required(ErrorMessage ="*IsActive is required")]
        [Display(Name = "Active Course?")]
        public bool IsActive { get; set; }
    }

    public class EnrollmentMetadata
    {
        [Required(ErrorMessage = "*Student Id is required")]
        [Display(Name = "Student")]
        public int StudentId { get; set; }

        [Required(ErrorMessage ="*Scheduled Class Id is required")]
        [Display(Name = "Scheduled Class Id")]
        public int ScheduledClassId { get; set; }

        [Required(ErrorMessage ="*Enrollment date is required")]
        [Display(Name = "Enrollment Date")]
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }
    }

    public class ScheduledClassMetadata
    {
        [Required(ErrorMessage = "*Course Id is required")]
        [Display(Name ="Couse Id")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "*Start date is required")]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "*End date is required")]
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "*Instructor Name is required")]
        [Display(Name = "Instructor Name")]
        [StringLength(40, ErrorMessage = "*Max 40 characters")]
        public string InstructorName { get; set; } = null!;

        [Required(ErrorMessage = "*Location is required")]
        [StringLength(20, ErrorMessage = "*Max 20 characters")]
        public string Location { get; set; } = null!;

        [Required(ErrorMessage = "*SCS Id is required")]
        [Display(Name = "Student Class Statues Id")]
        public int Scsid { get; set; }
    }

    public class ScheduledClassStatusMetadata
    {
        [Required(ErrorMessage ="*SCS Name is required")]
        [Display(Name = "Student Class Status Name")]
        public string Scsname { get; set; } = null!;
    }

    public class StudentMetadata
    {
        [Required(ErrorMessage = "*First Name is required")]
        [Display(Name = "First Name")]
        [StringLength(20, ErrorMessage = "*Max 20 characters")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "*Last Name is required")]
        [Display(Name = "Last Name")]
        [StringLength(20, ErrorMessage = "*Max 20 characters")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "*Major is required")]
        [StringLength(20, ErrorMessage = "*Max 20 characters")]
        public string? Major { get; set; }

        
        [StringLength(50, ErrorMessage = "*Max 50 characters")]
        public string? Minor { get; set; }

        [StringLength(50, ErrorMessage = "*Max 50 characters")]
        public string? Address { get; set; }

        [StringLength(25, ErrorMessage = "*Max 25 characters")]
        public string? City { get; set; }

        [StringLength(2, ErrorMessage = "*Max 2 characters")]
        public string? State { get; set; }

        [Display(Name = "Zip Code")]
        [StringLength(10, ErrorMessage = "*Max 10 characters")]
        public string? ZipCode { get; set; }

        [StringLength(13, ErrorMessage = "*Max 13 characters")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "*Email is required")]
        [StringLength(60, ErrorMessage = "*Max 60 characters")]
        public string Email { get; set; } = null!;

        [Display(Name = "Photo URL")]
        [StringLength(100, ErrorMessage = "*Max 100 characters")]
        public string? PhotoUrl { get; set; }

        [Required(ErrorMessage = "*Student Status Id is required")]
        [Display(Name = "Student Status Id")]
        public int? Ssid { get; set; }
    }

    public class StudentStatusMetadata
    {
        [Required(ErrorMessage ="*Student Status Name is required")]
        [Display(Name = "Student Status Name")]
        [StringLength(30, ErrorMessage = "*Max 30 characters")]
        public string Ssname { get; set; } = null!;

        [Display(Name = "Student Status Description")]
        [StringLength(250, ErrorMessage = "*Max 250 characters")]
        public string? Ssdescription { get; set; }
    }
   
}
