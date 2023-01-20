using Microsoft.AspNetCore.Mvc;
using SAT_Team_Development.DATA.EF.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAT_Team_Development.DATA.EF.Models
{
   
    [ModelMetadataType(typeof(CourseMetadata))]
    public partial class Course
    {

    }

    [ModelMetadataType(typeof(EnrollmentMetadata))]
    public partial class Enrollment
    {

    }

    [ModelMetadataType(typeof(ScheduledClassMetadata))]
    public partial class ScheduledClass
    {
        private readonly SAT_Administration_ToolContext _context;

        [NotMapped]
        public string? ClassInfo
        {
            get
            {
                if (Course == null)
                {
                    return null;
                }
                else
                {

                    return string.Format($"{Course.CourseName} | {StartDate:d} | {InstructorName}");
                }
            }
            
        }
    }

    [ModelMetadataType(typeof(ScheduledClassStatusMetadata))]
    public partial class ScheduledClassStatus
    {

    }

    [ModelMetadataType(typeof(StudentMetadata))]
    public partial class Student
    {

    }

    [ModelMetadataType(typeof(StudentStatusMetadata))]
    public partial class StudentStatus
    {

    }

       
    
}
