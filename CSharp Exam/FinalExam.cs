﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Exam
{
    public class FinalExam : Exam
    {
        public FinalExam(int time, int numberOfQuestions) : base(time, numberOfQuestions)
        {
        }

        public override void CreateListOfQuestions()
        {
            ListOfQuestions = new Question[NumberOfQuestions];  //depend on NumberOfQuestions that came from user from Subject class
            for (int i = 0; i < ListOfQuestions.Length; i++)
            {
                int choice;
                do
                {
                    Console.WriteLine("enter 1 for MCQ or 2 for True/False question:");
                }
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 2);
                Console.Clear();

                if(choice == 1)
                {
                    ListOfQuestions[i] = new MCQQuestion();
                    ListOfQuestions[i].AddQuestions();

                }
                else if(choice == 2)
                {
                    ListOfQuestions[i] = new TFQuestion();
                    ListOfQuestions[i].AddQuestions();
                }
            }
        }

        public override void ShowExam()
        {
            int totalMarks = 0, Grade = 0;

            foreach (var Question in ListOfQuestions)   // u can usee Question instead of var var will allow the compiler infers the type of the elements in the collection [ 3la 7sb kol no3 so2al ]
            {

                // question
                Console.WriteLine(Question);  //depend on the to string in the Question class

                // Answers/Choices

                for (int i = 0; i < Question.AnswerList.Length; i++)   //depend on the to string in the answer class
                {
                    Console.WriteLine(Question.AnswerList[i]);
                }
                Console.WriteLine("-----------------------------");

                // User Answer
                int UserAnswerId;

                if (Question.Header == "MCQ Question")
                {
                    do
                    {
                        Console.WriteLine("enter number of your answer:");

                    }
                    while (!int.TryParse(Console.ReadLine(), out UserAnswerId) || UserAnswerId < 1 || UserAnswerId > 3);

                    Question.UserAnswer.AnswerId = UserAnswerId;
                    Question.UserAnswer.AnswerText = Question.AnswerList[UserAnswerId - 1].AnswerText;
                    Console.WriteLine("------------------------------");
                }
                else if (Question.Header == "True/False Question")
                {
                    do
                    {
                        Console.WriteLine("enter number of your answer:");

                    }
                    while (!int.TryParse(Console.ReadLine(), out UserAnswerId) || UserAnswerId < 1 || UserAnswerId > 2);

                    Question.UserAnswer.AnswerId = UserAnswerId;
                    Question.UserAnswer.AnswerText = Question.AnswerList[UserAnswerId - 1].AnswerText;
                    Console.WriteLine("------------------------------");
                }
                Console.WriteLine("------------------------------");
                Console.Clear();
                totalMarks += Question.Marks;


            }

            for (int i = 0; i < ListOfQuestions.Length; i++)
            {
                if (ListOfQuestions[i].RightAnswer.AnswerId == ListOfQuestions[i].UserAnswer.AnswerId)    //this comparision  is a value type.
                                                                                                          //   To perform a value-based comparison for reference types, you need to override the Equals method and the == operator in the class definition.
                {
                    Grade += ListOfQuestions[i].Marks;
                }

                Console.WriteLine($"Question({i+1}): {ListOfQuestions[i].Body}");
                Console.WriteLine($"Your Answer: {ListOfQuestions[i].UserAnswer.AnswerText}");
                Console.WriteLine($"Right Answer: {ListOfQuestions[i].RightAnswer.AnswerText}");
            }

            Console.WriteLine($"your grade is {Grade}/{totalMarks}");
        }
    }
}
