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
using System.Threading;

namespace 登录页面
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(txtUser.Text=="admin" && txtPassword.Text=="123456")
            {
                Thread.Sleep(1000);
                label5.Content= "欢迎" + txtUser.Text + "登录本系统";
                Window1 win = new Window1();  
                win.Show();
                this.Close();
            }
            else
            {
                label5.Content = "用户名或密码错误\n" + "请重新输入";
                txtUser.Text = "";
                txtPassword.Text = "";
                txtUser.Focus();
            }  
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            txtUser.Text = "";
            txtPassword.Text = "";
            txtUser.Focus();
        }

        private void txtPassword_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}
