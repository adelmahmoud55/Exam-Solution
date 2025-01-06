using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Exam
{
    public abstract class Question
    {
        public abstract  string Header { get;}
        public int Marks { get; set; }
        public string Body { get; set; }

        public Answer[] AnswerList { get; set; }  /*: This indicates that AnswerList is an array of Answer objects. */
        public Answer RightAnswer { get; set; }       /*RightAnswer is a property that can hold an Answer object.
                                                         It is not just an object itself; it is a reference to an Answer object.
                                                          The property can be used to store and manipulate instances of the Answer class.*/
        public Answer UserAnswer { get; set; }


        public Question()
        {
            RightAnswer = new Answer();   ///hena 3mlt inialize lehom 3shan hyb2o sbten dymn kol AnswerList Element leh rightanswer  useranswer 
                                          // lakn m3mltsh inialize AnswerLIst 3shan kol no3 as2la leh 3add mo3yn
            UserAnswer = new Answer();
        }

        public abstract void AddQuestions();

        public override string ToString()
        {
            return $"{Header} \t Marks: {Marks} \n ------------ \n {Body} \n";
        }
    }
}
