using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Advanced_Portfolio
{
    public static class Methods
    {
        public static void MakeHead()
        {
            Console.WriteLine("Multiple Choise Exam\n" +
                              "--------------------");
        }
        public static void MakeHead(string section)
        {
            string head = $"Multiple Choise Exam - {section}\n";
            string line = "";

            for (int i = 0; i < head.Length - 1; i++)
            {
                line += "-";
            }
            Console.WriteLine(head + line);
        } 
        
        public static List<MultipleChoiceQuestion> Questions = new List<MultipleChoiceQuestion>();
        public static List<string> Answers = new List<string>();

        public static void CreateNewQuestion()
        {
            MakeHead("New Question");

            MultipleChoiceQuestion newQuestion = new MultipleChoiceQuestion();

            Console.WriteLine($"There are {Questions.Count} questions in the exam.\n");

            Console.WriteLine("Enter the question:");
            newQuestion.Question = Console.ReadLine();

            Console.WriteLine("Enter choice 1 for the question:");
            newQuestion.Choise1 = Console.ReadLine();

            Console.WriteLine("Enter choice 2 for the question:");
            newQuestion.Choise2 = Console.ReadLine();

            Console.WriteLine("Enter choice 3 for the question:");
            newQuestion.Choise3 = Console.ReadLine();

            Console.WriteLine("Enter choice 4 for the question:");
            newQuestion.Choise4 = Console.ReadLine();

            Console.WriteLine("Enter the correct choice (A, B, C, D):");
            Choice:
            switch (Console.ReadLine())
            {
                case "A":
                    newQuestion.CorrectChoise = CorrectChoise.A;
                    break;
                case "B":
                    newQuestion.CorrectChoise = CorrectChoise.B;
                    break;
                case "C":
                    newQuestion.CorrectChoise = CorrectChoise.C;
                    break;
                case "D":
                    newQuestion.CorrectChoise = CorrectChoise.D;
                    break;
                default:
                    Console.WriteLine("Only A, B, C or D allowed");
                    goto Choice;
            }
            Questions.Add(newQuestion);
            Console.WriteLine("Successfully added 1 question to exam.\n" +
                              "Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }

        public static void DisplayAllQuestions()
        {
            MakeHead("Display All Questions");

            for (int i = 0; i < Questions.Count; i++)
            {
                var q = Questions[i];
                Console.WriteLine($"Question {i+1}\n" +
                                   "-----------------\n" +
                                  $"{q.Question}\n" +
                                  $"A. {q.Choise1}\n" +
                                  $"B. {q.Choise2}\n" +
                                  $"C. {q.Choise3}\n" +
                                  $"D. {q.Choise4}");
                Console.WriteLine();
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }

        public static void EditQuestion()
        {
            MakeHead("Edit Question");

            Console.WriteLine("Enter the question number to edit:");
            Input:
            if (!int.TryParse(Console.ReadLine(), out int i))
            {
                Console.WriteLine("Write a number");
                goto Input;
            }

            if (i - 1 < Questions.Count)
            {
                var q = Questions[i - 1];
                Console.WriteLine("The question is as follows:\n" +
                                  $"Question {i}\n" +
                                  "-----------------\n" +
                                  $"{q.Question}\n" +
                                  $"A. {q.Choise1}\n" +
                                  $"B. {q.Choise2}\n" +
                                  $"C. {q.Choise3}\n" +
                                  $"D. {q.Choise4}");
                Console.WriteLine();

                Console.WriteLine("Enter the question:");
                q.Question = Console.ReadLine();

                Console.WriteLine("Enter choice 1 for the question:");
                q.Choise1 = Console.ReadLine();

                Console.WriteLine("Enter choice 2 for the question:");
                q.Choise2 = Console.ReadLine();

                Console.WriteLine("Enter choice 3 for the question:");
                q.Choise3 = Console.ReadLine();

                Console.WriteLine("Enter choice 4 for the question:");
                q.Choise4 = Console.ReadLine();

                Console.WriteLine("Enter the correct choice (A, B, C, D):");
                Choice:
                switch (Console.ReadLine())
                {
                    case "A":
                        q.CorrectChoise = CorrectChoise.A;
                        break;
                    case "B":
                        q.CorrectChoise = CorrectChoise.B;
                        break;
                    case "C":
                        q.CorrectChoise = CorrectChoise.C;
                        break;
                    case "D":
                        q.CorrectChoise = CorrectChoise.D;
                        break;
                    default:
                        Console.WriteLine("Only A, B, C or D allowed");
                        goto Choice;
                }

                Console.WriteLine($"Successfully updated question {i}");
            }
            else
            {
                Console.WriteLine($"Error! {i} is not a valid question number.");
            }

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }

        public static void DeleteQuestion()
        {
            MakeHead("Delete Question");

            Console.WriteLine("Enter the question number to delete:");
            Input:
            if (!int.TryParse(Console.ReadLine(), out int i))
            {
                Console.WriteLine("Write a number");
                goto Input; 
            }

            if (i - 1 < Questions.Count)
            {
                var q = Questions[i - 1];
                Console.WriteLine("Found the following question:\n" +
                                 $"Question {i}\n" +
                                  "-----------------\n" +
                                 $"{q.Question}\n" +
                                 $"A. {q.Choise1}\n" +
                                 $"B. {q.Choise2}\n" +
                                 $"C. {q.Choise3}\n" +
                                 $"D. {q.Choise4}");
                Console.WriteLine();
                Console.WriteLine($"Are you sure want to delete question {i} (y/n)?");
                Switch:
                switch (Console.ReadKey(true).KeyChar)
                {
                    case 'y':
                        Questions.Remove(Questions[i - 1]);
                        Console.WriteLine($"Successfully deleted question {i}");
                        break;
                    case 'n':
                        break;
                    default:
                        Console.WriteLine("y or n");
                        goto Switch;
                }
            }
            else
            {
                Console.WriteLine($"Error! {i} is not a valid question number.");
            }

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }

        public static void ImportQuestions()
        {
            MakeHead("Import Questions");
            
            Console.WriteLine("Enter the location of the file to read from:");
            string filename = Console.ReadLine();
            if (File.Exists(filename))
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    Questions.Clear();
                    string allText = sr.ReadToEnd();
                    string[] fullQuestions = allText.Split('-');

                    foreach (string fullQuestion in fullQuestions)
                    {
                        if (fullQuestion!="")
                        {
                            string[] q = fullQuestion.Trim().Split('\n');
                            CorrectChoise.TryParse(q[5],true, out CorrectChoise cc);

                            var newQuestion = new MultipleChoiceQuestion()
                            {
                                Question = q[0],
                                Choise1 = q[1].Substring(3),
                                Choise2 = q[2].Substring(3),
                                Choise3 = q[3].Substring(3),
                                Choise4 = q[4].Substring(3),
                                CorrectChoise = cc
                            };
                            Questions.Add(newQuestion);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine($"Could not find a part of the path '{filename}'");
            }

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.Clear();


        }

        public static void ExportQuestions()
        {
            MakeHead("Export Questions");

            Console.WriteLine("Enter the location of the file to save to:");
            string filename = Console.ReadLine();
            if (File.Exists(filename))
            {
                using (StreamWriter sw = new StreamWriter(filename))
                {
                    foreach (var q in Questions)
                    {
                        sw.WriteLine($"{q.Question}");
                        sw.WriteLine(
                                     $"A. {q.Choise1}\r\n" +
                                     $"B. {q.Choise2}\r\n" +
                                     $"C. {q.Choise3}\r\n" +
                                     $"D. {q.Choise4}\r\n" +
                                      "---");
                    }
                    sw.Dispose();
                }
            }
            else
            {
                Console.WriteLine($"Could not find a part of the path '{filename}'");
            }

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.Clear();

        }

        public static void StartExam()
        {
            Answers.Clear();
            int i = 1;
            foreach (var question in Questions)
            { 
                Console.WriteLine($"Question {i}\n" +
                                  "-----------------\n" +
                                  $"{question.Question}\n" +
                                  $"A. {question.Choise1}\n" +
                                  $"B. {question.Choise2}\n" +
                                  $"C. {question.Choise3}\n" +
                                  $"D. {question.Choise4}\n");

                Console.WriteLine("Your answer (A,B,C,D)");
                string a = Console.ReadLine();
                if (a=="A" || a=="B" || a=="C" || a=="D")
                {
                    Answers.Add(a);
                }
                else
                {
                    Console.WriteLine("Write A, B, C or D");
                }
                i++;
                Console.Clear();
            }
        }

        public static void MarkExam()
        {
            int right = 0;
            string wrongAnswers = "";

            for (int i = 0; i < Questions.Count; i++)
            {
                switch (Answers[i])
                {
                    case "A":
                        if (Questions[i].CorrectChoise == CorrectChoise.A)
                        {
                            right++;
                        }
                        else
                        {
                            wrongAnswers += i + " ";
                        }
                        break;
                    case "B":
                        if (Questions[i].CorrectChoise == CorrectChoise.B)
                        {
                            right++;
                        }
                        else
                        {
                            wrongAnswers += i + " ";
                        }
                        break;
                    case "C":
                        if (Questions[i].CorrectChoise == CorrectChoise.C)
                        {
                            right++;
                        }
                        else
                        {
                            wrongAnswers += i + " ";
                        }
                        break;
                    case "D":
                        if (Questions[i].CorrectChoise == CorrectChoise.D)
                        {
                            right++;
                        }
                        else
                        {
                            wrongAnswers += i + " ";
                        }
                        break;
                }
            }

            float percent = right / Questions.Count * 100;

            Console.WriteLine($"You got {percent} %. You got {right} questions correct out of {Questions.Count}.");

            if (percent >= 75)
            {
                Console.WriteLine("You passed the exam.");
            }
            else
            {
                Console.WriteLine("You failed the exam." +
                                  "The following questions were answered incorrectly:" +
                                  $"{wrongAnswers}");

            }

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
