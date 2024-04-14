using CustomDataList.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDataList
{
    public class CustomDataList
    {
        private Students[] students;
        private int placesInUse;
        private int numberOfTheStudentNumbers;
        public string[] studentNumber = { "15000", "15001", "15002", "15003", "15004", "15005", "15006", "15007", "15008", "15009" };
        public int Length
        {
            get
            {
                int count = 0;
                foreach (var item in students)
                {
                    count++;
                }
                return count;
            }
        }
        public Students First
        {
            get
            {
                return students[0];
            }
        }
        public Students Last
        {
            get
            {
                return students[students.Length - 1];
            }
        }

        public CustomDataList(int limit)
        {
            students = new Students[limit];
            placesInUse = 0;
            numberOfTheStudentNumbers = studentNumber.Length;
        }

        public void DisplayList()
        {
            Console.WriteLine("--------------------------------------------------------------");
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i] != null)
                {
                    Console.WriteLine($"{i + 1}. {students[i]}");
                }
            }
            Console.WriteLine("--------------------------------------------------------------");
        }

        public void PopulateWithSampleData()
        {
            Random rnd = new Random();

            for (int i = 0; i < students.Length; i++)
            {
                students[i] = new Students
                {
                    StudentFirstName = Convert.ToString((StudentFirstName)rnd.Next(0, 10)),
                    StudentLastName = Convert.ToString((StudentLastName)rnd.Next(0, 10)),
                    StudentNumber = studentNumber[i],
                    StudentAverageScore = (float)rnd.NextDouble() * (6 - 3) + 3
                };
                placesInUse++;
            }
        }

        public Students GetElement(int index)
        {
            if (index <= 0 || index > students.Length)
            {
                throw new ArgumentOutOfRangeException($"Student with index {index} does not exist");
            }

            return students[index - 1];
        }

        public void Add(Students student, string studentNum)
        {
            IncreaseArraySize();
            IncreaseArraySizeOfTheStudentNumber();

            students[placesInUse] = student;
            studentNumber[numberOfTheStudentNumbers] = studentNum;
            placesInUse++;
            numberOfTheStudentNumbers++;
        }

        public void RemoveByIndex(int index)
        {
            if (index <= 0 || index > students.Length)
            {
                throw new ArgumentOutOfRangeException($"Student with index {index} does not exist");
            }

            for (int i = index - 1; i < placesInUse - 1; i++)
            {
                students[i] = students[i + 1];
            }

            students[placesInUse - 1] = default;
            DecreaseArraySize();
            placesInUse--;
        }

        public void RemoveFirst()
        {
            for (int i = 0; i < placesInUse - 1; i++)
            {
                students[i] = students[i + 1];
            }

            students[placesInUse - 1] = default;
            DecreaseArraySize();
            placesInUse--;
        }

        public void RemoveLast()
        {
            for (int i = placesInUse - 1; i < placesInUse - 1; i++)
            {
                students[i] = students[i + 1];
            }

            students[placesInUse - 1] = default;
            DecreaseArraySize();
            placesInUse--;
        }

        public void IncreaseArraySize()
        {
            if (placesInUse >= students.Length)
            {
                Students[] resizedArray = new Students[students.Length + 1];

                Array.Copy(students, 0, resizedArray, 0, students.Length);

                students = resizedArray;
            }
        }

        public void DecreaseArraySize()
        {
            Students[] resizedArray = new Students[students.Length - 1];

            Array.Copy(students, 0, resizedArray, 0, students.Length - 1);

            students = resizedArray;
        }

        public void IncreaseArraySizeOfTheStudentNumber()
        {
            if (numberOfTheStudentNumbers >= studentNumber.Length)
            {
                string[] resizedArray = new string[studentNumber.Length + 1];

                Array.Copy(studentNumber, 0, resizedArray, 0, studentNumber.Length);

                studentNumber = resizedArray;
            }
        }
    }
}