using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Text;

namespace MyMailSender.Classes
{
    /// <summary>
    /// Класс для отправки сообщения на почту mail.ru
    /// </summary>
    class MySender
    {
        private string emailUser;
        private SecureString passwordUser;

        private string emailTo;

        /// <summary>
        /// Принимает email и пароль данного пользвателя, 
        /// а также email, кому отправляется сообщение
        /// </summary>
        /// <param name="emailUser">email пользователя</param>
        /// <param name="passwordUser">пароль пользвателя</param>
        /// <param name="emailTo">email, кому отправляется сообщение</param>
        public MySender(string emailUser, SecureString passwordUser,
            string emailTo)
        {
            this.emailUser = emailUser;
            this.passwordUser = passwordUser;
            this.emailTo = emailTo;
        }

        /// <summary>
        /// Отправляет сообщение
        /// </summary>
        /// <param name="subjectMessage">Заголовок сообщения</param>
        /// <param name="bodyMessage">Текст сообщения</param>
        public void Send(string subjectMessage, string bodyMessage)
        {
            try
            {
                using (var mailMessage = new MailMessage(this.emailUser, this.emailTo))
                {
                    mailMessage.Subject = subjectMessage;
                    mailMessage.Body = bodyMessage;

                    const string serverAddress = "smtp.mail.ru";
                    const int serverPort = 25;

                    using (var client = new SmtpClient(serverAddress, serverPort))
                    {
                        client.EnableSsl = true;
                        client.Credentials = new NetworkCredential(this.emailUser, this.passwordUser);
                        client.Send(mailMessage);

                        MB.MessageBoxInfo("Сообщение успешно отправлено.");
                    }
                }
            }
            catch (Exception ex)
            {
                MB.MessageBoxError(ex.Message);
            }
        }
    }
}
