namespace TestSchool
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using School;

    [TestClass]
    public class TestSchool
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingNullStudentToSchool()
        {
            School school = new School("Hristo Botev");

            school.AddStudent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingNullCourseToSchool()
        {
            School school = new School("Hristo Botev");

            school.AddCourse(null);
        }

        [TestMethod]
        public void AddingOneStudentToSchool()
        {
            School school = new School("Hristo Botev");
            Student student = new Student("Petar", "Zahariev", 54321);

            school.AddStudent(student);

            Assert.AreEqual(
                1,
                school.StudentsCount,
                string.Format("Student's count in the school is {0} which is incorrect!", school.StudentsCount));
        }

        [TestMethod]
        public void AddingOneCourseToSchool()
        {
            School school = new School("Hristo Botev");
            Course course = new Course("English");

            school.AddCourse(course);

            Assert.AreEqual(
                1,
                school.CoursesCount,
                string.Format("Course's count in the school is {0} which is incorrect!", school.CoursesCount));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingSchoolWithNullName()
        {
            School school = new School(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCourseWithNullName()
        {
            Course course = new Course(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingStudentWithNullFirstName()
        {
            Student student = new Student(null, "Einstein", 12345);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingStudentWithNullLastName()
        {
            Student student = new Student("Albert", null, 12345);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddingStudentWithOutOfRangeId()
        {
            Student student = new Student("Albert", "Einstein", 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddingTwoStudentsWithTheSameId()
        {
            School school = new School("Hristo Botev");
            Student firstStudent = new Student("Albert", "Einstein", 12345);
            Student secondStudent = new Student("Henry", "Ford", 12345);

            school.AddStudent(firstStudent);
            school.AddStudent(secondStudent);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingStudentToNullCourse()
        {
            School school = new School("Hristo Botev");
            Student student = new Student("Albert", "Einstein", 12345);

            school.AddStudent(student);
            school.AddStudentToCourse(student, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingNullStudentToCourse()
        {
            School school = new School("Hristo Botev");
            Course course = new Course("Math");

            school.AddCourse(course);
            school.AddStudentToCourse(null, course);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddingNonExistingInTheSchoolStudentToCourse()
        {
            School school = new School("Hristo Botev");
            Student student = new Student("Albert", "Einstein", 12345);
            Course course = new Course("Math");

            school.AddCourse(course);
            school.AddStudentToCourse(student, course);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddingStudentToNonExistingInTheSchoolCourse()
        {
            School school = new School("Hristo Botev");
            Student student = new Student("Albert", "Einstein", 12345);
            Course course = new Course("Math");

            school.AddStudent(student);
            school.AddStudentToCourse(student, course);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddingMoreThan30StudentsToOneCourse()
        {
            School school = new School("Hristo Botev");
            Course course = new Course("Math");

            school.AddCourse(course);

            for (uint i = 0; i < 30; i++)
            {
                Student currentStudent = new Student("Albert", "Einstein", 12345 + i);
                school.AddStudent(currentStudent);
                school.AddStudentToCourse(currentStudent, course);
            }

            Student student = new Student("Albert", "Einstein", 12342);
            school.AddStudent(student);
            school.AddStudentToCourse(student, course);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemovingStudentFromNullCourse()
        {
            School school = new School("Hristo Botev");
            Student student = new Student("Albert", "Einstein", 12345);

            school.AddStudent(student);
            school.RemoveStudentFromCourse(student, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemovingNullStudentFromCourse()
        {
            School school = new School("Hristo Botev");
            Course course = new Course("Math");

            school.AddCourse(course);
            school.RemoveStudentFromCourse(null, course);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemovingNonExistingInTheSchoolStudentFromCourse()
        {
            School school = new School("Hristo Botev");
            Student student = new Student("Albert", "Einstein", 12345);
            Course course = new Course("Math");

            school.AddCourse(course);
            school.RemoveStudentFromCourse(student, course);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemovingStudentFromNonExistingInTheSchoolCourse()
        {
            School school = new School("Hristo Botev");
            Student student = new Student("Albert", "Einstein", 12345);
            Course course = new Course("Math");

            school.AddStudent(student);
            school.RemoveStudentFromCourse(student, course);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemovingNonExistingInTheCourseStudentFromCourse()
        {
            School school = new School("Hristo Botev");
            Student student = new Student("Albert", "Einstein", 12342);
            Course course = new Course("Math");

            school.AddStudent(student);
            school.AddCourse(course);
            school.RemoveStudentFromCourse(student, course);
        }

        [TestMethod]
        public void RemovingStudentFromCourse()
        {
            School school = new School("Hristo Botev");
            Student student = new Student("Albert", "Einstein", 12342);
            Course course = new Course("Math");

            school.AddStudent(student);
            school.AddCourse(course);
            school.AddStudentToCourse(student, course);
            school.RemoveStudentFromCourse(student, course);

            Assert.AreEqual(
                0,
                course.StudentsCount,
                string.Format("Student's count in the course is {0} which is incorrect!", course.StudentsCount));
        }

        [TestMethod]
        public void GettingTheNameOfTheCourse()
        {
            Course course = new Course("Math");

            Assert.AreEqual(
                "Math",
                course.Name,
                string.Format("The name of the course is {0} which is incorrect!", course.Name));
        }

        [TestMethod]
        public void GettingTheNameOfTheSchool()
        {
            School school = new School("Hristo Botev");

            Assert.AreEqual(
                "Hristo Botev",
                school.Name,
                string.Format("The name of the school is {0} which is incorrect!", school.Name));
        }

        [TestMethod]
        public void GettingTheFirstNameOfTheStudent()
        {
            Student student = new Student("Hristo", "Petrov", 12345);

            Assert.AreEqual(
                "Hristo",
                student.FirstName,
                string.Format("The first name of the student is {0} which is incorrect!", student.FirstName));
        }

        [TestMethod]
        public void GettingTheLastNameOfTheStudent()
        {
            Student student = new Student("Hristo", "Petrov", 12345);

            Assert.AreEqual(
                "Petrov",
                student.LastName,
                string.Format("The last name of the student is {0} which is incorrect!", student.LastName));
        }

        [TestMethod]
        public void GettingTheIdOfTheStudent()
        {
            Student student = new Student("Hristo", "Petrov", 12345);

            Assert.AreEqual(
                12345u,
                student.Id,
                string.Format("The id of the student is {0} which is incorrect!", student.Id));
        }
    }
}