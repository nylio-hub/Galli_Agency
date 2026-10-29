using Galli_PR5.Models;
using System;
using System.Linq;

namespace Galli_PR5
{
    
    internal class Helper
    {
        private static AgencyEntities _context;

        
        public static AgencyEntities GetContext()
        {
            if (_context == null)
            {
                _context = new AgencyEntities();
            }
            return _context;
        }

        
        public void CreateUser(Users user)
        {
            try
            {
                var context = GetContext();
                context.Users.Add(user);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при добавлении пользователя в таблицу Users: {ex.Message}");
            }
        }

        public Users FindUserByLogin(string login)
        {
            try
            {
                var context = GetContext();
                return context.Users.FirstOrDefault(x => x.Login == login);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[ОШИБКА БД] Не удалось проверить логин в таблице Users: {ex.Message}");
                Console.ResetColor();
                return null;
            }
        }

        
        public void CreateSeller(Sellers seller)
        {
            try
            {
                var context = GetContext();
                context.Sellers.Add(seller);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при добавлении продавца в таблицу Sellers: {ex.Message}");
            }
        }

        public Sellers FindSellerByLogin(string login)
        {
            try
            {
                var context = GetContext();
                return context.Sellers.FirstOrDefault(x => x.Login == login);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[ОШИБКА БД] Не удалось проверить логин в таблице Sellers: {ex.Message}");
                Console.ResetColor();
                return null;
            }
        }

        
        public void CreateBuyer(Buyers buyer)
        {
            try
            {
                var context = GetContext();
                context.Buyers.Add(buyer);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при добавлении покупателя в таблицу Buyers: {ex.Message}");
            }
        }

        public Buyers FindBuyerByLogin(string login)
        {
            try
            {
                var context = GetContext();
                return context.Buyers.FirstOrDefault(x => x.Login == login);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[ОШИБКА БД] Не удалось проверить логин в таблице Buyers: {ex.Message}");
                Console.ResetColor();
                return null;
            }
        }

        // ===== AGENTS =====
        public void CreateAgent(Agents agent)
        {
            try
            {
                var context = GetContext();
                context.Agents.Add(agent);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при добавлении риелтора в таблицу Agents: {ex.Message}");
            }
        }

        public Agents FindAgentByLogin(string login)
        {
            try
            {
                var context = GetContext();
                return context.Agents.FirstOrDefault(x => x.Login == login);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[ОШИБКА БД] Не удалось проверить логин в таблице Agents: {ex.Message}");
                Console.ResetColor();
                return null;
            }
        }
    }
}