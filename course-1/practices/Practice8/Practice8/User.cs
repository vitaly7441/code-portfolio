using System;
using System.Xml.Linq;

namespace Practice8
{
	public class User
	{
		private string _username, _password, _email;

        public User(string username, string password, string email) {
            _username = username;
            _email = email;

            if (password.Length < 6)
            {
                Console.WriteLine("Пароль менее 6 символов");
            }
            else
            {
                _password = password;
            }

            if (email.Contains('@') != true)
            {
                Console.WriteLine("Введите корректный email!");
            }
            else
            {
                _email = email;
            }
        }

        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        public void ChangePassword(string oldPassword, string newPassword) {
            if (oldPassword != _password)
            {
                Console.WriteLine("Неверный пароль");
            }
            else {
                _password = newPassword;
            }
        }

        public bool Authenticate(string password) {
            if (_password == password)
            {
                return true;
            }
            else {
                return false;
            }
        }
    }
}

