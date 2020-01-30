using MyMailSender.Classes;
using System.Security;
using System.Windows;
using System.Windows.Controls;

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
                MB.MessageBoxError("Введите emailUser.");
                TextBoxEmail.Focus();
            }
            else if (string.IsNullOrEmpty(PasswordBox.Password))
            {
                MB.MessageBoxError("Введите пароль.");
                PasswordBox.Focus();
            }
            else if (string.IsNullOrEmpty(TextBoxEmailTo.Text))
            {
                MB.MessageBoxError("Введите emailUser, кому вы отправляете сообщение.");
                TextBoxEmail.Focus();
            }
            else if (string.IsNullOrEmpty(TextBoxMessage.Text))
            {
                MB.MessageBoxError("Введите сообщение.");
                TextBoxMessage.Focus();
            }
            else
            {
                string emailUser = TextBoxEmail.Text;
                SecureString password = PasswordBox.SecurePassword;
                string emailTo = TextBoxEmailTo.Text;

                MySender mySender = new MySender(emailUser, password, emailTo);

                string subjectMsg = TextBoxSubject.Text;
                string bodyMsg = TextBoxMessage.Text;

                mySender.Send(subjectMsg, bodyMsg);
            }
        }
    }
}
