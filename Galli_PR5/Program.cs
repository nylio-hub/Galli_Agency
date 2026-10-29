using Galli_HashLibrary;
using Galli_PR5.Models;
using System;

namespace Galli_PR5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Регистрация в системе Агентства Недвижимости\n");

            
            Console.Write("Введите логин (Email): ");
            string login = Console.ReadLine();

            Console.Write("Введите пароль: ");
            string password = Console.ReadLine();

            Console.Write("Выберите роль (1 - Покупатель, 2 - Продавец, 3 - Риелтор): ");
            string roleChoice = Console.ReadLine();

            
            HashGenerator hasher = new HashGenerator();
            string passwordHash = hasher.GenerateSha256Hash(password);

            
            Helper dbHelper = new Helper();

            bool loginExistsInUsers = dbHelper.FindUserByLogin(login) != null;
            bool loginExistsInSellers = dbHelper.FindSellerByLogin(login) != null;
            bool loginExistsInBuyers = dbHelper.FindBuyerByLogin(login) != null;
            bool loginExistsInAgents = dbHelper.FindAgentByLogin(login) != null;

            if (loginExistsInUsers || loginExistsInSellers || loginExistsInBuyers || loginExistsInAgents)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n[ОШИБКА] Пользователь с таким логином уже существует в системе!");
                Console.WriteLine("Пожалуйста, выберите другой логин.");
                Console.ResetColor();
                Console.WriteLine("\nНажмите любую клавишу для выхода...");
                Console.ReadKey();
                return;
            }

            
            try
            {
                switch (roleChoice)
                {
                    case "1": 
                        
                        var userBuyer = new Users
                        {
                            Login = login,
                            PasswordHash = passwordHash,
                            IsActive = true,
                            IsEmailConfirmed = false,
                            CreatedDate = DateTime.Now
                        };
                        dbHelper.CreateUser(userBuyer);

                        
                        var createdUser = dbHelper.FindUserByLogin(login);
                        int userId = createdUser.UserID;

                        
                        var buyer = new Buyers
                        {
                            UserID = userId,  
                            Login = login,
                            PasswordHash = passwordHash,
                            LastName = "Новый",
                            FirstName = "Покупатель",
                            Phone = "+70000000000",
                            RegDate = DateTime.Now
                        };
                        dbHelper.CreateBuyer(buyer);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nПокупатель успешно зарегистрирован в системе!");
                        Console.WriteLine($"Логин: {login}");
                        Console.WriteLine("Пароль сохранён в зашифрованном виде (SHA256).");
                        break;

                    case "2": 
                        var userSeller = new Users
                        {
                            Login = login,
                            PasswordHash = passwordHash,
                            IsActive = true,
                            IsEmailConfirmed = false,
                            CreatedDate = DateTime.Now
                        };
                        dbHelper.CreateUser(userSeller);

                       
                        var createdSeller = dbHelper.FindUserByLogin(login);
                        int sellerUserId = createdSeller.UserID;

                        
                        var seller = new Sellers
                        {
                            UserID = sellerUserId,  
                            Login = login,
                            PasswordHash = passwordHash,
                            LastName = "Новый",
                            FirstName = "Продавец",
                            Phone = "+70000000000",
                            RegDate = DateTime.Now
                        };
                        dbHelper.CreateSeller(seller);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nПродавец успешно зарегистрирован в системе!");
                        Console.WriteLine($"Логин: {login}");
                        Console.WriteLine("Пароль сохранён в зашифрованном виде (SHA256).");
                        break;

                    case "3": 
                        var userAgent = new Users
                        {
                            Login = login,
                            PasswordHash = passwordHash,
                            IsActive = true,
                            IsEmailConfirmed = false,
                            CreatedDate = DateTime.Now
                        };
                        dbHelper.CreateUser(userAgent);

                        
                        var createdAgent = dbHelper.FindUserByLogin(login);
                        int agentUserId = createdAgent.UserID;

                        
                        var agent = new Agents
                        {
                            UserID = agentUserId,  
                            Login = login,
                            PasswordHash = passwordHash,
                            LastName = "Новый",
                            FirstName = "Риелтор",
                            Phone = "+70000000000"
                        };
                        dbHelper.CreateAgent(agent);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nРиелтор успешно зарегистрирован в системе!");
                        Console.WriteLine($"Логин: {login}");
                        Console.WriteLine("Пароль сохранён в зашифрованном виде (SHA256).");
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n[ОШИБКА] Неверный выбор роли! Введите 1, 2 или 3.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n[ОШИБКА БД] Не удалось завершить регистрацию:");
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }

            Console.ResetColor();
            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}