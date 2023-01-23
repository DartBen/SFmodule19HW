using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetwork.PLL.Views
{
    public class UserFriendView
    {
        public void Show(IEnumerable<User> users)
        {
            if (users.Count() == 0 || users==null)
            {
                Console.WriteLine("У вас нет друзей. Найдите!");
                return;
            };


            Console.WriteLine("Ваши друзья");
            foreach (var user in users)
                Console.WriteLine($"Имя:{user.FirstName}. Фамилия:{user.LastName}. Почта:{user.Email}");

        }
    }
}
