using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Exam
{
    public class MCQQuestion : Question
    {
        public override string Header => "MCQ Question";   // Header = " ahmed ";  invalid 
                                                           // hya f el asl m3mola without setter 3shan m7dsh yegy f ay method y3ml Header = " ahmed "; 

        public MCQQuestion()  // 5ly balk hena by default ana b chain 3la parameter less contructor bta3 el base f already 3mlt intialize for RightAnswer 
        {
            AnswerList = new Answer[3];   /*you initialize AnswerList as an array of Answer objects with a size of 3.
                                           * At this point, each element in the array is set to null
                                           * because the array has been created but not yet populated with actual Answer instances.*/


                                                               // every element of the array is an object of Answer type which means every element has ( AnswerID , AnswerText )
        }
        public override void AddQuestions()
        {
            // Header
            Console.WriteLine(Header);

            // Body
            Console.WriteLine("Enter body of Question");
            Body = Console.ReadLine();

            // Marks
            int mark;
            do
            {
                Console.WriteLine("enter marks of question");

            } while (!int.TryParse(Console.ReadLine(), out mark) || mark < 1);

            Marks = mark;

            // Answers of question

            Console.WriteLine("enter answers of question:");
            for (int i = 0; i < 3; i++)
            {
                                                                              //If you do not initialize every element of the array,
                                                                               // the uninitialized elements will remain as null.
                                                                                  // This means that if you try to access or use these elements without initializing them,
                AnswerList[i] = new Answer                                         // you will get a NullReferenceException. Here’s how this might play out:*/
                {
                    AnswerId = i + 1
                };
                // AnswerList[i] = new Answer();  // two approach can be used but the above is better for readability
                //AnswerList[i].AnswerId= i+1;

                Console.WriteLine($"Enter answer number{i + 1}:");
                AnswerList[i].AnswerText = Console.ReadLine();                                                                  
            }


            // Right Answer

            int rightAnswerId;
            do
            {
                Console.WriteLine("enter id of the right answer:");

            } while (!int.TryParse(Console.ReadLine(), out rightAnswerId) || rightAnswerId < 1 || rightAnswerId > 3);
            //AnswerId dh bta3 kol so2al 
            RightAnswer.AnswerId = rightAnswerId;                                       /*RightAnswer is a property that can hold an Answer object.
                                                                                        It is not just an object itself; it is a reference to an Answer object.
                                                                                       The property can be used to store and manipulate instances of the Answer class.*/
            RightAnswer.AnswerText = AnswerList[rightAnswerId - 1].AnswerText;

            Console.Clear();
        }
    }
}
