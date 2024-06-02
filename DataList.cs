using StudentManagementSystem.models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    public static class DataList
    {
        public static List<user> UsersList = new List<user>();
        public static int studentID = 0001;
               
        public static void AddNewUsers()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"New User ID: {studentID} ");
            Console.CursorVisible = true;

            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter Date of Birth (DD/MM/YEAR): ");
            string dateOfBirth = Console.ReadLine();

            Console.Write("Enter Address: ");
            string address = Console.ReadLine();

            user user = new user(studentID, firstName, lastName, dateOfBirth, address);
            UsersList.Add(user);
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.White;

            studentID++;
        }

            
        public static void Modules_L()
        {
            Console.WriteLine("Available Modules are");
            Console.WriteLine(" 3251 GUI Prgramming");
            Console.WriteLine(" 3250 Programming  Project");
            Console.WriteLine(" 3302 DataStructure Structures and Algorithems");
            Console.WriteLine(" 3305 Signal And Systems");
            Console.WriteLine(" 3301 Analog Electronics");
            Console.WriteLine(" 3203 Electronic & Electrical Measurement");
            
            

        }
       
        
        public static void CreateModule(int userid,int moduleid)
        {
        
            foreach (var user in UsersList)
            {
               
                if(user.ID == userid){ 
                   
                    switch (moduleid)
                    {
                        case 3251:
                            Module GUI = new Module(3251, "GUI Prgramming", 2);
                            user.Modules.Add(GUI);
                            Console.WriteLine($"user {moduleid} is registed to {GUI.Name}");
                            break;
                        case 3250:
                            Module ProgrammingPro = new Module(3250, "Programming  Project", 3);
                            user.Modules.Add(ProgrammingPro);
                            Console.WriteLine($"user {moduleid} is registed to {ProgrammingPro.Name}");
                            break;
                        case 3302:
                            Module DataStructure = new Module(3302, "DataStructure Structures and Algorithems", 3);
                            user.Modules.Add(DataStructure);
                            Console.WriteLine($"user {moduleid} is registed to {DataStructure.Name}");
                            break;
                        case 3305:
                            Module Signal = new Module(3305, "Signal and Systems", 3);
                            user.Modules.Add(Signal);
                            Console.WriteLine($"user {moduleid} is registed to {Signal.Name}");
                            break;
                        case 3301:
                            Module Analog = new Module(3301, "Analog Electronics", 3);
                            Console.WriteLine($"user {moduleid} is registed to {Analog.Name}");
                            user.Modules.Add(Analog);
                            
                            break;
                        
                        case 3203:
                            Module Measurement = new Module(3203, "Measurement", 2);
                            user.Modules.Add(Measurement);
                            Console.WriteLine($"user {moduleid} is registed to {Measurement.Name}");
                            break;
                       
                        
                        default:
                            Console.WriteLine("Invalid Module Id");

                            break;


                    }
                    break;
                }
            }
            
        }
        
        
        public static void DisplayModules(user user_mod)
        {
            Console.SetCursorPosition(80, 0);
            int i = 1;
            Console.WriteLine("Registed Modules Are : ");

            foreach (var mod in user_mod.Modules)
            {
                Console.SetCursorPosition(80, i);
                Console.WriteLine($"| -> {mod.Id} {mod.Name}");
                i=i+1;
            }
            Console.SetCursorPosition(2, 0);
           

        }


        public static void print()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(55, 0);
            
            
            Console.WriteLine("ID");
            Console.SetCursorPosition(50,0);
            Console.WriteLine("First Name");
            Console.SetCursorPosition(70, 0);
            Console.WriteLine("Last Name");
            Console.SetCursorPosition(85, 0);
            Console.WriteLine("DateOfBirth");
            Console.SetCursorPosition(100, 0);
            Console.WriteLine("Address");
            Console.SetCursorPosition(110, 0);
            int i = 1;

            foreach (var user in UsersList)
            {
                i = i + 1;
                

                
                Console.WriteLine(user.ID);
                Console.SetCursorPosition(50, i);
                Console.WriteLine(user.FirstName);
                Console.SetCursorPosition(70, i);
                Console.WriteLine(user.LastName);
                Console.SetCursorPosition(85, i);
                Console.WriteLine(user.DateOfBirth);
                Console.SetCursorPosition(100, i);
                Console.WriteLine(user.Address);
                Console.SetCursorPosition(110, i);
                



            }
            Console.SetCursorPosition(2, 0);
            Console.ForegroundColor = ConsoleColor.White;
        }
         public static void print_short()
         {
             Console.ForegroundColor = ConsoleColor.Black;
             Console.SetCursorPosition(75, 0);
             int i = 1;
             Console.WriteLine("ID\tFirst Name\tLast Name");
             foreach (var user in UsersList)
             {
                 Console.SetCursorPosition(50, i);
                 i = i + 1;
                 Console.WriteLine($"{user.ID}\t{user.FirstName,-15}\t{user.LastName,-15}");
             }
             Console.SetCursorPosition(2, 0);
             Console.ForegroundColor = ConsoleColor.White;
         }

        
        public static void DeleteUser(user DeleteUser)
        {
            UsersList.Remove(DeleteUser);
           
        }
        
        

        public static void Display_one_user(user user1)
        {
           
            Console.WriteLine("ID\tFirst Name\tLast Name\tDOB\tAddress");
            Console.WriteLine($"{user1.ID}\t{user1.FirstName}\t{user1.LastName}\t{user1.DateOfBirth}\t{user1.Address}");

        }

    }
}
