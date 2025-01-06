using System.Diagnostics;

namespace CSharp_Exam
{
    internal class Program
    {
        
        
        static void Main(string[] args)
        {
            Subject subject = new Subject(1, "C#");

            subject.CreateExam();
            char c;
            do
            {
                Console.WriteLine("Do You Want to start the Exam (Y | N):");


            } while (!char.TryParse(Console.ReadLine(), out c));

            if (c == 'Y' || c == 'y')
            {
                Console.Clear();
                Stopwatch sw = new Stopwatch();
                sw.Start();

                subject.SubjectExam.ShowExam();  // bwsl 3n tre2 el property eli mn no3 el Exam
                Console.WriteLine($"Time Taken:{sw.Elapsed}");
            }
            else
                Console.WriteLine("Thank You!");




        }
    }

}