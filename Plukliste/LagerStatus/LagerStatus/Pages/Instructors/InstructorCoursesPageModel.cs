using LagerStatus.Data;
using LagerStatus.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LagerStatus.Pages.Instructors
{
    public class InstructorCoursesPageModel : PageModel
    {
        public List<Models.View_Models.AssignedCoursesData> AssignedCourseDataList;

        public void PopulateAssignedCourseData(InventoryContext context, Instructor instructor)
        {
            var allCourses = context.Courses;
            var instructorCourses = new HashSet<int>(
                instructor.Courses.Select(c => c.CourseID));
            AssignedCourseDataList = new List<Models.View_Models.AssignedCoursesData>();
            foreach (var course in allCourses)
            {
                AssignedCourseDataList.Add(new Models.View_Models.AssignedCoursesData
                {
                    CourseID = course.CourseID,
                    Title = course.Title,
                    Assigned = instructorCourses.Contains(course.CourseID)
                });
            }
        }
    }
}
