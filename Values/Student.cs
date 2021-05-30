using System;
using System.Collections.Generic;
using System.Text;

namespace DemoQAUITestAutomation.Values
{
    class Student
    {
        private string _firsName;
        private string _lastName;
        private string _mobile;
        private PagePractice.FormGender _gender;

        public static Student Create(string firstName, string lastName, string mobile, PagePractice.FormGender gender)
        {
            return new Student(firstName, lastName, mobile, gender);
        }
        private Student(string firstName, string lastName, string mobile, PagePractice.FormGender gender)
        {
            _firsName = firstName;
            _lastName = lastName;
            _mobile = mobile;
            _gender = gender;
        }

        private string First => _firsName;
        private string Last => _lastName;
        private string Mobile => _mobile;
        private PagePractice.FormGender Gender => _gender;
    }
}
