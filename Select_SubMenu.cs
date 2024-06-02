using StudentManagementSystem;
using StudentManagementSystem.models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

//SELECT USER SUB MENU

namespace UserMainMenuApp
{
    public class Select_SubMenu
    {
        public int ColPos2 { get; set; }
        public int RowPos2 { get; set; }
        public int SelectedItem2 { get; set; }

      
        public List<MenuItem> MenuItems2 { get; set; }
                
        public Select_SubMenu()
        {
            ColPos2 = 15;
            RowPos2 = 8;
            SelectedItem2 = 0;
            MenuItems2 = new List<MenuItem>
            {
                new MenuItem("Modify User",true),
                new MenuItem("Add Modules",false),
                new MenuItem("Remove Modules",false),
                new MenuItem("Add Grade",false),
                new MenuItem("Delete User",false),
                new MenuItem("Back",false)
            };
        }

       

        public void DisplaySubMenu(user get_user)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Clear();
            Console.CursorVisible = false;
            bool running2 = true;
            bool display2 = true;

            while (running2)
            {
                Console.SetCursorPosition(ColPos2, RowPos2);

                for (int i = 0; i < MenuItems2.Count; i++)
                {
                    Console.SetCursorPosition(ColPos2, RowPos2 + i);

                    if (MenuItems2[i].IsSelected)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        if (display2 == true) Console.Write(MenuItems2[i].Title);
                    }
                    else
                    {

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Red;
                        if (display2 == true) Console.Write(MenuItems2[i].Title);
                    }

                }

                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.DownArrow)
                {
                    MenuItems2[SelectedItem2].IsSelected = false;
                    SelectedItem2 = (SelectedItem2 + 1) % MenuItems2.Count;
                   MenuItems2[SelectedItem2].IsSelected = true;
                }

                if (key.Key == ConsoleKey.UpArrow)
                {
                    MenuItems2[SelectedItem2].IsSelected = false;
                    SelectedItem2 = SelectedItem2 - 1;

                    if (SelectedItem2 < 0)
                    {
                        SelectedItem2 = MenuItems2.Count - 1;
                    }

                    MenuItems2[SelectedItem2].IsSelected = true;
                }

                if (key.Key == ConsoleKey.Enter)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(2, 0);
                                                       
                    bool stop2 = false;
                    
