using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace MyMailSender.Classes
{
    static class MB
    {
        public static void MessageBoxError(string information)
        {
            MessageBox.Show(information, "Ошибка",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void MessageBoxInfo(string information)
        {
            MessageBox.Show(information, "Уведмоление",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
