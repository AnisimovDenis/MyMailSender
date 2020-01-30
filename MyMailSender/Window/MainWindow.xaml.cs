using MyMailSender.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyMailSender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MenuItemExit.Click += delegate { Application.Current.Shutdown(); };
        }

        private void btnSendMessage_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxEmail.Text))
            {
                MB.MessageBoxError("Введите email.");
                TextBoxEmail.Focus();
            }
            else if (string.IsNullOrEmpty(TextBoxPassword.Password))
            {
                MB.MessageBoxError("Введите пароль.");
                TextBoxPassword.Focus();
            }
            else if (string.IsNullOrEmpty(TextBoxTo.Text))
            {
                MB.MessageBoxError("Введите email, кому вы отправляете сообщение.");
                TextBoxEmail.Focus();
            }
            else if (string.IsNullOrEmpty(TextBoxMessage.Text))
            {
                MB.MessageBoxError("Введите сообщение.");
                TextBoxMessage.Focus();
            }
            else
            {
                try
                {
                    using (var message = new MailMessage(TextBoxEmail.Text, TextBoxTo.Text))
                    {
                        message.Subject = TextBoxSubject.Text;
                        message.Body = TextBoxMessage.Text;


                        const string serverAddress = "smtp.mail.ru";
                        const int serverPort = 25; 
                        using (var client = new SmtpClient(serverAddress, serverPort))
                        {
                            client.EnableSsl = true;

                            var userName = TextBoxEmail.Text;
                            //var user_password = PasswordEdit.Password;
                            SecureString userPassword = TextBoxPassword.SecurePassword;

                            client.Credentials = new NetworkCredential(userName, userPassword);

                            client.Send(message);

                            MessageBox.Show("Почта отправлена!", "Ура!!!",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
