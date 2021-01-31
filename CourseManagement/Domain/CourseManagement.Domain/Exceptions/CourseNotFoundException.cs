using System;

namespace CourseManagement.Domain.Exceptions
{
    public class CourseNotFoundException : Exception
    {
        public CourseNotFoundException() { }
        public CourseNotFoundException(string message) : base(message) { }
        public CourseNotFoundException(string message, Exception innerException) : base(message, innerException)
        { }

        public CourseNotFoundException(int id)
           : base($"Course ({id}) was not found.")
        {
        }
    }
}
