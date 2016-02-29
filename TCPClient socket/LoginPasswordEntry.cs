using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPClient_socket
{
    class LoginPasswordEntry
    {
        string filePath = @"UsersInfo.json";
        string option = "";
        FileReader fr = new FileReader();
        FileWriter fw = new FileWriter();
        public void CheckingLoginPassword()
        {
            List<PersonInfo> InfoList = fr.JsonFileReader(filePath);
            DisplayOptions dis = new DisplayOptions();
            dis.EntryUserOptions();
            option = Console.ReadLine();
            Console.Clear();

            switch (option)
            {
               
                case "1":
                    Console.WriteLine("Enter Login :");
                    string loginName = Console.ReadLine();
                    Console.WriteLine("Enter Password: ");
                    string password = Console.ReadLine();
                    string passwordfound = InfoList.Find(x => x.Name == loginName).Password;
                    if (password== passwordfound)
                    {
                        ClientSocket cs = new ClientSocket();
                        string nicknameFound = InfoList.Find(x => x.Name == loginName).NickName;
                        cs.Start();
                    }
                    else
                    {
                        Console.WriteLine("Incorrect Login or Password");
                        Console.WriteLine("Please Try again .....");
                        Console.ReadLine();
                        Console.Clear();
                        CheckingLoginPassword();
                    }
                    break;
                case "2":
                    Console.WriteLine("Please enter your name :");
                    string name = Console.ReadLine();
                    Console.WriteLine("enter your last name:");
                    string lastName = Console.ReadLine();
                    Console.WriteLine("Please enter your NickName:");
                    string nickName = Console.ReadLine();
                    Console.WriteLine("Enter Your Password:");
                    string pass = Console.ReadLine();
                    Console.WriteLine("Enter Email:");
                    string email = Console.ReadLine();

                    InfoList.Add(new PersonInfo(name, lastName, nickName, pass, email));
                    CheckingLoginPassword();
            

                    break;
                case "3":
                    Environment.Exit(0);
                    break;

            }
            fw.JasonWriter(filePath, InfoList);

        }
    }
}
