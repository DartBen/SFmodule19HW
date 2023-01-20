using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.PLL.Views
{
    public class AddFriendView
    {
        UserService userService;
        public AddFriendView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show(User user)
        {
            try
            {
                var friendUserData = new FriendUserData();

                Console.WriteLine("Введите почтовый адрес вашего друга: ");

                friendUserData.FriendEmail = Console.ReadLine();
                friendUserData.UserId = user.Id;

                this.userService.AddFriend(friendUserData);

                SuccessMessage.Show("Друг был добавлен в ваш список.");
            }

            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователя с таким почтовым адресом не существует.");
            }

            catch (Exception)
            {
                AlertMessage.Show("Произоша ошибка при добавлении друга.");
            }

        }
    }
}
