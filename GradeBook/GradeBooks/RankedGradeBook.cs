using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook: BaseGradeBook
    {
        public RankedGradeBook(string name, bool isweighted) : base(name, isweighted) { base.Type = GradeBookType.Ranked; }

        public override char GetLetterGrade(double averageGrade)
        {

            if (Students.Count < 5) { throw new InvalidOperationException(); }
            else
            {
                List<double> sorted = new List<Student>(base.Students).OrderByDescending(x => x.AverageGrade).Select(x => x.AverageGrade).ToList();
                int count = (int)Math.Floor(Students.Count * 0.2);

                if (averageGrade >= sorted[count - 1])
                { return 'A'; }
                else if (averageGrade >= sorted[2 * count - 1])
                { return 'B'; }
                else if (averageGrade >= sorted[3 * count - 1])
                { return 'C'; }
                else if (averageGrade >= sorted[4 * count - 1])
                { return 'D'; }
                else
                {
                    return 'F';
                }
            }
        }


                public override void CalculateStatistics()
               {
                if(Students.Count < 5)
                {
                 Console.WriteLine("Ranked grading requires at least 5 students.");
                 }
                    else { base.CalculateStatistics(); }
            
                     }


        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else { base.CalculateStudentStatistics(name); }
        }


        }
      
        



    }



