using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TodoTasks.View.UserControls
{
    /// <summary>
    /// Interaction logic for titlebarMenuButtons.xaml
    /// </summary>
    public partial class TitlebarMenuButtons : UserControl
    {
        public TitlebarMenuButtons()
        {
            InitializeComponent();
        }

        private void MinimizeButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TasksWindow.GetWindow(this).WindowState = WindowState.Minimized;
        }

        private void MaximizeButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window tasksWindow = TasksWindow.GetWindow(this);

            if (tasksWindow.WindowState == WindowState.Maximized)
            {
                tasksWindow.WindowState = WindowState.Normal;
            }
            else
            {
                tasksWindow.WindowState = WindowState.Maximized;
            }
        }

        private void ExitButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TasksWindow.GetWindow(this).Close();
        }
    }
}
