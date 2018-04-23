using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Advanced_Portfolio
{
    class Program
    {
        static void Main(string[] args)
        {
            Start:
            Methods.MakeHead();
            Console.WriteLine("Please enter:\n" +
                              "\t1 - to create a new question,\n" +
                              "\t2 - to display all questions,\n" +
                              "\t3 - to edit a question,\n" +
                              "\t4 - to delete a question,\n" +
                              "\t5 - to import questions from a file,\n" +
                              "\t6 - to export questions to a file,\n" +
                              "\t7 - to start the exam,\n" +
                              "\t8 - to mark the exam,\n" +
                              "\t0 - to exit the program.\n");

            var a = Console.ReadKey(true);
            switch (a.KeyChar)
            {
                case '1':
                    Console.Clear();
                    Methods.CreateNewQuestion();
                    goto Start;
                case '2':
                    Console.Clear();
                    Methods.DisplayAllQuestions();
                    goto Start;
                case '3':
                    Console.Clear();
                    Methods.EditQuestion();
                    goto Start;
                case '4':
                    Console.Clear();
                    Methods.DeleteQuestion();
                    goto Start;
                case '5':
                    Console.Clear();
                    Methods.ImportQuestions();
                    goto Start;
                case '6':
                    Console.Clear();                    
                    Methods.ExportQuestions();
                    goto Start;
                case '7':
                    Console.Clear();
                    Methods.StartExam();
                    goto Start;
                case '8':
                    Console.Clear();
                    Methods.MakeHead("Mark Exam");
                    Methods.MarkExam();
                    goto Start;
                case '0':
                    break;
                default:
                    Console.Clear();
                    goto Start;
            }
        }
    }
}
