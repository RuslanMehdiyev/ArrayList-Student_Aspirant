using System;
using System.Collections;
using System.Collections.Generic;
namespace Student_Aspirant_ArrayMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Display("Hello to app that allows you to create a list of Students & Aspirants and make some changes over it.\nChoose what you want to do:\n");
            bool end = true;
            Student student = new Student();
            Aspirant aspirant = new Aspirant();
            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Display("1) Creating students list.");
                    Display("2) Creating aspirants list.");
                    Display("0) Exit.");
                    int choise = Convert.ToInt32(Console.ReadLine());
                    switch (choise)
                    {
                        case 1:
                            Case1(student);
                            break;
                        case 2:
                            Case2(aspirant);
                            break;
                        case 0:
                            Display("\nThank you. Bye)");
                            Console.ReadKey();
                            Environment.Exit(0);
                            break;
                        default:
                            Display("\nSorry, we have only 3 choises\n");
                            break;
                    }
                }
                catch
                {
                    Display("\nError. Please select from the list below\n");
                }
            } while (end == true);
        }
        static void Display(string message)
        {
            Console.WriteLine(message);
        }
        static void Case1(Student student)
        {
            Display("Methods of ArrayList were used in the Student class");
            bool end = true;
            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Display("1) Add student(s).");
                    Display("2) Display the number of student(s).");
                    Display("3) Delete student.");
                    Display("4) Show all students.");
                    Display("5) Show after sorting.");
                    Display("6) Display student by ordinal index.");
                    Display("7) Back to menu.");
                    Display("0) Exit.");
                    int choise = Convert.ToInt32(Console.ReadLine());
                    switch (choise)
                    {
                        case 1:
                            student.AddPerson();
                            break;
                        case 2:
                            student.NumOfPerson();
                            break;
                        case 3:
                            student.DeletePerson();
                            break;
                        case 4:
                            student.Print();
                            break;
                        case 6:
                            student.PrintbyIndex();
                            break;
                        case 7:
                            end = false;
                            break;
                        case 5:
                            student.SortStudent();
                            break;
                        case 0:
                            Display("\nThank you. Bye)");
                            Console.ReadKey();
                            Environment.Exit(0);
                            break;
                        default:
                            Display("\nSorry, we have only 6 cases\n");
                            break;
                    }
                }
                catch
                {
                    Display("\nError. Please select from the list or check if you do not have a list yet\n");
                }
            } while (end == true);
        }
        static void Case2(Aspirant aspirant)
        {
            Display("Methods of LinkedList were used in the Aspirant class");
            bool end = true;
            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Display("1) Add aspirant(s).");
                    Display("2) Display the number of aspirant(s).");
                    Display("3) Delete last added aspirant.");
                    Display("4) Show all aspirants.");
                    Display("5) Display aspirant by ordinal index.");
                    Display("6) Back to menu.");
                    Display("0) Exit.");
                    int choise = Convert.ToInt32(Console.ReadLine());
                    switch (choise)
                    {
                        case 1:
                            aspirant.AddPerson();
                            break;
                        case 2:
                            aspirant.NumOfPerson();
                            break;
                        case 3:
                            aspirant.DeletePerson();
                            break;
                        case 4:
                            aspirant.Print();
                            break;
                        case 5:
                            aspirant.PrintbyIndex();
                            break;
                        case 6:
                            end = false;
                            break;
                        case 0:
                            Display("\nThank you. Bye)");
                            Console.ReadKey();
                            Environment.Exit(0);
                            break;
                        default:
                            Display("\nSorry, we have only 6 cases\n");
                            break;
                    }
                }
                catch
                {
                    Display("\nError. Please select from the list or check if you do not have a list yet\n");
                }
            } while (end == true);
        }
    }
    public abstract class Person
    {
        public string Surname { get; set; }
        public int YearOfStudy { get; set; }
        public int ID { get; set; }
        public abstract void Print();
        public abstract void AddPerson();
        public abstract void DeletePerson();
        public abstract void PrintbyIndex();
        public abstract void NumOfPerson();
    }
    public class Student : Person
    {
        ArrayList arrayList = new ArrayList();
        public override void AddPerson()
        {
            Console.WriteLine("How many students you want to add?");
            int number = ValidationClass.Validation();
            for (int i = 0; i < number; i++)
            {
                Console.Write($"Enter the Surname of {i + 1} student:");
                Surname = ValidationClass.ValidationString();
                Console.Write($"Enter the {Surname}'s year of study:");
                YearOfStudy = ValidationClass.Validation();
                Console.Write($"Enter the {Surname}'s ID number:");
                ID = ValidationClass.ValidationID();
                arrayList.Add($"Surname : {Surname}\nYear of study: {YearOfStudy}\nID: {ID}");
                Console.WriteLine("\nStudent Aded.\n");
            }
        }
        public void SortStudent()
        {
            arrayList.Sort();
            foreach (var i in arrayList)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"\n{i}\n");
            }
            if (arrayList.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nEmpty list.\n");
            }
        }
        public override void DeletePerson()
        {
            Console.WriteLine("Type the number of student you want to delete:");
            int index = ValidationClass.ValidationForWrongInput();
            arrayList.RemoveAt(index - 1);
            Console.WriteLine("\nDeleted successfully\n");
        }
        public override void PrintbyIndex()
        {
            Console.WriteLine("\nStudent under which number do you want to display?");
            int index = ValidationClass.ValidationForWrongInput();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\n{arrayList[index - 1]}\n");
        }
        public override void NumOfPerson()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\nThe number of created student's list is:{arrayList.Count}\n");
        }
        public override void Print()
        {
            int k = 0;
            foreach (var i in arrayList)
            {
                k++;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Student({k})");
                Console.WriteLine($"\n{i}\n");
            }
            if (arrayList.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nEmpty list.\n");
            }
        }
    }
    class Aspirant : Person
    {
        LinkedList<string> aspirant = new LinkedList<string>();
        public string Dissertation { get; set; }
        public override void AddPerson()
        {
            Console.WriteLine("How many aspirants you want to add?");
            int number = ValidationClass.Validation();
            for (int i = 0; i < number; i++)
            {
                Console.Write($"Enter the Surname of {i + 1} aspirant:");
                Surname = ValidationClass.ValidationString();
                Console.Write($"Enter the {Surname}'s year of study:");
                YearOfStudy = ValidationClass.Validation();
                Console.Write($"Enter the {Surname}'s ID number:");
                ID = ValidationClass.ValidationID();
                Console.Write($"Enter the {Surname}'s Dissertation topic:");
                Dissertation = ValidationClass.ValidationString();
                aspirant.AddLast($"Surname : {Surname}\nYear of study: {YearOfStudy}\nID: {ID}\nDissertation topic: {Dissertation}");
                Console.WriteLine("\nAspirant Aded.\n");
            }
        }
        public override void DeletePerson()
        {
            aspirant.RemoveLast();
            Console.WriteLine("\nDeleted successfully\n");
        }
        public override void PrintbyIndex()
        {
            Console.WriteLine("\nAspirant under which number do you want to display?");
            int index = ValidationClass.ValidationForWrongInput();
            Console.ForegroundColor = ConsoleColor.White;
            foreach (string item in aspirant)
            {
                index--;
                if (index == 0)
                {
                    Console.WriteLine($"\n{item}\n");
                }
                else
                {
                    Console.WriteLine("\nPlease make sure you have entered the correct index number of aspirant.\n");
                }
            }
            if (aspirant.Count == 0)
            {
                Console.WriteLine("\nEmpty list\n");
            }
        }
        public override void NumOfPerson()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\nThe number of created aspirant's list is:{aspirant.Count}\n");
        }
        public override void Print()
        {
            int number = 0;
            foreach (var i in aspirant)
            {
                number++;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Aspirant({number})");
                Console.WriteLine($"\n{i}\n");
            }
            if (aspirant.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nEmpty list.\n");
            }
        }
    }
    static class ValidationClass
    {
        public static int ValidationMain()
        {
            while (true)
            {
                if (Int32.TryParse(Console.ReadLine(), out int value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("\nError! Please enter a valid data\n");
                }
            }
        }
        public static int ValidationForWrongInput()
        {
            while (true)
            {
                if (Int32.TryParse(Console.ReadLine(), out int value) && value > 0 && value < 10)
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("\nError! Try again.\n");
                }
            }
        }
        public static int Validation()
        {
            while (true)
            {
                if (Int32.TryParse(Console.ReadLine(), out int value) && value > 0 && value < 10)
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("\nError! Year of study and number of added students cannot be more than 10\n");
                }
            }
        }
        public static int ValidationID()
        {
            while (true)
            {
                if (Int32.TryParse(Console.ReadLine(), out int value) && value > 0 && value < 1000000)
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("\nError! ID consists of 6 digits of number\n");
                }
            }
        }
        public static string ValidationString()
        {
            string invalid = "1234567890,.;<>'/-=+?!@`\t#%$^*~(\\)%{}[]:0 ";
            int count;
            string Info;
            do
            {
                Info = Console.ReadLine();
                count = EmptyString(Info);
                foreach (int i in Info)
                {
                    foreach (int j in invalid)
                    {
                        if (j == i)
                        {
                            count++;
                        }
                    }
                }
                if (count > 0)
                {
                    Console.WriteLine("Please enter valid data");
                }
            } while (count != 0);
            Info = Info.ToUpper()[0] + Info.Substring(1).ToLower();
            return Info;
        }
        public static int EmptyString(string name)
        {
            int count = 0;
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Empty string.");
                count++;
            }
            return count;
        }
    }
}