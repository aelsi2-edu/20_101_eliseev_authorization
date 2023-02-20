using _20_101_eliseev_authorization.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace _20_101_eliseev_authorization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string LoginText { get; set; }
        public string PasswordText { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            LoginText = string.Empty;
            PasswordText = string.Empty;
        }
        public void OnLoginClick(object sender, RoutedEventArgs args)
        {
            var context = new EliseevControlContext();
            var query = from user in context.Users.Include(u => u.Role) where user.Password == PasswordText select user;
            var result = query.FirstOrDefault();
            if (result == null)
            {
                MessageBox.Show("Неверно введены логин или пароль!");
            }
            else
            {
                MessageBox.Show($"Добро пожаловать! Ваша роль: {result.Role.Name}");
            }
        }
    }
}
