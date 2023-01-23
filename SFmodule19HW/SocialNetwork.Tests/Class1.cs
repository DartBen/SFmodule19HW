using NUnit.Framework;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Entities;
using SocialNetwork.PLL.Views;

namespace SocialNetwork.Tests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Test1()
        {
            //общая часть
            var userService = new UserService();
            var messageService = new MessageService();

            var mainView = new MainView();
            var registrationView = new RegistrationView(userService);
            var authenticationView = new AuthenticationView(userService);
            var userDataUpdateView = new UserDataUpdateView(userService);
            var messageSendingView = new MessageSendingView(messageService, userService);
            var userIncomingMessageView = new UserIncomingMessageView();
            var userOutcomingMessageView = new UserOutcomingMessageView();
            //конец общей части

            UserRegistrationData userRegistrationData = new UserRegistrationData();

            //Console.WriteLine("Для создания нового профиля введите ваше имя:");
            userRegistrationData.FirstName = "TestFirstName";

            //Console.Write("Ваша фамилия:");
            userRegistrationData.LastName = "TestLastName";

            //Console.Write("Пароль:");
            userRegistrationData.Password = "12345678";

            //Console.Write("Почтовый адрес:");
            userRegistrationData.Email = "Test@mail.ru";

            userService.Register(userRegistrationData);

            UserAuthenticationData userAuthenticationData = new UserAuthenticationData();
            userAuthenticationData.Email = userRegistrationData.Email;
            userAuthenticationData.Password = userRegistrationData.Password;


            var user = userService.Authenticate(userAuthenticationData);

            var messageSendingData = new MessageSendingData();

            messageSendingData.RecipientEmail= userRegistrationData.Email;
            messageSendingData.Content = "G";
            messageSendingData.SenderId = user.Id;

            messageService.SendMessage(messageSendingData);

            user = userService.FindById(user.Id);
            //Console.WriteLine(user.OutgoingMessages.Count());

            Assert.True(user.OutgoingMessages.Count()==user.IncomingMessages.Count());
        }

    }
}