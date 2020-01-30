using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace MyMailSender.Classes
{
    /// <summary>
    /// Вызывает MessageBox
    /// </summary>
    static class MB
    {
        /// <summary>
        /// Вызывает MessageBox с ошибкой
        /// </summary>
        /// <param name="information">информация</param>
        public static void MessageBoxError(string information)
        {
            MessageBox.Show(information, "Ошибка",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Вызывает MessageBox с уведомлением
        /// </summary>
        /// <param name="information">информация</param>
        public static void MessageBoxInfo(string information)
        {
            MessageBox.Show(information, "Уведмоление",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
