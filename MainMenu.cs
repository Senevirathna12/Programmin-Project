using StudentManagementSystem;
using StudentManagementSystem.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;



namespace UserMainMenuApp
{
    public class MainMenu
    {
        public int ColPos { get; set; }
        public int RowPos { get; set; }
        public int SelectedItem{get; set;}

        

        Select_SubMenu submenu = new Select_SubMenu();
        public List<MenuItem> MenuItems { get; set; }
       


        public MainMenu()
        {
            ColPos = 50;
            RowPos = 12;
            SelectedItem = 0;
            MenuItems = new List<MenuItem>
            {
                new MenuItem("Add User",true),
                new MenuItem("Select User",false),
                new MenuItem("Delete User",false),
                new MenuItem("Display All Users",false),
                new MenuItem("Quit",false)
            };
        }
     
      


        public void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            bool running = true;
            bool display=true;

            while (running)
            {
                Console.CursorVisible =false;
                Console.SetCursorPosition(ColPos, RowPos);

                for(int i = 0; i<MenuItems.Count; i++)
                {
                    Console.SetCursorPosition(ColPos, RowPos + i);
                    if (MenuItems[i].IsSelected)
                    {

                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        if(display==true) Console.Write(MenuItems[i].Title);
                    }
                    else
                    {

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        if (display == true) Console.Write(MenuItems[i].Title);
                    }
                    
                }

                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.DownArrow) 
                { 
                    MenuItems[SelectedItem].IsSelected = false;
                    SelectedItem = (SelectedItem+1)%MenuItems.Count;
                    MenuItems[SelectedItem].IsSelected = true;
                }

                if(key.Key == ConsoleKey.UpArrow)
                {
                    MenuItems[SelectedItem].IsSelected = false;
                    SelectedItem = SelectedItem - 1;

                    if(SelectedItem < 0)
                    {
                        SelectedItem = MenuItems.Count - 1;
                    }

                    MenuItems[SelectedItem].IsSelected = true;
                }

                if (key.Key == ConsoleKey.Enter)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(2, 0);
                                                 
                    bool stop = false;
                   
                    while (!stop)
                    {
                       
                        switch (MenuItems[SelectedItem].Title)
                        {
                            case "Add User":
                                Console.Clear();
                                DataList.print_short();
                                Console.WriteLine("Add Your New User");
                                DataList.AddNewUsers();
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.SetCursorPosition(50, 25);
                                Console.WriteLine("Press any key to Add another user");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.SetCursorPosition(2, 0);

                                break;
                            case "Select User":
                                
                                Console.Clear();
                                DataList.print_short();
                                Console.WriteLine("Select Your User");
                                Console.WriteLine("Enter the Uers Id");
                                int userID = Convert.ToInt32(Console.ReadLine());
                                bool userID_valid = false;
                                foreach(var user in DataList.UsersList)
                                {
                                    if(user.ID == userID)
                                    {
                                        userID_valid=true;
                                        submenu.DisplaySubMenu(user);
                                        break;
                                    }
                                }
                                if(userID_valid==false) { Console.WriteLine("invalid user ID"); }


                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.SetCursorPosition(50, 25);
                                Console.WriteLine("Press any key to select user again");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.SetCursorPosition(2, 0);

                                break;

                            case "Delete User":

                                Console.Clear();
                                DataList.print_short();
                                Console.WriteLine("Selected Delete User");
                                Console.WriteLine("Enter the user Id ");
                                int delete_id=Convert.ToInt32(Console.ReadLine());
                                bool is_user_valid_d=false;
                                foreach (var user in DataList.UsersList)
                                {
                                    if (user.ID == delete_id)
                                    {
                                        DataList.Display_one_user(user);
                                        Console.WriteLine("\nDo you want to delete this User y/n");
                                        string x = Console.ReadLine();
                                        if ((x == "YES") || (x == "yes"))
                                        {
                                            DataList.DeleteUser(user);
                                            is_user_valid_d=true;
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            Console.WriteLine($"User {user.ID} is Removed Successfuly...");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }

                                        break;
                                    }
                                }
                                if (is_user_valid_d == false) { Console.WriteLine("invalid user ID or User was already Deleted \a"); }

                          
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.SetCursorPosition(50, 25);
                                Console.WriteLine("Press any key to insert again");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.SetCursorPosition(2, 0);
                                break;

                            case "Display All Users":
                                Console.Clear();
                                Console.WriteLine("You Selected Display All Users");
                                DataList.print();
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.SetCursorPosition(50, 25);
                                Console.WriteLine("Press any key to insert again");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.SetCursorPosition(2, 0);


                                break;

                            case "Quit":
                                Console.Clear();
                                Console.SetCursorPosition(50, 15);
                              
                                Console.WriteLine("You Selected Quit" +
                                    "  Exiting.....\a");
                                running = false;
                                stop = true;
                               
                                break; 
                               
                            default:
                                Console.Clear();
                                Console.WriteLine("Invalid ");
                                break;
                        }
                        if (stop!= true)
                        {
                            Console.SetCursorPosition(50, 26);
                            Console.WriteLine("Press (B/b)->(Enter) to Back Main MainMenu");
                            string response = Console.ReadLine().ToLower();
                            Console.Clear();
                            if ((response == "B")||(response=="b"))
                            {
                                stop = true;
                            }
                            Console.SetCursorPosition(2, 0);
                        }
                        
                    }


                }
            }
        }

    };
}
