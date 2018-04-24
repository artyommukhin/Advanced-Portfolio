using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Advanced_Portfolio
{
    //class that contains all method for program
    public static class Methods
    {
        //functions that make head of application
        public static void MakeHead()
        {
            Console.WriteLine("Multiple Choise Exam\n" +
                              "--------------------");
        }
        public static void MakeHead(string section)
        {
            string head = $"Multiple Choise Exam - {section}\n";
            string line = "";

            //line length depends on length of head
            for (int i = 0; i < head.Length - 1; i++)
            {
                line += "-";
            }
            Console.WriteLine(head + line);
        }

        //list that contains 30 questions 
        public static List<MultipleChoiceQuestion> Questions = new List<MultipleChoiceQuestion>(30);
        
        //list that contains user answers from StartExam()
        public static List<CorrectChoise> Answers = new List<CorrectChoise>();

        //create new question
        public static void CreateNewQuestion()
        {
            MakeHead("New Question");

            Console.WriteLine($"There are {Questions.Count} questions in the exam.\n");

            Console.WriteLine("Enter the question:");
            string newQ = Console.ReadLine();

            Console.WriteLine("Enter choice 1 for the question:");
            string newC1 = Console.ReadLine();

            Console.WriteLine("Enter choice 2 for the question:");
            string newC2 = Console.ReadLine();

            Console.WriteLine("Enter choice 3 for the question:");
            string newC3 = Console.ReadLine();

            Console.WriteLine("Enter choice 4 for the question:");
            string newC4 = Console.ReadLine();

            Console.WriteLine("Enter the correct choice (A, B, C, D):");
            //check if user's input is in correct form (A,B,C,D)
            Parse:
            if (!CorrectChoise.TryParse(Console.ReadLine(), true, out CorrectChoise cc))
            {
                //if input not in correct form
                Console.WriteLine("Write A, B, C or D");
                goto Parse;
            }

            //create new question object and putting all usser's inputs inside it 
            MultipleChoiceQuestion newQuestion = new MultipleChoiceQuestion(newQ, newC1, newC2, newC3, newC4, cc);
            Questions.Add(newQuestion);


            Console.WriteLine($"Successfully added question {Questions.Count} to exam.\n" +
                              "Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }

        //display all questions
        public static void DisplayAllQuestions()
        {
            MakeHead("Display All Questions");

            //iterating through questions list
            for (int i = 0; i < Questions.Count; i++)
            {
                var q = Questions[i];
                Console.WriteLine($"Question {i + 1}\n" +
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

        //edit question
        public static void EditQuestion()
        {
            MakeHead("Edit Question");

            Console.WriteLine("Enter the question number to edit:");
            //check if user's input is integer
            Input:
            if (!int.TryParse(Console.ReadLine(), out int i))
            {
                //if user inputs not integer
                Console.WriteLine("Write a number");
                goto Input;
            }

            //check if there is the user inputted index in the questions list 
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
                //check if user's input is in correct form
                Choice:
                if (!CorrectChoise.TryParse(Console.ReadLine(), true, out CorrectChoise cc))
                {
                    //if user's input not in correct form
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

        //delete question
        public static void DeleteQuestion()
        {
            MakeHead("Delete Question");

            Console.WriteLine("Enter the question number to delete:");
            //check if user's input is an integer
            Input:
            if (!int.TryParse(Console.ReadLine(), out int i))
            {
                //if user's input is not an integer
                Console.WriteLine("Write a number");
                goto Input;
            }

            //check if there is the user inputted index in the questions list
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
                        Console.WriteLine("press y or n");
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

        //import questions
        public static void ImportQuestions()
        {
            MakeHead("Import Questions");

            Console.WriteLine("Enter the location of the file to read from:");
            string filename = Console.ReadLine();
            if (File.Exists(filename))
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    //clear questions list
                    Questions.Clear();

                    //read all text
                    string allText = sr.ReadToEnd();

                    //split text into questions
                    string[] fullQuestions = allText.Split('-');
                    
                    //for each question from file
                    foreach (string fullQuestion in fullQuestions)
                    {
                        //getting rid of useless white space characters and cutting-off each string
                        string[] q = fullQuestion.Trim().Split('\n');
                        
                        //the first string is the question
                        string question = q[0].Substring(3);//Substring to cut-off letter and space (A. , B. , etc.)
                        string choise1 = q[1].Substring(3); 
                        string choise2 = q[2].Substring(3);
                        string choise3 = q[3].Substring(3);
                        string choise4 = q[4].Substring(3);
                        CorrectChoise.TryParse(q[5], true, out CorrectChoise cc);//don't forget to enter correct choise into file :)

                        //putting all question data into the new question and adding it into the list
                        var newQuestion = new MultipleChoiceQuestion(question, choise1, choise2, choise3, choise4, cc);
                        Questions.Add(newQuestion);
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

        //export questions
        public static void ExportQuestions()
        {
            MakeHead("Export Questions");

            Console.WriteLine("Enter the location of the file to save to:");
            string filename = Console.ReadLine();
            if (File.Exists(filename))
            {
                //to work with file we need to use StreamWriter class
                using (StreamWriter sw = new StreamWriter(filename))
                {
                    foreach (var q in Questions)
                    {
                        //if not last question
                        if (q != Questions[Questions.Count - 1])
                        {
                            sw.WriteLine($"{q.Question}\r\n" +
                                         $"A. {q.Choise1}\r\n" +
                                         $"B. {q.Choise2}\r\n" +
                                         $"C. {q.Choise3}\r\n" +
                                         $"D. {q.Choise4}\r\n" +
                                         "-");
                        }
                        //if last question
                        else
                        {
                            sw.WriteLine($"{q.Question}\r\n" +
                                         $"A. {q.Choise1}\r\n" +
                                         $"B. {q.Choise2}\r\n" +
                                         $"C. {q.Choise3}\r\n" +
                                         $"D. {q.Choise4}");

                        }
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

        //start exam
        public static void StartExam()
        {
            //delete all answers from Answers list from previous try
            Answers.Clear();
            //number of the question
            int i = 0;
            foreach (var question in Questions)
            {
                i++;
                Console.WriteLine($"Question {i}\n" +
                                  "-----------------\n" +
                                  $"{question.Question}\n" +
                                  $"A. {question.Choise1}\n" +
                                  $"B. {question.Choise2}\n" +
                                  $"C. {question.Choise3}\n" +
                                  $"D. {question.Choise4}\n");

                Console.WriteLine("Your answer (A,B,C,D)");
                //check if the input is in correct form
                Input:
                if (!CorrectChoise.TryParse(Console.ReadLine(), true, out CorrectChoise cc))
                {
                    //if input not in correct form
                    Console.WriteLine("Write A, B, C or D");
                    goto Input;
                }
                
                //adding user's answer to Answers list
                Answers.Add(cc);
                Console.Clear();
            }
        }

        //mark exam
        public static void MarkExam()
        {
            MakeHead("Mark Exam");

            //variable that counts the number of right answers
            int right = 0;

            //string that contains wring answers' numbers
            string wrongAnswers = "";

            //iterate through Questions list to compare CorrectChoise to users answer for each question
            for (int i = 0; i < Questions.Count; i++)
            {
                if (Questions[i].CorrectChoise == Answers[i])
                {
                    //incrementing right answers counter
                    right++;
                }
                else
                {
                    //adding the number of the wrong answer to the string
                    wrongAnswers += i + " ";
                }
            }
            //calculation of right answers percent
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