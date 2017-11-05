using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using _1.zadatak;

namespace _4.zadatak
{
    public class HomeworkLinqQueries
    {
        public static string[] Linq1(int[] intArray)
        {
            string[] strings = intArray.GroupBy(number => number).OrderBy(number => number.Key)
                .Select(g => System.String.Format("Broj {0} ponavlja se {1} puta", g.Key, g.Count()))
                .ToArray();
            return strings;
        }

        public static University[] Linq2_1(University[] universityArray)
        {
            return universityArray.Where(uni => uni.Students.All(s => s.Gender == Gender.Male)).ToArray();
        }

        public static University[] Linq2_2(University[] universityArray)
        {
            double averageNumOfStudents = universityArray.Select(u => u.Students.Length).Average();
            return universityArray.Where(u => u.Students.Length < averageNumOfStudents).ToArray();
        }

        public static Student[] Linq2_3(University[] universityArray)
        {
            return universityArray.SelectMany(u => u.Students).Distinct().ToArray();
        }

        public static Student[] Linq2_4(University[] universityArray)
        {
            return universityArray.Where(u => u.Students.All(s => s.Gender == Gender.Female)).SelectMany(u => u.Students)
                .Union(universityArray.Where(u => u.Students.All(s => s.Gender == Gender.Male))
                    .SelectMany(u => u.Students)).ToArray();
        }

        public static Student[] Linq2_5(University[] universityArray)
        {
            return  universityArray.SelectMany(uni => uni.Students)
                .GroupBy(stud => stud).Where(stud => stud.Count() > 1).Select(stud => stud.Key).ToArray();
            //return result;
            }
    }
}