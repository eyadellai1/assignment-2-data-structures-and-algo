using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDataList
{
    public class Students
    {
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public string StudentNumber { get; set; }
        public float StudentAverageScore { get; set; }

        public override string ToString()
        {
            return $"Name: {StudentFirstName} {StudentLastName}, Student number: {StudentNumber}, Student Average Score: {Math.Round(StudentAverageScore, 2)}";
        }
    }
}

