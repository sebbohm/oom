using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Course
    {
        private double Grade;

        /// <summary>
        /// Creates new course object.
        /// </summary>
        /// <param name="name">Name must contain course name.</param>
        /// <param name="testDate">Date of first test for course.</param>
        /// <param name="grade">Current grade in course.</param>
        public Course(string name, string testDate, double grade)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Course name required!", nameof(name));
            if (string.IsNullOrWhiteSpace(testDate)) throw new ArgumentException("Test date required!", nameof(testDate));
            if (grade <= 0) throw new ArgumentException("Grade must be positive!", nameof(grade));
            Name = name;
            FirstTest = testDate;
            SetGrade(grade);    
        }

        /// <summary>
        /// Gets the course name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the date for first test.
        /// </summary>
        public string FirstTest { get; }

        /// <summary>
        /// Updates the grade if new grade has been put in.
        /// </summary>
        /// <param name="newgrade">New grade from following tests.</param>
        public void NewGrade (double newgrade)
        {
            if (newgrade >= 0 && newgrade != Grade) Grade = (Grade + newgrade) / 2;
            else throw new ArgumentException("Grade must be positive!", nameof(newgrade));
        }

        /// <summary>
        /// Set the grade of the course.
        /// </summary>
        public void SetGrade(double grade)
        {
            if (grade > 0) Grade = grade;
            else throw new ArgumentException("Grade must be positive!", nameof(grade));
        }

        /// <summary>
        /// Gets grade of course.
        /// </summary>
        public double GetGrade()
        {
            return Grade;
        }
    }
}
