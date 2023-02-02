using internet_sellings.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace internet_sellings.classes
{
    public class CurrantUser : User
    {
        static private CurrantUser Instance;
        private CurrantUser() { }
        private CurrantUser(User user) { 
            if (user != null)
            {
                this.Id = user.Id;
                this.Name = user.Name;
                this.Login = user.Login;
                this.Role = user.Role;
                this.Role_Id = user.Role_Id;
            }
        }
        new private string Login { get; set; }
        new private string Password { get; set; }

        /// <summary>
        /// Возвращает булевое значение авторизирован ли пользователь.
        /// </summary>
        /// <param name="logout">Деактивировать текущую авторизацию пользователя.</param>
        /// <returns>true - пользователь авторизирован. False - пользователь не авторизирован.</returns>
        public bool IsLogged(bool logout = false)
        {
            if (logout) Instance = new CurrantUser();

            return this.Login != null && this.Role != null && this.Name != null;
        }
        static public CurrantUser AuthUser(User user)
        {
            User result = ApplicationContext
                        .GetInstance()
                        .Users
                        .FirstOrDefault(rec => rec.Login == user.Login && rec.Password == user.Password);

            Instance = new CurrantUser(result);

            return Instance;
        }
        static public CurrantUser GetInstance()
        {
            if (Instance == null) Instance = new CurrantUser();

            return Instance;
        }
    }
}
