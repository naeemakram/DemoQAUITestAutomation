using System;
using System.Collections.Generic;

namespace DemoQAUITestAutomation.Values
{
    class Student : IEquatable<Student>
    {
        private string _firsName;
        private string _lastName;
        private string _mobile;
        private PagePractice.FormGender _gender;

        public static Student Create(string firstName, string lastName, string mobile, PagePractice.FormGender gender)
        {
            return new Student(firstName, lastName, mobile, gender);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Student);
        }

        public bool Equals(Student other)
        {
            return other != null &&
                   First == other.First &&
                   Last == other.Last &&
                   Mobile == other.Mobile &&
                   Gender == other.Gender;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(First, Last, Mobile, Gender);
        }

        private Student(string firstName, string lastName, string mobile, PagePractice.FormGender gender)
        {
            _firsName = firstName;
            _lastName = lastName;
            _mobile = mobile;
            _gender = gender;
        }

        public string First => _firsName;
        public string Last => _lastName;
        public string Mobile => _mobile;
        public PagePractice.FormGender Gender => _gender;

        public static bool operator ==(Student left, Student right)
        {
            return EqualityComparer<Student>.Default.Equals(left, right);
        }

        public static bool operator !=(Student left, Student right)
        {
            return !(left == right);
        }
    }
}