                    while (!stop2)
                    {
                                                
                        switch (MenuItems2[SelectedItem2].Title)
                        {
                            case "Modify User":
                                Console.Clear();
                                Console.SetCursorPosition(20, 0);
                                Console.WriteLine("MODIFY USER");
                                Console.SetCursorPosition(0, 2);
                                Console.CursorVisible= true;
                                
                                
                                DataList.Display_one_user(get_user);
                                Console.WriteLine("1).change First Name");
                                Console.WriteLine("2).change Last Name");
                                Console.WriteLine("3).change Date of Birth Name");
                                Console.WriteLine("4).change Address");
                                string y=Console.ReadLine();
                                
                                switch (y)
                                {
                                    case "1":
                                        Console.WriteLine("Enter the First Name: ");
                                        get_user.FirstName = Console.ReadLine();
                                        DataList.Display_one_user(get_user);
                                        break;

                                    case "2":
                                        Console.WriteLine("Enter the Last Name: ");
                                        get_user.LastName = Console.ReadLine();
                                        DataList.Display_one_user(get_user);
                                        break;

                                    case "3":
                                        Console.WriteLine("Enter the Date of Birth Name: ");
                                        get_user.DateOfBirth = Console.ReadLine();
                                        DataList.Display_one_user(get_user);
                                        break;

                                    case "4":
                                        Console.WriteLine("Enter the Address Name: ");
                                        get_user.Address = Console.ReadLine();
                                        DataList.Display_one_user(get_user);
                                        break;

                                    default:
                                        Console.WriteLine("Your Entered Index Is Invalied");
                                        break;
                                }
                                
                                                         

                                Console.CursorVisible = false;
                                Console.WriteLine("Press any key to insert again");
                                Console.SetCursorPosition(50, 24);
                                Console.ForegroundColor = ConsoleColor.White;
                                break;

                            case "Add Modules":
                                Console.Clear();
                                DataList.DisplayModules(get_user);
                                Console.WriteLine("You selected Add Modules");
                                DataList.Modules_L();
                                DataList.Display_one_user(get_user);
                                Console.WriteLine($"\nEnter the module id to Add module to user {get_user.FirstName}");
                                int ModuleID = Convert.ToInt32(Console.ReadLine());
                                bool AddedID = false;
                                foreach (var module in get_user.Modules)
                                {
                                    if (module.Id == ModuleID)
                                    {
                                        Console.WriteLine("module is already Added");
                                        AddedID = true;
                                        break;
                                    }


                                }
                                if (AddedID == false) DataList.CreateModule(get_user.ID, ModuleID);
                                
                                DataList.DisplayModules(get_user);
                               

                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.SetCursorPosition(50, 24);
                                Console.WriteLine("Press any key to insert again");
                                Console.ForegroundColor = ConsoleColor.White;
                                break;

                            case "Delete User":

                                Console.Clear();
                                Console.WriteLine("Delete User");
                                DataList.Display_one_user(get_user);
                                Console.WriteLine("\nDo you want to delete this User please enter y/n");
                                string x1 = Console.ReadLine().ToLower();

                                if (x1 =="y" )
                                {
                                    DataList.DeleteUser(get_user);
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"User {get_user.FirstName} is Removed Successfuly.....");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                
                                running2 = false;
                                stop2 = true;
                                break;

                            case "Remove Modules":

                                Console.Clear();
                                DataList.DisplayModules(get_user);
                                Console.WriteLine("Remove Modules");
                                DataList.Display_one_user(get_user);
                                Console.WriteLine($"\nEnter the module id to delete module from user {get_user.FirstName}");
                                int idmodule_r = Convert.ToInt32(Console.ReadLine());
                                bool isdeleted = false;
                                foreach (var mod in get_user.Modules)
                                {
                                    if (mod.Id == idmodule_r)
                                    {
                                        get_user.Modules.Remove(mod);
                                        isdeleted = true;
                                        break;
                                    }


                                }
                                Console.Clear();

                                if (isdeleted == false) Console.WriteLine("Your entered module already deleted or invalid module id");
                                DataList.Display_one_user(get_user);
                                DataList.DisplayModules(get_user);
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.SetCursorPosition(50, 24);
                                Console.WriteLine("Press any key to insert again");
                                Console.ForegroundColor = ConsoleColor.White;

                                break;

                            case "Add Grade":

                                Console.Clear();
                                DataList.DisplayModules(get_user);
                                Console.WriteLine("You Selected Remove Modules");
                                DataList.Display_one_user(get_user);
                                Console.WriteLine($"\nEnter the module ID of the desired module to add the grade {get_user.FirstName}");
                                int Ent_moduleID =Convert.ToInt32(Console.ReadLine());
                                bool module_reg = false;
                                foreach (var mod in get_user.Modules)
                                {
                                    if(mod.Id == Ent_moduleID)
                                    {
                                        Console.WriteLine("Enter the Grade\n");
                                        Console.WriteLine("a). A\nb). B\nc). C\nd). E");
                                        string grade= Console.ReadLine().ToLower();
                                        module_reg= true;
                                        switch(grade)
                                        {
                                            case "a":
                                                mod.Grade_point = 4;
                                                Console.WriteLine("Grade A added");
                                                break;
                                            case "b":
                                                mod.Grade_point = 3;
                                                Console.WriteLine("Grade B added");
                                                break;
                                            case "c":
                                                mod.Grade_point = 2;
                                                Console.WriteLine("Grade C added");
                                                break;
                                            case "d":
                                                mod.Grade_point = 0;
                                                Console.WriteLine("Grade E added");
                                                break;
                                            default: 
                                                Console.WriteLine("Your Entered Gread is Invalied");
                                                break;
                                        }


                                        break;
                                    }
                                }
                                
                                if (module_reg == false) 
                                { Console.WriteLine("Invalid Index !"); }
                                
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.SetCursorPosition(50, 24);
                                Console.WriteLine("Press Any Key To Insert Again");
                                Console.ForegroundColor = ConsoleColor.White;

                                break;

                            case "Back":

                                Console.Clear(); 
                                running2 = false;
                                stop2 = true;
                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                                break;

                            default:
                                Console.Clear();
                                Console.WriteLine("INVALIED....");
                                break;
                        }

                        if (stop2 != true)
                        {
                            Console.SetCursorPosition(50, 25);
                            Console.WriteLine("Press [(B/b)->(Enter)] to Back MainMenu");
                            string y2 = Console.ReadLine().ToLower();
                            Console.Clear();
                            if (y2 == "b")
                            {
                                stop2 = true;

                            }
                            Console.SetCursorPosition(2, 0);
                        }
                        

                    }


                }
            }
        }

    };
}
