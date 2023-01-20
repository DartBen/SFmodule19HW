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
            if (users.Count() == 0)
            {
                Console.WriteLine("У вас нет друзей. Найдите!");
                return;
            };


            Console.WriteLine("Ваши друзья");
            foreach (var user in users)
                Console.WriteLine("Имя:{0}. Фамилия:{1}. Почта:{2}", user.FirstName, user.LastName, user.Email);

            users.ToList().ForEach(friend =>
            {
                Console.WriteLine("Почтовый адрес друга: {0}. Имя друга: {1}. Фамилия друга: {2}", friend.Email, friend.FirstName, friend.LastName);
            });
        }
    }
}
