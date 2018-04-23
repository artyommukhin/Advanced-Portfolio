using System;
using System.Collections.Generic;
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
            
            string section = "";
            string head = $"Multiple Choise Exam{section}";
            string line = "\n";

            for (int i = 0; i < head.Length; i++)
            {
                line += "-";
            }
            
            Console.WriteLine(head+line);
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
            Start:
            var a = Console.ReadKey(true);
            switch (a.KeyChar)
            {
                case '1':
                    break;
                case '2':
                    break;
                case '3':
                    break;
                case '4':
                    break;
                case '5':
                    break;
                case '6':
                    break;
                case '7':
                    break;
                case '8':
                    break;
                case '0':
                    break;
                default:
                    Console.WriteLine("Write a number");
                    goto Start;
                    break;


            }
            
            Console.ReadKey();
        }
    }
}
